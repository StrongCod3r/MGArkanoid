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
    class VectorCollider : Collider
    {
        public Vector2 start;
        public Vector2 end;
        public Vector2 vector;
        
        /// <summary>
        /// Creates a line collider defined between 2 points given with respect to the owner object position
        /// </summary>
        /// <param name="relativeStart"> initial point of the vector relative to the Owner position </param>
        /// <param name="relativeEnd"> final point of the vector relative to the Owner position</param>
        public VectorCollider(Vector2 relativeStart, Vector2 relativeEnd)
        {
            start = new Vector2(relativeStart.X, relativeStart.Y);
            end = new Vector2(relativeEnd.X, relativeEnd.Y);
            normal = Vector2.Normalize(new Vector2(vector.Y, -vector.X));
            this.type = TypeCollider.Vector;
            initialized = false;
        }

        public override void Initialize()
        {
            start = Owner.position + start;
            end = Owner.position + end;
            vector = end - start;
            normal = new Vector2(vector.Y, -vector.X);
            initialized = true;
        }

        public override void Draw(GameTime gameTime, SpriteBatch SB) 
        {
            SB.DrawLine(start, end, Color.Red,2);
            SB.DrawLine(start + 0.5f * vector,start + 0.5f * vector + normal, Color.Green, 2);
        }
    }
}
