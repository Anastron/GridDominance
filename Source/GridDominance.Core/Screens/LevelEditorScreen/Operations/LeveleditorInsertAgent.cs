﻿using GridDominance.Shared.Resources;
using GridDominance.Shared.Screens.LevelEditorScreen.Entities;
using MonoSAMFramework.Portable.GameMath;
using MonoSAMFramework.Portable.GameMath.Geometry;
using MonoSAMFramework.Portable.Input;
using MonoSAMFramework.Portable.Screens;
using MonoSAMFramework.Portable.UpdateAgents;

namespace GridDominance.Shared.Screens.LevelEditorScreen.Operations
{
	public class LeveleditorInsertAgent : SAMUpdateOp<LevelEditorScreen>
	{
		private LevelEditorScreen _gdScreen;

		public override string Name => "LeveleditorInsertAgent";

		private ILeveleditorStub _preview = null;

		public LeveleditorInsertAgent()
		{
			//
		}

		protected override void OnInit(LevelEditorScreen screen)
		{
			_gdScreen = screen;
		}

		protected override void OnUpdate(LevelEditorScreen screen, SAMTime gameTime, InputState istate)
		{
			const float raster = (GDConstants.TILE_WIDTH / 2f);
			var x = raster * FloatMath.Round(istate.GamePointerPositionOnMap.X / raster);
			var y = raster * FloatMath.Round(istate.GamePointerPositionOnMap.Y / raster);

			if (_gdScreen.Mode == LevelEditorMode.AddCannon && istate.IsExclusiveJustDown)
			{
				istate.Swallow(InputConsumer.GameBackground);

				var stub = _gdScreen.CanInsertCannonStub(new FPoint(x, y), null);
				if (stub != null)
				{
					_preview = stub;
					_gdScreen.Entities.AddEntity(stub);
					_gdScreen.SelectStub(_preview);
					_gdScreen.DragAgent.ManualStartCannonMove(istate);
				}
			}

			if (_gdScreen.Mode == LevelEditorMode.AddObstacle && istate.IsExclusiveJustDown)
			{
				istate.Swallow(InputConsumer.GameBackground);

				var stub = _gdScreen.CanInsertObstacleStub(
					new FPoint(x, y),
					ObstacleStub.ObstacleStubType.VoidVircle,
					GDConstants.TILE_WIDTH * 2f,
					GDConstants.TILE_WIDTH * 2f,
					0,
					null);

				if (stub != null)
				{
					_preview = stub;
					_gdScreen.Entities.AddEntity(stub);
					_gdScreen.SelectStub(_preview);
					_gdScreen.DragAgent.ManualStartObstacleMove(istate);
				}
			}

			if (_gdScreen.Mode == LevelEditorMode.AddWall && istate.IsExclusiveJustDown)
			{
				istate.Swallow(InputConsumer.GameBackground);

				var stub = _gdScreen.CanInsertWallStub(new FPoint(x, y), GDConstants.TILE_WIDTH * 2, null);

				if (stub != null)
				{
					_preview = stub;
					_gdScreen.Entities.AddEntity(stub);
					_gdScreen.SelectStub(_preview);
					_gdScreen.DragAgent.ManualStartWallDragP2(istate);
				}
			}

			if (_gdScreen.Mode == LevelEditorMode.AddPortal && istate.IsExclusiveJustDown)
			{
				istate.Swallow(InputConsumer.GameBackground);

				var stub = _gdScreen.CanInsertPortalStub(new FPoint(x, y), GDConstants.TILE_WIDTH * 2, 0, null);

				if (stub != null)
				{
					_preview = stub;
					_gdScreen.Entities.AddEntity(stub);
					_gdScreen.SelectStub(_preview);
					_gdScreen.DragAgent.ManualStartPortalMove(istate);
				}
			}
		}
	}
}
