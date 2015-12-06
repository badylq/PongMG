using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pong
{
	public class Entity : DrawableGameComponent
	{
		public int Id;
		public EntityType Type;
		public Collider Collider;
		protected Game game;

		public Entity(Game game) : base(game)
		{
			this.DrawOrder = 1;
			this.game = game;
			this.Type = EntityType.Default;
		}

		public void SetDrawOrder(int drawOrder)
		{
			this.DrawOrder = drawOrder;
		}

		public void SetVisibility(bool visible)
		{
			this.Visible = visible;
		}

		public virtual Rectangle GetLocalBounds()
		{
			return new Rectangle(0,0,0,0);
		}
	}

	public enum EntityType
	{
		Player,
		Edge,
		Ball,
		Default
	}
}
