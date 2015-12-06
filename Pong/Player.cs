﻿using System;
using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
	public class Player : Entity
	{
		private readonly Texture2D pixelTexture;
		private Vector2 position;
		private int size;
		private int thickness;
		public int PlayerNumer;

		public Player(Game game) : base(game)
		{
			Entities.Instance.AddEntity(this);
			pixelTexture = new Texture2D(game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
			pixelTexture.SetData(new[] {Color.White});
			position = new Vector2(0, 0);
			thickness = 1;
			size = 1;
			PlayerNumer = 0;
			Type = EntityType.Player;
			Collider = new Collider(GetLocalBounds());
		}

		public override void Draw(GameTime gameTime)
		{
			Game1.spriteBatch.Draw(pixelTexture, GetLocation(), GetBoundingBox(), Color.White);

			base.Draw(gameTime);
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}

		public void SetPlayerNumber(int number)
		{
			PlayerNumer = number;
		}

		public void SetColor(Color color)
		{
			pixelTexture.SetData(new[] {color});
		}

		public void SetPosition(Vector2 newPosition)
		{
			position = newPosition;
			Collider.Update(GetLocalBounds());
		}

		public void SetPosition(OnScreenPosition side, OnScreenPosition height)
		{
			if (side == OnScreenPosition.Left)
			{
				position.X = thickness/2;
			}
			else
			{
				position.X = game.Window.ClientBounds.Width - thickness/2;
			}
			if (height == OnScreenPosition.Top)
			{
				position.Y = size/2;
			}
			else
			{
				if (height == OnScreenPosition.Center)
				{
					position.Y = game.Window.ClientBounds.Height/2;
				}
				else
				{
					position.Y = game.Window.ClientBounds.Height - size/2;
				}
			}
			Collider.Update(GetLocalBounds());
		}

		public Vector2 GetPosition()
		{
			return position;
		}

		public void Move(Vector2 moveBy)
		{
			position.X += moveBy.X;
			position.Y += moveBy.Y;
			Collider.Update(GetLocalBounds());
		}

		private Vector2 GetLocation()
		{
			return new Vector2(position.X - thickness/2, position.Y - size/2);
		}

		public Rectangle GetBoundingBox()
		{
			return new Rectangle(0, 0, thickness, size);
		}

		public void SetThickness(int thickness)
		{
			this.thickness = thickness;
			Collider.Update(GetLocalBounds());
		}

		public int GetThickness()
		{
			return thickness;
		}

		public void SetSize(int size)
		{
			this.size = size;
			Collider.Update(GetLocalBounds());
		}

		public void ChangeSize(int change)
		{
			size += change;
			Collider.Update(GetLocalBounds());
		}

		public void ChangeSizeByPrecentage(float procentage)
		{
			size = (int) (size*(1.0f + 1.0f/procentage));
			Collider.Update(GetLocalBounds());
		}

		public override Rectangle GetLocalBounds()
		{
			return new Rectangle((int)GetLocation().X, (int)GetLocation().Y, thickness, size);
		}
	}
}