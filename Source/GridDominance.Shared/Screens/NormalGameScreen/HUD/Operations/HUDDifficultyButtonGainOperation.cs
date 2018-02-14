﻿using GridDominance.Shared.Screens.NormalGameScreen.HUD;
using MonoSAMFramework.Portable.ColorHelper;
using MonoSAMFramework.Portable.Input;
using MonoSAMFramework.Portable.GameMath;
using MonoSAMFramework.Portable.Screens;
using MonoSAMFramework.Portable.UpdateAgents.Impl;

namespace GridDominance.Shared.Screens.NormalGameScreen.HUDOperations
{
	public class HUDDifficultyButtonGainOperation : FixTimeOperation<HUDDifficultyButton>
	{
		public HUDDifficultyButtonGainOperation() : base(3f)
		{
		}

		protected override void OnProgress(HUDDifficultyButton element, float progress, SAMTime gameTime, InputState istate)
		{
			element.BackgroundColor = ColorMath.Blend(FlatColors.ButtonHUD, FlatColors.BackgroundHUD2, progress);
			element.IconScale = FloatMath.FunctionEaseOutElastic(progress);
		}

		public override string Name => "DifficultyButtonGain";
	}
}
