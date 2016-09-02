﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoSAMFramework.Portable.BatchRenderer;
using MonoSAMFramework.Portable.Extensions;
using MonoSAMFramework.Portable.Input;
using MonoSAMFramework.Portable.GameMath.FloatClasses;
using MonoSAMFramework.Portable.RenderHelper;
using MonoSAMFramework.Portable.Screens.HUD.Enums;

namespace MonoSAMFramework.Portable.Screens.HUD.Elements.Primitives
{
	public class HUDRawText : HUDElement
	{
		public override int Depth { get; }

		private string _textCache = "";
		private float _fsizeCache = -1;

		private string _text = "";
		public string Text
		{
			get { return _text; }
			set { _text = value; InvalidatePosition(); }
		}

		public Color TextColor = Color.Magenta;

		private float _fontScale = 1f;
		private float _fontVOffset = 0f;
		private float _fontSize = 16;
		public float FontSize
		{
			get { return _fontSize; }
			set { _fontSize = value; InvalidatePosition(); }
		}

		public SpriteFont Font;

		public HUDRawText(int depth = 0)
		{
			Depth = depth;
		}

		protected override void DoDraw(IBatchRenderer sbatch, FRectangle bounds)
		{
			if (Alignment == HUDAlignment.CENTER || Alignment == HUDAlignment.CENTERLEFT || Alignment == HUDAlignment.CENTERRIGHT)
			{
				sbatch.DrawString(
					Font, 
					_textCache, 
					new Vector2(bounds.Left, bounds.Top + _fontVOffset), 
					TextColor, 
					0, 
					Vector2.Zero, 
					_fontScale, 
					SpriteEffects.None, 
					0);
			}
			else
			{
				sbatch.DrawString(
					Font, 
					_textCache, 
					bounds.VectorTopLeft, 
					TextColor, 
					0,
					Vector2.Zero, 
					_fontScale, 
					SpriteEffects.None, 
					0);
			}
		}

		public override void OnInitialize()
		{
			if (Font == null) Font = HUD.DefaultFont;
		}

		public override void OnRemove()
		{
			// NOP
		}

		protected override void DoUpdate(GameTime gameTime, InputState istate)
		{
			// NOP
		}

		protected override void OnBeforeRecalculatePosition()
		{
			base.OnBeforeRecalculatePosition();

			// ReSharper disable once CompareOfFloatsByEqualityOperator
			if (_fsizeCache != _fontSize)
			{
				_fontScale = FontRenderHelper.GetFontScale(Font, FontSize);
				
				_fsizeCache = _fontSize;
			}

			if (_textCache != _text)
			{
				Size = (Font.MeasureString(_text) * _fontScale).ToSize();

				_textCache = _text;
			}

			_fontVOffset = FontRenderHelper.GetFontVCenterOffset(Font) * _fontScale;
		}

		protected override void DrawDebugHUDBorders(IBatchRenderer sbatch)
		{
			sbatch.DrawRectangle(BoundingRectangle, Color.Magenta, 1f);
			sbatch.DrawLine(BoundingRectangle.VectorTopLeft, BoundingRectangle.VectorBottomRight, Color.Magenta, 1f);
			sbatch.DrawLine(BoundingRectangle.VectorTopRight, BoundingRectangle.VectorBottomLeft, Color.Magenta, 1f);
		}
	}
}
