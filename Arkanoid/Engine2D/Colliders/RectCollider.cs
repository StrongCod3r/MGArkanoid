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
    class RectCollider : Collider
    {
        private Rectangle rect;
        public int X { get => (int)this.Owner.position.X + x; set => x = value; }
        public int Y { get => (int)this.Owner.position.Y + y; set => y = value; }
        public int Widht { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }


        public Rectangle Rect
        {
            get
            {
                rect.X = X;
                rect.Y = Y;
                rect.Width = Widht;
                rect.Height = Height;
                return rect;
            }
        }

        public RectCollider()
        {
            this.rect = new Rectangle();
            initialized = false;
            this.type = TypeCollider.Rectangle;
        }

        public override void Update()
        {
            if (width == 0)
                this.width = (int)this.Owner.size.X;

            if (height == 0)
                this.height = (int)this.Owner.size.Y;

            initialized = true;
        }

        public override void Draw(GameTime gameTime, SpriteBatch SB)
        {
            SB.DrawRectangle(Rect, Color.Red, 1);
        }
    }
}
