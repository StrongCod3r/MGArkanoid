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

namespace Arkanoid
{
    class Paddle : CharacterBase
    {
        Texture2D paddleSprite;
        float speed;


        public Paddle(int x, int y)
        {
            position = new Vector2(x, y);
            size = new Vector2(120, 30);
        }

        public override void Initialize()
        {
            
        }

        public override void LoadContent()
        {
            paddleSprite = Content.Load<Texture2D>("Sprites/paddleGato");
            
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                position.X -= 5;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                position.X += 5;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (paddleSprite != null)
                spriteBatch.Draw(paddleSprite, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), Color.White);
        }
    }
}
