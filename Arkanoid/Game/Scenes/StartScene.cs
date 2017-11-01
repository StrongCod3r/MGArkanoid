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


        public StartScene()
        {
            
        }

        public override void Initialize()
        {
            var paddle = new Paddle(480, Game.SCREEN_HEIGHT - 55);
            AddEntity(paddle);
            AddEntity(new Ball(300, 300, paddle));
            position = Vector2.Zero;

            base.Initialize();
        }

        public override void LoadContent()
        {
            backgrounTexture = Content.Load<Texture2D>("Sprites/background2");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SB.Begin();
            //-------------------------------------
            SB.Draw(backgrounTexture, new Rectangle(0, 0, Game.SCREEN_WIDTH, Game.SCREEN_HEIGHT), Color.White);

            Primitives2D.PutPixel(SB, new Vector2(300, 300), Color.Red);

            //-------------------------------------
            SB.End();

            base.Draw(gameTime);
        }
    }
}
