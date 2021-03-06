﻿using FarseerPhysics;
using GridDominance.Shared.Resources;
using Microsoft.Xna.Framework;
using MonoSAMFramework.Portable.BatchRenderer;
using MonoSAMFramework.Portable.Extensions;
using MonoSAMFramework.Portable.Input;
using MonoSAMFramework.Portable.GameMath;
using GridDominance.Shared.Screens.NormalGameScreen.Fractions;
using MonoSAMFramework.Portable.GameMath.Geometry;
using MonoSAMFramework.Portable.GameMath.Geometry.Alignment;
using MonoSAMFramework.Portable.Screens;
using MonoSAMFramework.Portable.Screens.Entities;

namespace GridDominance.Shared.Screens.NormalGameScreen.Entities
{
	class BulletSplitter : GameEntity
	{
		private const float SPLITTER_SPEED = 30f;
		private const float SPLITTER_LIFETIME_MIN = 0.15f;
		private const float SPLITTER_LIFETIME_MAX = 0.35f;

		private static readonly Vector2[] VELOCITIES =
		{
			new Vector2(0, -SPLITTER_SPEED).Rotate(FloatMath.ToRadians(22.5f + (int)FlatAlign8.NN * 45f)),
			new Vector2(0, -SPLITTER_SPEED).Rotate(FloatMath.ToRadians(22.5f + (int)FlatAlign8.NE * 45f)),
			new Vector2(0, -SPLITTER_SPEED).Rotate(FloatMath.ToRadians(22.5f + (int)FlatAlign8.EE * 45f)),
			new Vector2(0, -SPLITTER_SPEED).Rotate(FloatMath.ToRadians(22.5f + (int)FlatAlign8.SE * 45f)),
			new Vector2(0, -SPLITTER_SPEED).Rotate(FloatMath.ToRadians(22.5f + (int)FlatAlign8.SS * 45f)),
			new Vector2(0, -SPLITTER_SPEED).Rotate(FloatMath.ToRadians(22.5f + (int)FlatAlign8.SW * 45f)),
			new Vector2(0, -SPLITTER_SPEED).Rotate(FloatMath.ToRadians(22.5f + (int)FlatAlign8.WW * 45f)),
			new Vector2(0, -SPLITTER_SPEED).Rotate(FloatMath.ToRadians(22.5f + (int)FlatAlign8.NW * 45f)),
		};

		public readonly Fraction Fraction;
		public float ShapeAlpha;
		public FPoint ShapePosition;
		public float ShapeRotation = 0f;

		private readonly float scale;
		
		private readonly float maxLifetime;

		private readonly float rotationSpeed = 0f;
		private readonly Vector2 velocity;

		public override FPoint Position => ShapePosition;
		public override FSize DrawingBoundingBox { get; }
		public override Color DebugIdentColor => Fraction.Color;

		public BulletSplitter(GameScreen scrn, BaseBullet b, FlatAlign8 d) : base(scrn, GDConstants.ORDER_GAME_BULLETPARTICLE)
		{
			scale = b.Scale;
			ShapePosition = b.BulletPosition;
			ShapeAlpha = 1f;
			Fraction = b.Fraction;
			velocity = VELOCITIES[(int)d] * FloatMath.GetRangedRandom(0.5f, 2f) + ConvertUnits.ToDisplayUnits(b.PhysicsBody.LinearVelocity)/10f;
			maxLifetime = FloatMath.GetRangedRandom(SPLITTER_LIFETIME_MIN, SPLITTER_LIFETIME_MAX);
			ShapeRotation = FloatMath.ToRadians((int) d * 45f);
			rotationSpeed = FloatMath.GetRangedRandom(-FloatMath.TAU, FloatMath.TAU);

			DrawingBoundingBox = new FSize(BaseBullet.BULLET_DIAMETER, BaseBullet.BULLET_DIAMETER) * scale;
		}

		public override void OnInitialize(EntityManager manager)
		{
			//
		}

		public override void OnRemove()
		{
			//
		}
		
		protected override void OnUpdate(SAMTime gameTime, InputState istate)
		{
			ShapePosition += velocity * gameTime.ElapsedSeconds;

			ShapeRotation = FloatMath.IncModulo(ShapeRotation, rotationSpeed * gameTime.ElapsedSeconds, FloatMath.TAU);

			if (Lifetime < maxLifetime) ShapeAlpha = 1 - Lifetime / maxLifetime;
			if (Lifetime > maxLifetime) Alive = false;
		}

		protected override void OnDraw(IBatchRenderer sbatch)
		{
			sbatch.DrawCentered(
				Textures.TexBulletSplitter,
				ShapePosition,
				scale * BaseBullet.BULLET_DIAMETER,
				scale * BaseBullet.BULLET_DIAMETER,
				Fraction.Color * ShapeAlpha, ShapeRotation);
		}
	}
}
