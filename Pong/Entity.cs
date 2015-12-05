using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pong
{
	class Entity : DrawableGameComponent
	{
		public int Id;
		protected Game game;

		public Entity(Game game) : base(game)
		{
			this.DrawOrder = 1;
			this.game = game;
		}

		public void SetDrawOrder(int drawOrder)
		{
			this.DrawOrder = drawOrder;
		}

		public void SetVisibility(bool visible)
		{
			this.Visible = visible;
		}
	}
}
