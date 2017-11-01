using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Engine2D;
using Arkanoid.Entities;

namespace Arkanoid.Entities
{
    class Ball : CharacterBase
    {
        Texture2D ballTexture;
        private bool isPaddleCollide;
        private bool caught;
        private float radius;
        private Vector2 direction;
        private float acceleration = 5;
        private float speed = 600;

        Paddle paddle;

        public Ball(int x, int y, Paddle paddle)
        {
            this.paddle = paddle;
            position = new Vector2(x, y);
            size = new Vector2(20, 20);
            caught = false;
            direction = new Vector2(1, 1);
            radius = 5;  
        }

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            ballTexture = Content.Load<Texture2D>(Assets.ball[0]);
        }

        public override void Update(GameTime gameTime)
        {
            // Capturada
            if (!caught)
            {
                position += (direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds);

                if (IsPaddleCollide())
                {
                    direction.Y *= -1;
                }
                else
                {
                    if (IsCollideX()) direction.X *= -1;
                    if (IsCollideY()) direction.Y *= -1;
                }
                //notifyObserver();
            }

        }

        public override void Draw(GameTime gameTime)
        {
            if (!ballTexture.Equals(null))
                SB.Draw(ballTexture, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), Color.White);

        }


        #region METHODS

        public void Throw(Vector2 direction, float acceleration)
        {
            // direccion normalizada
            direction.X = direction.X / (float)Math.Sqrt(Math.Pow(direction.X, 2) + Math.Pow(direction.Y, 2));
            direction.Y = direction.Y / (float)Math.Sqrt(Math.Pow(direction.X, 2) + Math.Pow(direction.Y, 2));
            caught = false; 
        }



        bool IsCollideX()
        {
            if(this.position.X + 2 * this.radius >= Game.SCREEN_WIDTH ||
               this.position.X <= 0)
            {
                return true;
            }
            return false;
        }

        bool IsPaddleCollide()
        {
            if(position.Y + 2 * this.radius >= paddle.position.Y &&
               this.position.Y + 2 * this.radius <=
                   paddle.position.Y + paddle.size.Y &&
               this.position.X + 2 * this.radius >= paddle.position.X &&
               this.position.X + 2 * this.radius <=
                   paddle.position.X + paddle.size.X)
                return true;

            return false;
        }

        void reverseDirection()
        {
            direction.Y *= -1;
        }

        bool IsCollideY()
        {
            if(this.position.Y + 2 * this.radius >= Game.SCREEN_HEIGHT ||
               this.position.Y <= 0) {
                return true;
            }
            return false;
        }

        public void Capture(Vector2 pos)
        {
            caught = true;
            SetPos(pos.X, pos.Y);
        }


        //public void notifyObserver();
        //public void addObserver(CollisionObserverPtr observer);



        private void LoseBall()
        {

        }

        private void SetPos(float x, float y)
        {
            position.X = x;
            position.Y = y;
        }

        #endregion 



    }
}
