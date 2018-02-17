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
        private Vector2 start;
        private Vector2 end;
        //private Vector2 vector;


        public Vector2 Start
        {
            get
            {
                return (Owner.position + start);
            }
        }

        public Vector2 End
        {
            get
            {
                return (Owner.position + end);
            }
        }

        public Vector2 Vector
        {
            get
            {
                return End - Start;
            }
        }

        public Vector2 Normal
        {
            get
            {
                return new Vector2(Vector.X, Vector.Y);
            }
        }
        
        /// <summary>
        /// Creates a line collider defined between 2 points given with respect to the owner object position
        /// </summary>
        /// <param name="relativeStart"> initial point of the vector relative to the Owner position </param>
        /// <param name="relativeEnd"> final point of the vector relative to the Owner position</param>
        public VectorCollider(Vector2 relativeStart, Vector2 relativeEnd)
        {
            start = new Vector2(relativeStart.X, relativeStart.Y);
            end = new Vector2(relativeEnd.X, relativeEnd.Y);
            //normal = Vector2.Normalize(new Vector2(Vector.Y, -Vector.X));
            this.type = TypeCollider.Vector;
            initialized = false;
        }

        //public override void Intialize()
        //{
        //    start = Owner.position + start;
        //    end = Owner.position + end;
        //    vector = end - start;
        //    normal = new Vector2(vector.Y, -vector.X);
        //    initialized = true;
        //}

        public override void Draw(GameTime gameTime, SpriteBatch SB) 
        {
            SB.DrawLine(Start, End, Color.Red,2);
            SB.DrawLine(Start + 0.5f * Vector, Start + 0.5f * Vector + Normal, Color.Green, 2);
        }
    }
}
