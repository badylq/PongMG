using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pong
{
	public class Collider
	{
		private Rectangle bounds;
		public List<Collider> CollidingWith; 
		public Collider()
		{
			bounds = new Rectangle(0,0,1,1);
		}

		public Collider(Rectangle bounds)
		{
			Update(bounds);
		}

		private void Initialize()
		{
			CollidingWith = new List<Collider>();
		}

		public void Update(Rectangle bounds)
		{
			this.bounds = bounds;
			CollidingWith = new List<Collider>();
		}

		public bool CheckCollision(Collider collider)
		{
			if (this.bounds.X < collider.bounds.Right &&
			    this.bounds.Right > collider.bounds.X &&
			    this.bounds.Y < collider.bounds.Bottom &&
			    this.bounds.Bottom > collider.bounds.Y)
			{
				Console.WriteLine("Collision detected!");
				CollidingWith.Add(collider);
				return true;
			}
			return false;
		}
	}
}
