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
    class StartScene : Scene
    {
        Texture2D backgrounTexture;
        public Vector2 position;


        public StartScene(E2D engine) : base(engine)
        {
            
        }

        public override void Initialize()
        {
            var paddle = new Paddle(480, Engine.GraphicsDevice.Viewport.Height - 100);
            AddEntity(paddle);
            AddEntity(new Ball(300, 300, paddle));
            position = Vector2.Zero;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            backgrounTexture = Content.Load<Texture2D>("Sprites/background2");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                position.X -= 5;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                position.X += 5;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //-------------------------------------
            spriteBatch.Draw(backgrounTexture, new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height), Color.White);


            //-------------------------------------
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
