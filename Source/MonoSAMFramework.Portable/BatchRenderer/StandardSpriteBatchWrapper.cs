﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Shapes;
using MonoGame.Extended.TextureAtlases;
using MonoSAMFramework.Portable.Extensions;
using MonoSAMFramework.Portable.GameMath;
using MonoSAMFramework.Portable.GameMath.FloatClasses;
using MonoSAMFramework.Portable.GameMath.VectorPath;
using MonoSAMFramework.Portable.RenderHelper;
using System;
using System.Linq;
using System.Text;

namespace MonoSAMFramework.Portable.BatchRenderer
{
	/// <summary>
	/// Thin wrapper around SpriteBatch
	/// 
	/// Some methods in this class come from MonoGameExtended.SpritebatchWrapper
	/// </summary>
	class StandardSpriteBatchWrapper : IBatchRenderer, IDebugBatchRenderer
	{
		private readonly SpriteBatch internalBatch;

#if DEBUG
		public int LastRenderSpriteCount { get; private set; }
		public int LastRenderTextCount { get; private set; }

		private int renderSpriteCount;
		private int renderTextCount;
#endif

		public StandardSpriteBatchWrapper(GraphicsDevice device)
		{
			internalBatch = new SpriteBatch(device);
		}

		public StandardSpriteBatchWrapper(SpriteBatch sbatch)
		{
			internalBatch = sbatch;
		}

		public void Dispose()
		{
			internalBatch.Dispose();
		}

		public void OnBegin()
		{
#if DEBUG
			renderSpriteCount = 0;
			renderTextCount = 0;
#endif
		}

		public void Begin(SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null, SamplerState samplerState = null, DepthStencilState depthStencilState = null, RasterizerState rasterizerState = null, Effect effect = null, Matrix? transformMatrix = null)
		{
			OnBegin();

			internalBatch.Begin(sortMode, blendState, samplerState, depthStencilState, rasterizerState, effect, transformMatrix);
		}

		public void OnEnd()
		{
#if DEBUG
			LastRenderSpriteCount = renderSpriteCount;
			LastRenderTextCount = renderTextCount;
#endif
		}

		public void End()
		{
			internalBatch.End();

			OnEnd();
		}

		public void Draw(Texture2D texture, Vector2? position = null, Rectangle? destinationRectangle = null, Rectangle? sourceRectangle = null, Vector2? origin = null, float rotation = 0, Vector2? scale = null, Color? color = null, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(texture, position, destinationRectangle, sourceRectangle, origin, rotation, scale, color, effects, layerDepth);
		}

		public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
		}

		public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
		}

		public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(texture, destinationRectangle, sourceRectangle, color, rotation, origin, effects, layerDepth);
		}

		public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(texture, position, sourceRectangle, color);
		}

		public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
		}

		public void Draw(Texture2D texture, Vector2 position, Color color)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(texture, position, color);
		}

		public void Draw(Texture2D texture, Rectangle destinationRectangle, Color color)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(texture, destinationRectangle, color);
		}

		public void Draw(Texture2D texture, Vector2? position = null, FRectangle? destinationRectangle = null, Rectangle? sourceRectangle = null, Vector2? origin = null, float rotation = 0, Vector2? scale = null, Color? color = null, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(texture, position, destinationRectangle?.Truncate(), sourceRectangle, origin, rotation, scale, color, effects, layerDepth);
		}

		public void Draw(Texture2D texture, FRectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(texture, destinationRectangle.Truncate(), sourceRectangle, color, rotation, origin, effects, layerDepth);
		}

		public void Draw(Texture2D texture, FRectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(texture, destinationRectangle.Truncate(), sourceRectangle, color);
		}

		public void Draw(Texture2D texture, FRectangle destinationRectangle, Color color)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(texture, destinationRectangle.Truncate(), color);
		}


		public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color)
		{
#if DEBUG
			renderTextCount += text.Length;
#endif

			internalBatch.DrawString(spriteFont, text, position, color);
		}

		public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
		{
#if DEBUG
			renderTextCount += text.Length;
#endif

			internalBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
		}

		public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
		{
#if DEBUG
			renderTextCount += text.Length;
#endif

			internalBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
		}

		public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color)
		{
#if DEBUG
			renderTextCount += text.Length;
#endif

			internalBatch.DrawString(spriteFont, text, position, color);
		}

		public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
		{
#if DEBUG
			renderTextCount += text.Length;
#endif

			internalBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
		}

		public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
		{
#if DEBUG
			renderTextCount += text.Length;
#endif

			internalBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
		}

		public void DrawPolygon(Vector2 position, PolygonF polygon, Color color, float thickness = 1f)
		{
			DrawPolygon(position, polygon.Vertices, color, true, thickness);
		}

		public void DrawPolygon(Vector2 offset, Vector2[] points, Color color, bool closed, float thickness)
		{
			if (points.Length == 0)
				return;

			if (points.Length == 1)
			{
				DrawPoint(points[0], color, (int)thickness);
				return;
			}

			var texture = StaticTextures.SinglePixel;

			for (var i = 0; i < points.Length - 1; i++)
				DrawPolygonEdge(texture, points[i] + offset, points[i + 1] + offset, color, thickness);

			if (closed) DrawPolygonEdge(texture, points[points.Length - 1] + offset, points[0] + offset, color, thickness);
		}

		private void DrawPolygonEdge(TextureRegion2D texture, Vector2 point1, Vector2 point2, Color color, float thickness)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			var length = Vector2.Distance(point1, point2);
			var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
			var scale = new Vector2(length, thickness);

			internalBatch.Draw(
				texture: texture.Texture,
				position: point1, 
				sourceRectangle: texture.Bounds, 
				color: color, 
				rotation: angle, 
				scale: scale);
		}

		public void FillRectangle(FRectangle rectangle, Color color)
		{
			FillRectangle(rectangle.Location, rectangle.Size, color);
		}

		public void FillRectangle(Vector2 location, Vector2 size, Color color)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(
				StaticTextures.SinglePixel.Texture, 
				location,
				StaticTextures.SinglePixel.Bounds, 
				color, 
				0, 
				Vector2.Zero, 
				size, 
				SpriteEffects.None, 
				0);
		}

		public void FillRectangle(float x, float y, float width, float height, Color color)
		{
			FillRectangle(new Vector2(x, y), new Vector2(width, height), color);
		}

		public void DrawRectangle(FRectangle rectangle, Color color, float thickness = 1f)
		{
#if DEBUG
			renderSpriteCount+=4;
#endif

			var pixel = StaticTextures.SinglePixel;
			var topLeft = new Vector2(rectangle.X, rectangle.Y);
			var topRight = new Vector2(rectangle.Right - thickness, rectangle.Y);
			var bottomLeft = new Vector2(rectangle.X, rectangle.Bottom - thickness);
			var horizontalScale = new Vector2(rectangle.Width, thickness);
			var verticalScale = new Vector2(thickness, rectangle.Height);

			internalBatch.Draw(pixel.Texture, topLeft,    sourceRectangle: pixel.Bounds, scale: horizontalScale, color: color);
			internalBatch.Draw(pixel.Texture, topLeft,    sourceRectangle: pixel.Bounds, scale: verticalScale,   color: color);
			internalBatch.Draw(pixel.Texture, topRight,   sourceRectangle: pixel.Bounds, scale: verticalScale,   color: color);
			internalBatch.Draw(pixel.Texture, bottomLeft, sourceRectangle: pixel.Bounds, scale: horizontalScale, color: color);
		}

		public void DrawRectangle(Vector2 location, Vector2 size, Color color, float thickness = 1f)
		{
			DrawRectangle(new FRectangle(location.X, location.Y, size.X, size.Y), color, thickness);
		}

		public void DrawLine(float x1, float y1, float x2, float y2, Color color, float thickness = 1f)
		{
			DrawLine(new Vector2(x1, y1), new Vector2(x2, y2), color, thickness);
		}

		public void DrawLine(Vector2 point1, Vector2 point2, Color color, float thickness = 1f)
		{
			var distance = Vector2.Distance(point1, point2);
			var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);

			DrawLine(point1, distance, angle, color, thickness);
		}

		public void DrawLine(Vector2 point, float length, float angle, Color color, float thickness = 1f)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			var origin = new Vector2(0f, 0.5f);
			var scale = new Vector2(length, thickness);
			internalBatch.Draw(StaticTextures.SinglePixel.Texture, point, StaticTextures.SinglePixel.Bounds, color, angle, origin, scale, SpriteEffects.None, 0);
		}

		public void DrawPoint(float x, float y, Color color, float size = 1f)
		{
			DrawPoint(new Vector2(x, y), color, size);
		}

		public void DrawPoint(Vector2 position, Color color, float size = 1f)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			var scale = Vector2.One * size;
			var offset = new Vector2(0.5f) - new Vector2(size * 0.5f);
			internalBatch.Draw(StaticTextures.SinglePixel.Texture, position + offset, sourceRectangle: StaticTextures.SinglePixel.Bounds, color: color, scale: scale);
		}
		
		public void DrawCircle(CircleF circle, int sides, Color color, float thickness = 1f)
		{
			DrawCircle(circle.Center, circle.Radius, sides, color, thickness);
		}

		public void DrawCircle(Vector2 center, float radius, int sides, Color color, float thickness = 1f)
		{
			DrawPolygon(center, SpriteBatchCommon.CreateCircle(radius, sides), color, true, thickness);
		}

		public void DrawCirclePiece(Vector2 center, float radius, float angleMin, float angleMax, int sides, Color color, float thickness = 1f)
		{
			Vector2[] poly = SpriteBatchCommon.CreateCirclePiece(radius, angleMin, angleMax, sides);

			DrawPolygon(center, poly, color, false, thickness);
			DrawLine(center, center + poly.First(), color, thickness);
			DrawLine(center, center + poly.Last(), color, thickness);
		}

		public void DrawPath(Vector2 pos, VectorPath path, int segments, Color color, float thickness = 1)
		{
			var last = pos + path.Get(0);
			for (int i = 1; i <= segments; i++)
			{
				var next = pos + path.Get((path.Length * i) / (segments+1));

				DrawPolygonEdge(StaticTextures.SinglePixel, last, next, color, thickness);

				last = next;
			}
		}

		public void DrawCircle(float x, float y, float radius, int sides, Color color, float thickness = 1f)
		{
			DrawPolygon(new Vector2(x, y), SpriteBatchCommon.CreateCircle(radius, sides), color, true, thickness);
		}

		public void FillCircle(Vector2 center, float radius, int sides, Color color)
		{
#if DEBUG
			renderSpriteCount += sides;
#endif

			float width = FloatMath.Sqrt(radius * radius * 2);

			for (int i = 0; i < sides; i++)
			{
				internalBatch.Draw(
					StaticTextures.SinglePixel.Texture,
					center,
					StaticTextures.SinglePixel.Bounds,
					color,
					(FloatMath.TAU * i) / (4f * sides),
					StaticTextures.SinglePixel.Center(),
					new Vector2(width, width), 
					SpriteEffects.None,
					0);
			}
		}

		public void DrawEllipse(FRectangle rectangle, int sides, Color color, float thickness = 1f)
		{
			DrawPolygon(rectangle.Center, SpriteBatchCommon.CreateEllipse(rectangle.Width, rectangle.Height, sides), color, true, thickness);
		}

		public void Draw(TextureRegion2D textureRegion, Vector2 position, Color color)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(textureRegion.Texture, position, textureRegion.Bounds, color, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
		}

		public void Draw(TextureRegion2D textureRegion, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(textureRegion.Texture, position, textureRegion.Bounds, color, rotation, origin, scale, effects, layerDepth);
		}

		public void Draw(TextureRegion2D textureRegion, Rectangle destinationRectangle, Color color)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(textureRegion.Texture, destinationRectangle, textureRegion.Bounds, color);
		}

		public void Draw(TextureRegion2D textureRegion, FRectangle destinationRectangle, Color color)
		{
#if DEBUG
			renderSpriteCount++;
#endif

			internalBatch.Draw(textureRegion.Texture, destinationRectangle.Truncate(), textureRegion.Bounds, color);
		}
	}
}
