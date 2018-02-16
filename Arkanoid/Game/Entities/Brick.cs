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
    class Brick : Entity
    {
        Texture2D brickTexture;
        UInt32 type;

        public Brick(int x, int y, UInt32 type)
        {
            this.tag = "Brick";
            this.name = "Brick";
            position = new Vector2(x, y);
            size = new Vector2(40, 20);
            this.type = type;
        }

        public override void Initialize()
        {
            AddCollider(new VectorCollider(new Vector2(0, 0),new Vector2(size.X, 0)));
            AddCollider(new VectorCollider(new Vector2(0, size.Y), new Vector2(0, 0)));
            AddCollider(new VectorCollider(new Vector2(size.X, size.Y), new Vector2(0,size.Y)));
            AddCollider(new VectorCollider(new Vector2(size.X, 0), new Vector2(size.X, size.Y)));
        }

        public override void LoadContent()
        {
            brickTexture = Content.Load<Texture2D>(Assets.brick[type]);
        }

        public override void Update(GameTime gameTime)
        {
        
        }

        public override void Draw(GameTime gameTime, SpriteBatch SB)
        {
            SB.DrawSprite(brickTexture, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), Color.White);
        }

        public override void OnCollisionEnter(Collider local, Collider other, Vector2 intersecPoint)
        {
            if (other.Owner.name == "Ball")
                destroy = true;
        }
    }
}
