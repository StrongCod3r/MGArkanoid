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
using Engine2D.Geometry;
using Arkanoid;
using Arkanoid.Entities;


namespace Arkanoid.Scenes
{
    class StartScene : Scene
    {
        Texture2D backgrounTexture;
        public Vector2 position;


        public StartScene()
        {
            position = Vector2.Zero;
        }

        public override void Initialize()
        {
            var paddle = new Paddle(480, Game.SCREEN_HEIGHT - 80);
            var ball = new Ball(300, 300, paddle);
            paddle.AppendBall(ball);

            EntityManager.Add(paddle);
            EntityManager.Add(ball);

            var brickFactory = new BrickFactory(this, Assets.Level[0], new Point(130, 50));
            brickFactory.LoadLevel();

            base.Initialize();
        }

        public override void LoadContent()
        {
            backgrounTexture = Content.Load<Texture2D>(Assets.background[1]);

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
            SB.DrawSprite(backgrounTexture, new Rectangle(0, 0, Game.SCREEN_WIDTH, Game.SCREEN_HEIGHT), Color.White);

            //-------------------------------------
            SB.End();

            base.Draw(gameTime);
        }
    }
}
