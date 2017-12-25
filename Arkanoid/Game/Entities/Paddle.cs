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
using Engine2D.Colliders;
using Arkanoid.Entities;


namespace Arkanoid.Entities
{
    class Paddle : Entity
    {
        Texture2D paddleSprite;
        float speed;
        List<Ball> currentBalls = new List<Ball>();
        private Random randomGen = new Random();
        private KeyboardState keyState;
        private KeyboardState lastKeyState;

        public Paddle(int x, int y)
        {
            this.tag = "Player";
            this.name = "Paddle";

            position.X = x;
            position.Y = y;
            size.X = 200;
            size.Y = 80;
        }

        public override void Initialize()
        {
            AddCollider(new RectCollider() { X = 50, Y = 41, Widht = 95, Height = 24 });
            AddCollider(new CircleCollider() { Radius = 12, X = -50, Y = 13 });
            AddCollider(new CircleCollider() { Radius = 12, X = 50, Y = 13 });
        }

        public override void LoadContent()
        {
            paddleSprite = Content.Load<Texture2D>(Assets.paddle[0]);
        }

        public override void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && position.X > 0)
                position.X -= 10;

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && (position.X + size.X < Game.SCREEN_WIDTH))
                position.X += 10;

            
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                ConectBall(); 

            if (Keyboard.GetState().IsKeyUp(Keys.Space) && lastKeyState.IsKeyDown(Keys.Space))
                currentBalls[0].direction.X = (float)(randomGen.NextDouble()-0.5);


            lastKeyState = keyState;
        }

        public override void Draw(GameTime gameTime, SpriteBatch SB)
        {
            SB.DrawSprite(paddleSprite, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), Color.White);
        }


        //eigenmethods (reference xD)
        public void AppendBall(Ball ball)
        {
            currentBalls.Add(ball);
        }


        //unfinished, by now it works independently of the position of the ball, and just for 1 on screen, and teleport the ball
        private void ConectBall()
        {
            currentBalls[0].direction = new Vector2(1, -1);
            currentBalls[0].position.X = this.position.X + this.size.X /2 - currentBalls[0].size.X;
            currentBalls[0].position.Y = this.position.Y - 50;
        }
    }
}
