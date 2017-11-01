using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Engine2D
{
    public class Scene
    {
        private String name;
        public string Name { get { return name; } set { name = value; } }
        public E2D Game;
		public ContentManager Content { get { return Game.Content; } }

        protected List<Entity> entities;
        public List<Entity> Entities
        {
            get { return this.entities; }
        }

        public bool isLoaded = false;

        protected SpriteBatch SB;

        public Scene()
        {
            entities = new List<Entity>();
        }

        public void AddEntity(Entity entity)
        {
            if (entity != null)
            {
                entity.Game = Game;
                entities.Add(entity);
            }  
        }

        public virtual void Initialize()
        {
            this.LoadContent();

            foreach (Entity e in entities)
            {
                e.Game = this.Game;
                e.SB = this.SB;
                e.Initialize();
                e.LoadContent();
            }

            isLoaded = true;
  
        }

        public virtual void LoadContent()
        {
            SB = new SpriteBatch(Game.GraphicsDevice);

            foreach (Entity e in entities)
            {
                e.LoadContent();
            }
        }

        public virtual void UnloadContent() { }


        public virtual void Update(GameTime gameTime)
        {
            foreach(Entity e in entities)
            {
                e.Update(gameTime);
            }
        }

        public virtual void Draw(GameTime gameTime)
        {
            SB.Begin();
            //-------------------------------------
            foreach (Entity e in entities)
            {
                e.Draw(gameTime);
            }
            //-------------------------------------
            SB.End();
        }
    }
}
