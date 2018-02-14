﻿using GridDominance.Shared.Screens.NormalGameScreen.HUD;
using MonoSAMFramework.Portable.ColorHelper;
using MonoSAMFramework.Portable.Input;
using MonoSAMFramework.Portable.GameMath;
using MonoSAMFramework.Portable.Screens;
using MonoSAMFramework.Portable.UpdateAgents;

namespace GridDominance.Shared.Screens.NormalGameScreen.HUDOperations
{
	public class HUDMultiplayerDifficultyButtonBlinkingIconOperation : SAMUpdateOp<HUDMultiplayerDifficultyButton>
	{
		private const float BLINK_LENGTH = 1.5f;
		
		protected override void OnUpdate(HUDMultiplayerDifficultyButton element, SAMTime gameTime, InputState istate)
		{
			element.ForegroundColor = ColorMath.Blend(FlatColors.SunFlower, FlatColors.Orange, FloatMath.Sin(Lifetime / BLINK_LENGTH) / 2f + 0.5f);
		}

		public override string Name => "BlinkingDifficultyButtonIcon";
	}
}
