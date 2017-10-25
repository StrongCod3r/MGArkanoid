using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Engine2D
{
    public class SceneManager : DrawableGameComponent
    {
		public ContentManager Content { get { return Game.Content; } }
        private SpriteBatch spriteBatch;
        //private List<Scene> scenes;
        private Scene currentScene;
        private E2D Engine;

        public SceneManager(E2D engine) : base(engine)
        {
            Engine = engine;
            //scenes = new List<Scene>();
        }

        public void LoadScene(Scene scene, bool start)
        {
            if (scene != null)
            {
                if (currentScene != null)
                {
                    //scenes.Remove(currentScene);
                    Game.Components.Remove(currentScene);
                }

                //scenes.Add(scene);
                currentScene = scene;
                Game.Components.Add(scene);
            }
        }

        public bool RemoveScene(Scene scene)
        {
            return Game.Components.Remove(scene);
        }

        public override void Initialize()
        {
            // Center Window
            Game.Window.Position = new Point((GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - (Engine.graphicsDevice.PreferredBackBufferWidth / 2),
                            (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - (Engine.graphicsDevice.PreferredBackBufferHeight / 2));

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Engine.GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Game.Exit();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}