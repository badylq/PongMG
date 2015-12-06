using System;
using System.Collections.Generic;
using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		public static SpriteBatch spriteBatch;
		public List<Player> Players;
		private Ball ball;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			graphics.PreferredBackBufferHeight = 768;
			graphics.PreferredBackBufferWidth = 1366;
			graphics.IsFullScreen = true;
			graphics.ApplyChanges();

			Players = new List<Player>(2);
			Player player = new Player(this);
			player.SetThickness(20);
			player.SetSize(250);
			player.SetPosition(OnScreenPosition.Left, OnScreenPosition.Center);
			player.SetPlayerNumber(1);
			player.SetInput(Keys.W, Keys.S, Keys.Space);
			Players.Add(player);
			
			player = new Player(this);
			player.SetThickness(20);
			player.SetSize(250);
			player.SetPosition(OnScreenPosition.Right, OnScreenPosition.Center);
			player.SetPlayerNumber(2);
			player.SetInput(Keys.Up,Keys.Down, Keys.LeftShift);
			Players.Add(player);

			ball = new Ball(this);
			ball.SetSize(20);
			ball.SetSpeed(600);
			ball.SetPosition(OnScreenPosition.Left, Players[0].Id);

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			if(!ball.IsBallMoving() && Keyboard.GetState().IsKeyDown(Keys.Space))
				ball.StartMoving();

			for (int i = 0; i < Players.Count; i++)
			{
				Players[i].Update(gameTime);
			}
			
			ball.Update(gameTime);

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			spriteBatch.Begin();
			foreach (var player in Players)
			{
				player.Draw(gameTime);
			}
			ball.Draw(gameTime);
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
