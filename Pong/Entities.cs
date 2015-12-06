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
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].Id == id)
				{
					return entities[i];
				}
			}
			return null;
		}

		public void RemoveEntity(int id)
		{
			entities.Remove(GetEntityById(id));
		}

		public ICollection<Entity> GetEntitiesList()
		{
			return entities;
		}

		public ICollection<Entity> GetEntitiesOfType(EntityType type)
		{
			List<Entity> listOfEntities = new List<Entity>();
			foreach (var entity in entities)
			{
				if (entity.Type == type)
				{
					listOfEntities.Add(entity);
				}
			}
			if (listOfEntities.Count == 0)
			{
				return null;
			}
			else
			{
				return listOfEntities;
			}
		} 

		private static Entities _instance = null;
		private int currentId;
		private List<Entity> entities;
	}
}
