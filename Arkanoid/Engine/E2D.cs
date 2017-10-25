using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Arkanoid.Scenes;


namespace Engine2D
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class E2D : Game
    {
        public GraphicsDeviceManager graphicsDevice;
        SpriteBatch spriteBatch;
        public SceneManager SceneManager;
        public Game game;

        public E2D(String name, int with, int height, bool fullScreen = false)
        {
            graphicsDevice = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = with,
                PreferredBackBufferHeight = height,
                IsFullScreen = fullScreen
            };

            Content.RootDirectory = "Content";

            SceneManager = new SceneManager(this);
            Components.Add(SceneManager);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}





//namespace Engine2D
//{
//    /// <summary>
//    /// This is the main type for your game.
//    /// </summary>
//    public class E2D
//    {
//        public Game game;
//        public GraphicsDeviceManager graphicsDevice;
//        public SceneManager SceneManager;

//        public E2D(String name, int with, int height, bool fullScreen = false)
//        {
//            game = new Game();
//            game.Content.RootDirectory = "Content";
//            graphicsDevice = new GraphicsDeviceManager(game);
//            graphicsDevice.PreferredBackBufferWidth = with;
//            graphicsDevice.PreferredBackBufferHeight = height;
//            graphicsDevice.IsFullScreen = fullScreen;
//            graphicsDevice.ApplyChanges();
//            SceneManager = new SceneManager(this);
//            game.Components.Add(SceneManager);
//        }

//        public void Run()
//        {
//            game.Run();
//        }
//    }
//}
