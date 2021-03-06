﻿using System;
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
        List<Ball> currentBalls = new List<Ball>();
        private Random randomGen = new Random();
        private KeyboardState keyState;
        private KeyboardState lastKeyState;
        float gain = 200.0f;

        public Paddle(int x, int y)
        {
            this.tag = "Player";
            this.name = "Paddle";
            position.X = x;
            position.Y = y;
            size = new Vector2(200, 90);
            speed = 350;

            //position.X = x-200;
            //position.Y = y - 400;
            //size.X = (int)4.0f * gain;
            //size.Y = (int)2.25f * gain;
            //speed = 350;
            //pasive = false;
        }

        public override void Initialize()
        {
            //float scale = this.gain*4f;


            //AddCollider(new VectorCollider(new Vector2(0.13f * scale, 0.36f * scale), new Vector2(0.13f * scale, 0.32f * scale)));
            //AddCollider(new VectorCollider(new Vector2(0.13f * scale, 0.32f * scale), new Vector2(0.232f * scale, 0.255f * scale)));
            //AddCollider(new VectorCollider(new Vector2(0.232f * scale, 0.255f * scale), new Vector2(0.275f * scale, 0.255f * scale)));
            //AddCollider(new VectorCollider(new Vector2(0.275f * scale, 0.255f * scale), new Vector2(0.275f * scale, 0.275f * scale)));
            //AddCollider(new VectorCollider(new Vector2(0.275f * scale, 0.275f * scale), new Vector2(0.30f * scale, 0.290f * scale)));
            //AddCollider(new VectorCollider(new Vector2(0.30f * scale, 0.290f * scale), new Vector2(0.317f * scale, 0.293f * scale)));
            //AddCollider(new VectorCollider(new Vector2(0.317f * scale, 0.293f * scale), new Vector2(0.332f * scale, 0.313f * scale)));
            //AddCollider(new VectorCollider(new Vector2(0.332f * scale, 0.313f * scale), new Vector2(0.35f * scale, 0.323f * scale)));

            //AddCollider(new VectorCollider(new Vector2(0.35f * scale, 0.323f * scale), new Vector2(0.654f * scale, 0.323f * scale)));

            //AddCollider(new VectorCollider(new Vector2(0.65f * scale, 0.323f * scale), new Vector2(0.668f * scale, 0.313f * scale)));
            //AddCollider(new VectorCollider(new Vector2(0.668f * scale, 0.313f * scale), new Vector2(0.683f * scale, 0.293f * scale)));
            //AddCollider(new VectorCollider(new Vector2(0.683f * scale, 0.293f * scale), new Vector2(0.70f * scale, 0.290f * scale)));
            //AddCollider(new VectorCollider(new Vector2(0.70f * scale, 0.290f * scale), new Vector2(0.725f * scale, 0.275f * scale)));
            //AddCollider(new VectorCollider(new Vector2(0.725f * scale, 0.275f * scale), new Vector2(0.725f * scale, 0.255f * scale)));
            //AddCollider(new VectorCollider(new Vector2(0.725f * scale, 0.255f * scale), new Vector2(0.768f * scale, 0.255f * scale)));
            //AddCollider(new VectorCollider(new Vector2(0.768f * scale, 0.255f * scale), new Vector2(0.87f * scale, 0.32f * scale)));
            //AddCollider(new VectorCollider(new Vector2(0.87f * scale, 0.32f * scale), new Vector2(0.87f * scale, 0.36f * scale)));

            AddCollider(new CircleCollider() { X = -50, Y = 15, Radius = 20});
            AddCollider(new RectCollider() {X = 50, Y = 40, Widht = 100, Height = 40 });
            AddCollider(new CircleCollider() { X = 50, Y = 15, Radius = 20 });
        }

        public override void LoadContent()
        {
            paddleSprite = Content.Load<Texture2D>(Assets.paddle[0]);
        }

        public override void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();

            //using the directions is gonna be useful for collitions 
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && position.X > 0)
            {
                direction = new Vector2(-1, 0);
                position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && (position.X + size.X < Game.SCREEN_WIDTH))
            {
                direction = new Vector2(1, 0);
                position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right))
                direction = Vector2.Zero;


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
