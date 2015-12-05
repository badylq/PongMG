using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
	class Entities
	{
		protected Entities()
		{
			currentId = 0;
			entities = new List<Entity>();
		}

		public static Entities Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Entities();
				}
				return _instance;
			}
		}

		public void AddEntity(Entity entity)
		{
			entity.Id = currentId;
			entities.Add(entity);
			currentId++;
		}

		public Entity GetEntityById(int id)
		{
			foreach (var entity in entities)
			{
				if(entity.Id == id)
					return entity;
			}
			return null;
		}

		public void RemoveEntity(int id)
		{
			entities.Remove(GetEntityById(id));
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (var entity in entities)
			{
				//entity.Draw();
			}
		}

		private static Entities _instance = null;
		private int currentId;
		private List<Entity> entities;
	}
}
