using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine2D;
using Engine2D.Colliders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Engine2D.Managers
{
    class ColliderManager : Manager
    {
        private Scene scene;
        private List<Collider> colliders;

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
            for (int i = 0; i < colliders.Count; i++)
            {
                for (int j = i + 1; j < colliders.Count; j++)
                {
                    if (!ReferenceEquals(colliders[i].Owner, colliders[j].Owner))
                    {
                        if (CheckCollision(colliders[i], colliders[j]))
                        {                                         
                            colliders[i].Owner.OnCollisionEnter(colliders[j]);
                            colliders[j].Owner.OnCollisionEnter(colliders[i]);
                        }
                    }
                }
            }

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

        public bool CheckCollision(Collider obj1, Collider obj2)
        {
            var a = (obj1 as RectCollider).Rect;
            var b = (obj2 as RectCollider).Rect;

            if (obj1.Type == TypeCollider.Rectangle && obj2.Type == TypeCollider.Rectangle)
            {
                return (obj1 as RectCollider).Rect.Intersects((obj2 as RectCollider).Rect);
            }
            return false;
        }

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
