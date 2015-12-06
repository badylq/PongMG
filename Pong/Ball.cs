using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
	class Ball : Entity
	{
		private readonly Texture2D pixelTexture;
		private Vector2 position;
		private int size;
		private float speed;
		private Direction verticalDirection;
		private Direction horizntalDirection;
		private bool isMoving;
		private int playerId;

		public Ball(Game game) : base(game)
		{
			Entities.Instance.AddEntity(this);
			pixelTexture = new Texture2D(game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
			pixelTexture.SetData(new[] { Color.White });
			position = new Vector2(0, 0);
			playerId = 1;
			size = 1;
			speed = 100;
			Type = EntityType.Ball;
			verticalDirection = Direction.Down;
			horizntalDirection = Direction.Right;
			isMoving = false;
			Collider = new Collider(GetLocalBounds());
		}

		public override void Draw(GameTime gameTime)
		{
			Game1.spriteBatch.Draw(pixelTexture, GetLocation(), GetBoundingBox(), Color.White);

			base.Draw(gameTime);
		}

		public override void Update(GameTime gameTime)
		{
			if (isMoving)
			{
				Vector2 moveVector = new Vector2(0, 0);
				if (horizntalDirection == Direction.Right)
				{
					moveVector.X = (float) (speed*gameTime.ElapsedGameTime.TotalSeconds);
				}
				else
				{
					moveVector.X = -(float) (speed*gameTime.ElapsedGameTime.TotalSeconds);
				}
				if (verticalDirection == Direction.Up)
				{
					moveVector.Y = -(float) (speed*gameTime.ElapsedGameTime.TotalSeconds);
				}
				else
				{
					moveVector.Y = (float) (speed*gameTime.ElapsedGameTime.TotalSeconds);
				}
				Move(moveVector);

				if (verticalDirection == Direction.Up && position.Y < size/2)
				{
					verticalDirection = Direction.Down;
				}
				else
				{
					if (verticalDirection == Direction.Down && position.Y > game.Window.ClientBounds.Bottom - size/2)
					{
						verticalDirection = Direction.Up;
					}
				}

				foreach (var player in Entities.Instance.GetEntitiesOfType(EntityType.Player))
				{
					Collider.CheckCollision(player.Collider);
				}
			}
			else
			{
				Player player = Entities.Instance.GetEntityById(playerId) as Player;
				position.Y = player.GetLocalBounds().Center.Y;
				//Console.WriteLine("Y:{0}", playerBounds.Center.Y);
			}
			base.Update(gameTime);
		}

		public void SetColor(Color color)
		{
			pixelTexture.SetData(new[] { color });
		}

		public void SetPosition(Vector2 newPosition)
		{
			position = newPosition;
			Collider.Update(GetLocalBounds());
		}

		public void SetPosition(OnScreenPosition side, int playerId)
		{
			Player player = Entities.Instance.GetEntityById(playerId) as Player;
			Rectangle playerBounds = player.GetLocalBounds();
			if (side == OnScreenPosition.Left)
			{
				position.X = size / 2 + playerBounds.Width;
				horizntalDirection = Direction.Right;
			}
			else
			{
				position.X = game.Window.ClientBounds.Width - size / 2 - playerBounds.Width;
				horizntalDirection = Direction.Left;
			}
			position.Y = playerBounds.Center.Y;
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
			return new Vector2(position.X - size / 2, position.Y - size / 2);
		}

		public Rectangle GetBoundingBox()
		{
			return new Rectangle(0, 0, size, size);
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
			size = (int)(size * (1.0f + 1.0f / procentage));
			Collider.Update(GetLocalBounds());
		}

		public Rectangle GetLocalBounds()
		{
			return new Rectangle((int)GetLocation().X, (int)GetLocation().Y, size, size);
		}

		public void SetSpeed(int speed)
		{
			this.speed = speed;
		}

		public void StartMoving()
		{
			isMoving = true;
		}

		public bool IsBallMoving()
		{
			return isMoving;
		}
	}
}
