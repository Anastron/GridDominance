﻿using GridDominance.Shared.Resources;
using GridDominance.Shared.Screens.Common;
using GridDominance.Shared.Screens.NormalGameScreen.Entities;
using GridDominance.Shared.Screens.NormalGameScreen.Fractions;
using Microsoft.Xna.Framework;
using MonoSAMFramework.Portable.BatchRenderer;
using MonoSAMFramework.Portable.GameMath;
using MonoSAMFramework.Portable.GameMath.Geometry;
using MonoSAMFramework.Portable.Input;
using MonoSAMFramework.Portable.LogProtocol;
using MonoSAMFramework.Portable.Screens;
using MonoSAMFramework.Portable.Screens.Entities;

namespace GridDominance.Shared.Screens.Leveleditor.Entities
{
	class CannonStub : GameEntity, ILeveleditorStub
	{
		public enum CannonStubType { Bullet, Laser, Minigun, Relay, Shield, Trishot }
		public enum CannonStubFraction { N0=0, P1=1, A2=2, A3=3, A4=4 }
		public static readonly float[] SCALES = { 0.500f, 0.750f, 1.125f, 1.500f, 1.875f, 2.500f, 3.000f };

		private FPoint _position;
		private FSize _boundingBox;
		public float Scale = 1f;
		public float Rotation = 0f;
		public CannonStubType CannonType = CannonStubType.Bullet;
		public CannonStubFraction CannonFrac = CannonStubFraction.N0;

		public override FPoint Position => _position;
		public override FSize DrawingBoundingBox => new FSize(Cannon.CANNON_OUTER_DIAMETER * Scale, Cannon.CANNON_OUTER_DIAMETER * Scale);

		public override Color DebugIdentColor => Color.Red;

		public CannonStub(GameScreen scrn, FPoint pos, float scale) : base(scrn, GDConstants.ORDER_GAME_CANNON)
		{
			_position = pos;
		}

		public override void OnInitialize(EntityManager manager) { }
		public override void OnRemove() { }
		protected override void OnUpdate(SAMTime gameTime, InputState istate) { }

		protected override void OnDraw(IBatchRenderer sbatch)
		{
			switch (CannonType)
			{
				case CannonStubType.Bullet:
					CommonCannonRenderer.DrawBulletCannon_BG(sbatch, Position, Scale, Rotation, 1);
					break;

				case CannonStubType.Laser:
					break;

				case CannonStubType.Minigun:
					break;

				case CannonStubType.Relay:
					break;

				case CannonStubType.Shield:
					break;

				case CannonStubType.Trishot:
					break;

				default:
					SAMLog.Error("LECS::EnumSwitch_CS_OD", "CannonType = " + CannonType);
					break;
			}
		}

		protected override void OnDrawOrderedForegroundLayer(IBatchRenderer sbatch)
		{
			switch (CannonType)
			{
				case CannonStubType.Bullet:
					CommonCannonRenderer.DrawBulletCannon_FG(sbatch, Position, Scale, Rotation, 1, Lifetime * Cannon.BASE_COG_ROTATION_SPEED, 1, Fraction.FRACTION_COLORS[(int)CannonFrac]);
					break;

				case CannonStubType.Laser:
					break;

				case CannonStubType.Minigun:
					break;

				case CannonStubType.Relay:
					break;

				case CannonStubType.Shield:
					break;

				case CannonStubType.Trishot:
					break;

				default:
					SAMLog.Error("LECS::EnumSwitch_CS_ODOFL", "CannonType = " + CannonType);
					break;
			}
		}

		public bool CollidesWith(CannonStub other)
		{
			
			var minD = FloatMath.Max(this.Scale, other.Scale) * Cannon.CANNON_OUTER_DIAMETER/2 + FloatMath.Min(this.Scale, other.Scale) * Cannon.CANNON_DIAMETER / 2;

			return (Position - other.Position).LengthSquared() < minD * minD;
		}

		public void Kill()
		{
			Remove();
		}
	}
}
