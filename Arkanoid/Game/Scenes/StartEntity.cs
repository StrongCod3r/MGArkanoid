using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Engine2D;


namespace Arkanoid.Scenes
{
    class StartEntity : Scene
    {
        public StartEntity(E2D engine): base(engine)
        {

        }

        public override void Initialize()
        {
            Game.Window.Title = "Arkanoid";
            AddEntity(new Paddle(new Vector2(200, 400), "Sprites/paddleRed"));
            AddEntity(new Paddle(new Vector2(200, 450), "Sprites/paddleBlu"));
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                Engine.SceneManager.LoadScene(new StartScene(Engine), true);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
