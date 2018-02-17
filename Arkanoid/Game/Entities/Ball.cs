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
using Engine2D.Colliders;
using Engine2D.Geometry;
using Arkanoid.Entities;

namespace Arkanoid.Entities
{
    class Ball : Entity
    {
        Texture2D ballTexture;
        private bool caught;
        private float radius;


        private bool isPaddleCollide;
        private Vector2 normalCollide;
        int currentCollisions = 0;
        int iterations = 0;
        Paddle paddle;
        int fpsCount = 0;
        Vector2 intersectionTest;
        VectorCollider prove;

        public Ball(int x, int y, Paddle paddle)
        {
            this.paddle = paddle;
            position = new Vector2(x, y);
            size = new Vector2(20, 20);
            caught = false;
            direction = new Vector2(0.7071067812f, 0.7071067812f);
            speed = 100;
            radius = 5;
            pasive = false;
        }

        public override void Initialize()
        {
            this.name = "Ball";
            AddCollider(new CircleCollider() { /*Radius = 50*/});
            //AddCollider(new VectorCollider(new Vector2(0,10), new Vector2(20, 20)));
            //AddCollider(new RectCollider());
            //AddCollider(new VectorCollider(1, 1));
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

                if (isPaddleCollide)
                {
                    Vector2 refDirection;
                    refDirection = this.direction - 2 * Vector2.Dot(this.direction, this.normalCollide) * this.normalCollide;
                    refDirection.Normalize();
                    this.direction = refDirection;
                    this.isPaddleCollide = false;
                    Game.Window.Title = "" + this.direction.X + "," + this.direction.Y;
                }
                else
                {
                    if (IsCollideX()) direction.X *= -1;
                    if (IsCollideY()) direction.Y *= -1;
                }
                
            }

        }

        public override void Draw(GameTime gameTime, SpriteBatch SB)
        {
            if (!ballTexture.Equals(null))
                SB.DrawSprite(ballTexture, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), Color.White);
            if (intersectionTest.X != 0 || intersectionTest.Y != 0)
            {
                SB.DrawCircle(intersectionTest, 3, 20, Color.Red, 5);
                intersectionTest = Vector2.Zero;
                SB.DrawLine(prove.Start, prove.End, Color.Yellow, 4);
                prove = null;
            }

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
            if (this.position.X + 2 * this.radius >= Game.SCREEN_WIDTH || this.position.X <= 0)
                return true;

            return false;
        }

        //bool IsPaddleCollide()
        //{
        //    if(position.Y + 2 * this.radius >= paddle.position.Y &&
        //       this.position.Y + 2 * this.radius <=
        //           paddle.position.Y + paddle.size.Y &&
        //       this.position.X + 2 * this.radius >= paddle.position.X &&
        //       this.position.X + 2 * this.radius <=
        //           paddle.position.X + paddle.size.X)
        //        return true;

        //    return false;
        //}

        void reverseDirection()
        {
            direction.Y *= -1;
        }

        bool IsCollideY()
        {
            if (this.position.Y + 2 * this.radius >= Game.SCREEN_HEIGHT || this.position.Y <= 0)
                return true;

            return false;
        }

        public void Capture(Vector2 pos)
        {
            caught = true;
            SetPos(pos.X, pos.Y);
        }

        private void LoseBall()
        {

        }

        private void SetPos(float x, float y)
        {
            position.X = x;
            position.Y = y;
        }

        public override void OnCollisionEnter(Collider local, Collider other,Vector2 intersecPoint)
        {
            //isPaddleCollide |= other.Owner.name.Equals("Paddle");

            this.normalCollide = other.normal;

            if (other.Owner.tag.Equals("Player") || local.Owner.tag.Equals("Player"))
                Game.Window.Title = "BALL ==> PADDLE";
            intersectionTest = intersecPoint;
            prove = (VectorCollider)other;
        }

        #endregion 




    }
}
