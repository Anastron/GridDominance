﻿using MonoSAMFramework.Portable.GameMath;
using MonoSAMFramework.Portable.Input;
using MonoSAMFramework.Portable.Screens;
using MonoSAMFramework.Portable.UpdateAgents.Impl;

namespace GridDominance.Shared.Screens.NormalGameScreen.Entities.EntityOperations
{
	class ShakeTextOperation : IntervalOperation<BackgroundText>
	{
		private const float TIME_BETWEEN = 20.0f;
		private const float TIME_SHAKE   =  1.0f;
		private const int   SHAKE_COUNT   =  6;
		private const float SHAKE_OFFSET   =  FloatMath.RAD_NEG_001;

		public override string Name => "ShakeText";

		public ShakeTextOperation() : base(TIME_BETWEEN, TIME_BETWEEN, TIME_SHAKE)
		{
		}

		protected override void OnCycleStart(BackgroundText entity, SAMTime gameTime, InputState istate)
		{
			//
		}

		protected override void OnCycleProgress(BackgroundText entity, float progress, SAMTime gameTime, InputState istate)
		{
			entity.SuperRotation = FloatMath.Sin(progress * FloatMath.TAU * SHAKE_COUNT) * SHAKE_OFFSET;
		}

		protected override void OnCycleEnd(BackgroundText entity, SAMTime gameTime, InputState istate)
		{
			entity.SuperRotation = 0f;
		}
	}
}
