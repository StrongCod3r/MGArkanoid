using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Engine2D.Managers;
using Engine2D.Geometry;
using Engine2D.Utils;


namespace Engine2D
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class E2D : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphicsDeviceManager;
        private SpriteBatch spriteBatch;
        public SceneManager SceneManager;
        private Point screen;
        private bool debug = false;
        float timeCount = 0f;

        public int SCREEN_WIDTH{get { return screen.X; }}
        public int SCREEN_HEIGHT{ get { return screen.Y; } }
        public bool Debug { get { return debug; } set { debug = value; } }

        //Performance
        internal static bool needToDraw;
        private int lastMilliseconds;
        private int elapsedMilliseconds;
        internal static int fps = 30;
        private int frameDuration = (int)(1000f / fps);
        private int last;
        private int elapsed;
        private int oversleep;

        internal static int frameCount;

        float timer;
        int timecounter;

        public E2D(String name, int width, int height, bool fullScreen = false)
        {
            screen = new Point(width, height);

            graphicsDeviceManager = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = width,
                PreferredBackBufferHeight = height,
                IsFullScreen = fullScreen,
                SynchronizeWithVerticalRetrace = false,
                PreferredDepthStencilFormat = DepthFormat.Depth16
            };

            //// Frame rate is 30 frameDuration by default for Windows Phone.
            //IsFixedTimeStep = false;
            //TargetElapsedTime = TimeSpan.FromMilliseconds(1000f / fps);
            //frameCount = 0;

            //// Extend battery life under lock.
            //InactiveSleepTime = TimeSpan.FromMilliseconds(1000);

            //IsFixedTimeStep = false;
            ////TargetElapsedTime = TimeSpan.FromMilliseconds(15);

            Window.Title = name;
            Content.RootDirectory = "Content";

            Primitives2D.GameEngine = this;
            SceneManager = new SceneManager(this);
            //SceneManager = new SceneManager(this);
            //Components.Add(SceneManager);

            graphicsDeviceManager.ApplyChanges();

        }

        public void ChangeResolution(int width, int height)
        {
            graphicsDeviceManager.PreferredBackBufferWidth = width;
            graphicsDeviceManager.PreferredBackBufferHeight = height;
            graphicsDeviceManager.ApplyChanges();
        }

        public void SetTitle(string title)
        {
            this.Window.Title = title;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Center Window
            Window.Position = new Point((GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - (graphicsDeviceManager.PreferredBackBufferWidth / 2),
                            (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - (graphicsDeviceManager.PreferredBackBufferHeight / 2));


            //IsFixedTimeStep = true;
            //graphicsDevice.SynchronizeWithVerticalRetrace = true;
            //graphicsDevice.ApplyChanges();

            //////FrameRate is 30fps
            //TargetElapsedTime = TimeSpan.FromTicks(333333);


            SceneManager.Initialize();
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
#if DEBUG
            var debugFont = Content.Load<SpriteFont>("Fonts/debugFont");

            var fpsCounter = new FpsCounter(this, debugFont, new Vector2(5, 5));
            Components.Add(fpsCounter);
#endif
            SceneManager.LoadContent();
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


            // ModeDebug
            if (Keyboard.GetState().IsKeyDown(Keys.F12) && timeCount > 0.3)
            {
                Debug = !Debug;
                timeCount = 0;
            }
            else if (timeCount <= 0.3f)
            {
                timeCount += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timecounter += (int)timer;
            if (timer >= 0.016F)
            {
                SceneManager.Update(gameTime);
                timer = 0F;
            }

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
            SceneManager.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}


