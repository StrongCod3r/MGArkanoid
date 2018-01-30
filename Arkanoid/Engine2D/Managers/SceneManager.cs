using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Engine2D.Managers
{
    public class SceneManager
    {
		public ContentManager Content { get { return Engine.Content; } }
        private SpriteBatch SB;
        private List<Scene> scenes;
        private Scene currentScene;
        private E2D Engine;


        public SceneManager(E2D engine)
        {
            Engine = engine;
            scenes = new List<Scene>();
        }

        public void LoadScene(Scene scene, bool start)
        {
            if (scene != null)
            {
                if (currentScene != null)
                {
                    scenes.Remove(currentScene);
                }

                scene.Game = Engine;
                scenes.Add(scene);
                currentScene = scene;
            }
        }

        public bool RemoveScene(Scene scene)
        {
            scene.UnloadContent();
            return scenes.Remove(scene);
        }

        public void Initialize()
        {
            
            //if (currentScene != null)
            //{
            //    if (!currentScene.Loaded)
            //        currentScene.Initialize();

            //    currentScene.Initialize();
            //}
            //base.Initialize();
        }


        public void LoadContent()
        {
            SB = new SpriteBatch(Engine.GraphicsDevice);

            //if (currentScene != null)
            //    currentScene.LoadContent();

            //base.LoadContent();
        }

        protected void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            currentScene.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Engine.Exit();


            if (currentScene != null)
            {
                if (!currentScene.Loaded)
                    currentScene.Initialize();

                currentScene.Update(gameTime);
            }

            //base.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            if (currentScene != null)
            {
                if (!currentScene.Loaded)
                    currentScene.Initialize();
            }

            SB.Begin();
            //-------------------------------------
            if (currentScene != null)
            {
                currentScene.Draw(gameTime);
            }
                
            //-------------------------------------
            SB.End();


        }
    }
}