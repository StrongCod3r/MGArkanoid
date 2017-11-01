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
using Arkanoid.Entities;

namespace Arkanoid.Entities
{
    class Brick : CharacterBase
    {
        Texture2D brickTexture;
        UInt32 type;

        public Brick(int x, int y, UInt32 type)
        {
            position = new Vector2(x, y);
            size = new Vector2(40, 20);
            this.type = type;
        }

        public override void Initialize()
        {
            
        }

        public override void LoadContent()
        {
            brickTexture = Content.Load<Texture2D>(Assets.brick[type]);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            SB.Draw(brickTexture, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), Color.White);
        }
    }
}
