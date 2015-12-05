using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Framework;

namespace Pong
{
	class Player : Entity
	{
		public Player(Game game) : base(game)
		{
			Entities.Instance.AddEntity(this);
			pixelTexture = new Texture2D(game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
			pixelTexture.SetData<Color>(new Color[] {Color.White});
			position = new Vector2(10,this.game.GraphicsDevice.DisplayMode.Height/2);
			thickness = 20;
			size = 160;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(pixelTexture, new Vector2(position.X - thickness/2, position.Y - size/2),
				new Rectangle(0, 0, thickness, size), Color.White);
		}

		private readonly Texture2D pixelTexture;
		private Vector2 position;
		private int thickness;
		private int size;
	}
}
