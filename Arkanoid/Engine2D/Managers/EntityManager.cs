using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine2D;
using Engine2D.Colliders;

namespace Engine2D.Managers
{
    public class EntityManager : Manager
    {
        private List<Entity> entitiesList;
        private Scene scene;

        internal List<Entity> EntitiesList { get => entitiesList; }

        public EntityManager(Scene scene)
        {
            if (scene == null)
                throw new ArgumentNullException(nameof(scene));

            this.scene = scene;

            entitiesList = new List<Entity>();
        }

        public void Add(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.Game = scene.Game;
            entitiesList.Add(entity);
        }

        public override void Initialize()
        {
            foreach (Entity e in EntitiesList)
            {
                e.Initialize();
                e.LoadContent();
            }
            this.initialized = true;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Entity e in EntitiesList)
            {
                e.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch SB)
        {
            foreach (Entity e in EntitiesList)
            {
                e.Draw(gameTime, SB);
            }
        }
    }
}