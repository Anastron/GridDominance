﻿using System;
using System.IO;
using GridDominance.Shared.Resources;
using GridDominance.Shared.Screens.NormalGameScreen;
using MonoSAMFramework.Portable.LogProtocol;
using MonoSAMFramework.Portable.Network.Multiplayer;
using MonoSAMFramework.Portable;
using GridDominance.Shared.Screens.NormalGameScreen.Entities;
using MonoSAMFramework.Portable.GameMath;
using MonoSAMFramework.Portable.Screens;
using GridDominance.Shared.Screens.NormalGameScreen.Fractions;
using GridDominance.Levelfileformat.Blueprint;

namespace GridDominance.Shared.Network.Multiplayer
{
	public class GDMultiplayerClient : GDMultiplayerCommon
	{
		public Guid LevelID;
		public GameSpeedModes Speed;
		public int MusicIndex;
		public ulong ServerGameVersion;
		public ulong ServerLevelHash;

		public ushort LastServerPackageSeq;
		public float LastServerPackageTime;

		public GDMultiplayerClient()
			: base(new UDPNetworkMedium(GDConstants.MULTIPLAYER_SERVER_HOST, GDConstants.MULTIPLAYER_SERVER_PORT))
		{
#if DEBUG
			AddDebugLine(MonoSAMGame.CurrentInst.GetCurrentScreen());
#endif
		}

#if DEBUG
		public void AddDebugLine(GameScreen s)
		{
			s.DebugDisp.AddLine("DebugMultiplayer", () => 
				$"CLIENT(Ping={Ping.Value:0.0000} | Loss={PackageLossPerc * 100:00.00}% | State={ConnState} | Mode={Mode} | Packages={packageCount} (l={packageModSize}byte) | Ctr={msgIdWraps:00}:{msgId:000})\n" + 
				$"CLIENT(ServerSeq={LastServerPackageSeq} | ServerTime={LastServerPackageTime:000.00}s | LagBehind={lagBehindTime})");
		}
#endif
		
		protected override bool ProcessSpecificMessage(byte cmd, byte[] data)
		{
			if (cmd == CMD_FORWARDLOBBYSYNC)
			{
				if (Mode == ServerMode.InLobby)
				{
					ProcessForwardLobbySync(data);
					return true;
				}
			}
			else if (cmd == CMD_FORWARD)
			{
				if (Mode == ServerMode.InLobby)
				{
					Mode = ServerMode.InGame;
					ProcessForward(data);
					return true;
				}
				else if (Mode == ServerMode.InGame)
				{
					ProcessForward(data);
					return true;
				}
			}

			return false;
		}

		private void ProcessForwardLobbySync(byte[] data)
		{
			// [8: CMD] [8:seq] [16: SessionID] [4: UserID] [12: SessionSecret]

			UserConn[0].LastResponse = MonoSAMGame.CurrentTime.TotalElapsedSeconds;
			
			using (BinaryReader reader = new BinaryReader(new MemoryStream(data)))
			{
				reader.ReadByte(); // CMD
				reader.ReadByte(); // SEQ
				reader.ReadByte(); // SID
				reader.ReadByte(); // SID
				reader.ReadByte(); // SSC
				reader.ReadByte(); // SSC
				LevelID = new Guid(reader.ReadBytes(16));
				Speed = (GameSpeedModes) reader.ReadByte();
				MusicIndex = reader.ReadByte();
				ServerGameVersion = reader.ReadUInt64();
				ServerLevelHash = reader.ReadUInt64();
			}

			SAMLog.Debug($"[[CMD_FORWARDLOBBYSYNC]]: {LevelID} | {Speed} | {MusicIndex}");

			if (ServerGameVersion != GDConstants.IVersion)
			{
				ErrorStop(ErrorType.GameVersionMismatch, null);
				return;
			}

			LevelBlueprint blueprint;
			if (! Levels.LEVELS.TryGetValue(LevelID, out blueprint))
			{
				ErrorStop(ErrorType.LevelNotFound, null);
				SAMLog.Error("GDMC::LNF", "ProcessForwardLobbySync -> LevelNotFound: " + LevelID);
				return;
			}

			var correctCS = blueprint.CalcCheckSum();
			if (ServerLevelHash != correctCS)
			{
				ErrorStop(ErrorType.LevelVersionMismatch, null);
				SAMLog.Error("GDMC::LVM", "ProcessForwardLobbySync -> LevelVersionMismatch: " + ServerLevelHash + " <> " + correctCS);
				return;
			}

			byte[] answer = new byte[8];

			answer[0] = ANS_FORWARDLOBBYSYNC;
			SetSequenceCounter(ref answer[1]);
			answer[2] = (byte) ((SessionID >> 8) & 0xFF);
			answer[3] = (byte) (SessionID & 0xFF);
			answer[4] = (byte) (((SessionUserID & 0xF) << 4) | ((SessionSecret >> 8) & 0x0F));
			answer[5] = (byte) (SessionSecret & 0xFF);
			answer[6] = (byte) SessionUserID;
			_medium.Send(answer);
		}

		private void ProcessForward(byte[] d)
		{
			if (Screen == null) return;

			// [8: CMD] [8:seq] [16: SessionID] [4: UserID] [12: SessionSecret] [32:Time] [~: Payload]

			var seq = NetworkDataTools.GetByte(d[1]);
			var msgSessionID = NetworkDataTools.GetSplitBits(d[2], d[3], 8, 8);
			var msgUserID = NetworkDataTools.GetHighBits(d[4], 4);
			var msgSessionSecret = NetworkDataTools.GetSplitBits(d[4], d[5], 4, 8);
			var msgTime = NetworkDataTools.GetSingle(d[6], d[7], d[8], d[9]);

			LastServerPackageSeq = seq;
			LastServerPackageTime = msgTime;

			if (msgSessionID != SessionID || msgSessionSecret != SessionSecret || msgUserID != 0)
			{
				SAMLog.Warning("SNS-Client", $"Invalid server message: ({msgSessionID} != {SessionID} || {msgSessionSecret} != {SessionSecret} || {msgUserID} != {0})");
				return;
			}

			if (IsSeqGreater(UserConn[msgUserID].LastRecievedSeq, seq))
			{
				ProcessStateData(d, msgUserID);
			}
			else
			{
				SAMLog.Debug("Ignore Out-Of-Order Message");
			}

			RecieveMsg(msgUserID, seq);
		}

		protected override void SendGameStateNow()
		{
			if (Screen == null) return;

			packageCount = 0;

			NetworkDataTools.SetByteWithHighBits(out MSG_FORWARD[2], SessionID, 16);
			NetworkDataTools.SetByteWithLowBits(out MSG_FORWARD[3], SessionID, 16);
			NetworkDataTools.SetSplitByte(out MSG_FORWARD[4], SessionUserID, SessionSecret, 4, 12, 4, 4);
			NetworkDataTools.SetByteWithLowBits(out MSG_FORWARD[5], SessionSecret, 12);
			NetworkDataTools.SetSingle(out MSG_FORWARD[6], out MSG_FORWARD[7], out MSG_FORWARD[8], out MSG_FORWARD[9], Screen.LevelTime);

			int p = PACKAGE_FORWARD_HEADER_SIZE;
			SendForwardBulletCannons(ref p);
			SendAndReset(ref p);
		}

		protected override bool ShouldRecieveData(Fraction f, Cannon c) => !Screen.HasFinished;
		protected override bool ShouldRecieveRotationData(Fraction f, Cannon c) => f != Screen.LocalPlayerFraction;
		protected override bool ShouldRecieveStateData(Fraction f, Cannon c) => true;

		protected override bool ShouldSendData(BulletCannon c) => c.Fraction == Screen.LocalPlayerFraction;
		protected override bool ShouldSendData(LaserCannon c) => c.Fraction == Screen.LocalPlayerFraction;
	}
}