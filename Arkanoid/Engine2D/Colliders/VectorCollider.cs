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
        public Vector2 Start;
        public Vector2 End;
        public Vector2 vector;

        /// <summary>
        /// Creates a line collider defined between 2 points given with respect to the owner object position
        /// </summary>
        /// <param name="relativeStart"> initial point of the vector relative to the Owner position </param>
        /// <param name="relativeEnd"> final point of the vector relative to the Owner position</param>
        public VectorCollider(Vector2 relativeStart, Vector2 relativeEnd)
        {
            Start = new Vector2(Owner.position.X + relativeStart.X, Owner.position.Y + relativeStart.Y);
            End = new Vector2(Owner.position.X + relativeEnd.X, Owner.position.Y + relativeEnd.Y);
            vector = End - Start;
        }

        public override void Initialize() { }

        public override void Draw(GameTime gameTime, SpriteBatch SB) 
        {
            SB.DrawLine(Start, End, Color.Red);
        }
    }
}
