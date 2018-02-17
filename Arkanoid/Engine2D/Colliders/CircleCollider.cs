using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine2D;
using Engine2D.Geometry;

namespace Engine2D.Colliders
{
    class CircleCollider : Collider
    {
        private float radius;
        public Vector2 center;
        public int X { get => (int)this.Owner.position.X + x + (int)Owner.size.X / 2; set => x = value; }
        public int Y { get => (int)this.Owner.position.Y + y + (int)Owner.size.Y / 2; set => y = value; }
        public int Width { get => 2 * (int)radius; }
        public int Height { get => 2 * (int)radius; }
        public float Radius { get => radius; set => radius = value; }

        public CircleCollider()
        {
            this.type = TypeCollider.Circle;
        }

        public override void Update()
        {
            if (radius == 0)
                this.radius = (int)this.Owner.size.X / 2;
            center = new Vector2(x, y);

            initialized = true;
        }

        public override void Draw(GameTime gameTime, SpriteBatch SB)
        {
            SB.DrawCircle(new Vector2(X, Y), Radius, 20, Color.Red);
        }
    }
}
