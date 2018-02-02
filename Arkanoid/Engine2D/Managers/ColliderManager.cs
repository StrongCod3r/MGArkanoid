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
                for (int i = 0; i < colliders.Count; i++)
                {
                    for (int j = i + 1; j < colliders.Count; j++)
                    {
                        if (!ReferenceEquals(colliders[i].Owner, colliders[j].Owner) && colliders[i].enable && colliders[j].enable)
                        {
                            if (IsColliding(colliders[i], colliders[j]))
                            {
                                colliders[i].Owner.OnCollisionEnter(colliders[i], colliders[j]);
                                colliders[j].Owner.OnCollisionEnter(colliders[j], colliders[i]);
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
        public bool IsColliding(Collider obj1, Collider obj2)
        {
            if (obj1.Type == TypeCollider.Rectangle && obj2.Type == TypeCollider.Rectangle)
                return CheckCollision(obj1 as RectCollider, obj2 as RectCollider);

            else if (obj1.Type == TypeCollider.Rectangle && obj2.Type == TypeCollider.Circle)
                return CheckCollision(obj2 as CircleCollider, obj1 as RectCollider);

            else if (obj1.Type == TypeCollider.Circle && obj2.Type == TypeCollider.Circle)
                return CheckCollision(obj1 as CircleCollider, obj2 as CircleCollider);
            else
                return CheckCollision(obj1 as CircleCollider, obj2 as RectCollider);
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
