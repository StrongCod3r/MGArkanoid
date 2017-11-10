using System;
using System.Collections.Generic;
using Engine2D;

namespace Engine2D.Managers
{
    public class EntityManager
    {
        private List<Entity> entities;
        private Scene scene;


        public EntityManager(Scene scene)
        {
            entities = new List<Entity>();
            this.scene = scene;
        }

        public void Add(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

             

        }
    }
}