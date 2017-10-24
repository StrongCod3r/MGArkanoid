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
        public ContentManager Content { get => Game.Content; }
        private SpriteBatch spriteBatch;
        private List<Scene> scenes;
        private Scene currentScene;
        private E2D Engine;

        public SceneManager(E2D engine) : base(engine.game)
        {
            Engine = engine;
            Game.Window.Title = "holaa";
            scenes = new List<Scene>();
        }

        public void AddScene(Scene scene, bool start)
        {
            if (scene != null)
            {
                //scene.Game = Game;
                //scenes.Add(scene);
                Game.Components.Add(scene);

                if (start)
                {
                    currentScene = scene;

                }
            }
        }

        public override void Initialize()
        {
            //Game.Window.Position = new Point((GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - (graphics.PreferredBackBufferWidth / 2),
            //                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - (Game.graphics.PreferredBackBufferHeight / 2));

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Engine.game.GraphicsDevice);

            //if (currentScene != null)
            //{
            //    currentScene.LoadContent();
            //}
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Game.Exit();

            //if (currentScene != null)
            //{
            //    currentScene.Update(gameTime);

            //}

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (currentScene != null)
            {
                spriteBatch.Begin();

                currentScene.Draw(spriteBatch);

                spriteBatch.End();

            }

            base.Draw(gameTime);
        }
    }
}