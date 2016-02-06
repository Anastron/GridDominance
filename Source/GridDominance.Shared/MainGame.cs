﻿using System;
using GridDominance.Shared.Framework;
using GridDominance.Shared.Resources;
using GridDominance.Shared.Screens.GameScreen;
using Microsoft.Xna.Framework;

namespace GridDominance.Shared
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class MainGame : Game
	{
		private ScreenManager screens;

		private readonly GraphicsDeviceManager graphics;

		public MainGame()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			base.Initialize();

#if __DESKTOP__
			IsMouseVisible = true;
			graphics.IsFullScreen = false;

			graphics.PreferredBackBufferWidth = 1200;
			graphics.PreferredBackBufferHeight = 900;
			Window.AllowUserResizing = true;
			graphics.ApplyChanges();
			Window.Position = new Point((1920 - graphics.PreferredBackBufferWidth) / 2, (1080 - graphics.PreferredBackBufferHeight) / 2);

			IsFixedTimeStep = true;
			TargetElapsedTime = TimeSpan.FromMilliseconds(1);
#else
			graphics.IsFullScreen = true;
			graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;
			graphics.ApplyChanges();
#endif

			screens = new ScreenManager(this)
			{
				CurrentScreen = new GameScreen(this, graphics)
			};
		}

		protected override void LoadContent()
		{
			Textures.LoadContent(Content);
		}

		protected override void UnloadContent()
		{
			// NOP
		}

		protected override void Update(GameTime gameTime)
		{
			screens.Update(gameTime);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			screens.Draw(gameTime);

			base.Draw(gameTime);
		}
	}
}
