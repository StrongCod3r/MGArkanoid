using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine2D;
using Engine2D.Colliders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Timers;

namespace Engine2D.Managers
{
    class ColliderManager : Manager
    {
        private Scene scene;
        private List<Collider> colliders;
        double elapsedTime = 0f;

        public ColliderManager(Scene scene)
        {
            this.scene = scene ?? throw new ArgumentNullException(nameof(scene));
        }

        public override void Initialize()
        {
            GetColliders();
            this.initialized = true;
        }



        public override void Update(GameTime gameTime)
        {
            //elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;

            //if (elapsedTime >= 10)
            //{
                elapsedTime = 0;
            //=====
            Vector2 intersecPoint;
                for (int i = 0; i < colliders.Count; i++)
                {
                    //we do not check collisions of not moving entity with other not moving entity
                    if (colliders[i].Owner.sleeping)
                    {
                        continue;
                    }

                    for (int j = i + 1; j < colliders.Count; j++)
                    {
                        if (!ReferenceEquals(colliders[i].Owner, colliders[j].Owner) && colliders[i].enable && colliders[j].enable)
                        {
                            if (IsColliding(colliders[i], colliders[j],out intersecPoint))
                            {
                                colliders[i].Owner.OnCollisionEnter(colliders[i], colliders[j],intersecPoint);
                                colliders[j].Owner.OnCollisionEnter(colliders[j], colliders[i],intersecPoint);
                            }
                        }
                    }
                }
            //}

        }

        private void GetColliders()
        {
            var entities = this.scene.EntityManager.EntitiesList;
            colliders = new List<Collider>();

            foreach (var entitie in entities)
            {
                var collidersEntity = entitie.Colliders;
                if (collidersEntity != null)
                    colliders.AddRange(entitie.Colliders);
            }
        }

        #region METHODS COLLIDERS
        public bool IsColliding(Collider obj1, Collider obj2,out Vector2 intersecPoint)
        {
            intersecPoint = Vector2.Zero;
            if (obj1.Type == TypeCollider.Vector && obj2.Type == TypeCollider.Vector)
                return CheckCollision(obj1 as VectorCollider, obj2 as VectorCollider,out intersecPoint);

            else if (obj1.Type == TypeCollider.Circle && obj2.Type == TypeCollider.Circle)
                return CheckCollision(obj1 as CircleCollider, obj2 as CircleCollider);

            else if (obj1.Type == TypeCollider.Circle && obj2.Type == TypeCollider.Vector)
                return CheckCollision(obj2 as VectorCollider, obj1 as CircleCollider, out intersecPoint);
            else 
                return CheckCollision(obj1 as VectorCollider, obj2 as CircleCollider, out intersecPoint);

        }

        public bool CheckCollision(RectCollider rect1, RectCollider rect2)
        {
            return rect1.Rect.Intersects(rect2.Rect);
        }

        public bool CheckCollision(CircleCollider circle, RectCollider rect)
        {
            var closestX = MathHelper.Clamp(circle.X, rect.X, rect.X + rect.Widht);
            var closestY = MathHelper.Clamp(circle.Y, rect.Y, rect.Y + rect.Height);

            // Calculate the distance between the circle's center and this closest point
            var distanceX = circle.X - closestX;
            var distanceY = circle.Y - closestY;

            // If the distance is less than the circle's radius, an intersection occurs
            var distanceSquared = (distanceX * distanceX) + (distanceY * distanceY);
            return distanceSquared < (circle.Radius * circle.Radius);
        }

        public bool CheckCollision(CircleCollider circle1, CircleCollider circle2)
        {
            // Distance: (R1+ R2)^2 => (x2 – x1)^2 + (y2 – y1)^2

            float dx = circle2.X - circle1.X;
            float dy = circle2.Y - circle1.Y;

            Int32 radioTotal = (Int32)(circle1.Radius + circle2.Radius);

            if ((Math.Pow(dx, 2) + Math.Pow(dy, 2)) <= Math.Pow(radioTotal, 2))
                return true;

            return false;
        }

        /// <summary>
        /// Check if 2 vectors collide in space and return the point of the intersection
        /// </summary>
        /// <param name="vector1">First VectorCollider to test</param>
        /// <param name="vector2">Second VectorCollider to test</param>
        /// <param name="intersecPoint">Var to store the intersection Point</param>
        /// <returns></returns>
        public bool CheckCollision(VectorCollider vector1, VectorCollider vector2, out Vector2 intersecPoint)
        {
            float t2;

            t2 = (vector1.Vector.Y * (vector1.Start.X - vector2.Start.X) + vector1.Vector.X * (vector2.Start.Y - vector1.Start.Y)) /
                (vector2.Vector.X * vector1.Vector.Y - vector1.Start.X * vector2.Vector.Y);

            if (t2 < 0 || t2 > 1)
            {
                intersecPoint = Vector2.Zero;
                return false;
            }
            else
            {
                intersecPoint = vector2.Start + t2 * vector2.Vector;
                return true;
            }
        }
        /// <summary>
        /// Check if vector (line segment) collide with a circunference in space and return the first point of the intersection
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="circle"></param>
        /// <param name="intersecPoint"></param>
        /// <returns></returns>
        public bool CheckCollision(VectorCollider vector, CircleCollider circle, out Vector2 intersecPoint)
        {
            float a;
            float b;
            float c;
            intersecPoint = Vector2.Zero;

            a = Vector2.Dot(vector.Vector, vector.Vector);
            b = Vector2.Dot(vector.Start - circle.center, vector.Vector) * 2;
            c = Vector2.Dot(vector.Start - circle.center, vector.Start - circle.center) - circle.Radius*circle.Radius;

            double sqrtTerm = b * b - 4 * a * c;
            if (sqrtTerm < 0)
            {
                return false;
            }
            else
            {
                sqrtTerm = Math.Sqrt(sqrtTerm);

                float t1 = (float)(-b - sqrtTerm) / (2 * a);
                float t2 = (float)(-b + sqrtTerm) / (2 * a);

                //t1 has preference, but if the starting point is inside the circle t2 will be the point
                if (t1 >= 0 && t2 <= 1)
                {
                    intersecPoint = vector.Start + t1 * vector.Vector;
                    return true;
                }
                if (t2 >= 0 && t2 <= 1)
                {
                    intersecPoint = vector.Start + t2 * vector.Vector;
                    return true;
                }
                return false;
            }
            


        }
        #endregion


        public override void Draw(GameTime gameTime, SpriteBatch SB)
        {
            var entitiesList = this.scene.EntityManager.EntitiesList;
            foreach (var e in entitiesList)
            {
                var collidersList = e.Colliders;
                if (collidersList != null)
                {
                    foreach (var c in collidersList)
                    {
                        c.Draw(gameTime, SB);
                    }
                }
            }
        }

    }
}
