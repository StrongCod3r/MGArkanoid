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
    public class Scene : DrawableGameComponent
    {
        private String name;
        public string Name { get => name; set => name = value; }
        public SpriteBatch spriteBatch;
        public E2D Engine;
        public ContentManager Content { get => Game.Content; }

        protected List<Entity> entities;
        public List<Entity> Entities
        {
            get { return this.entities; }
        }

        private bool load = true;
        

        public Scene(E2D engine) : base(engine.game)
        {
            Engine = engine;
            entities = new List<Entity>();
        }

        public void AddEntity(Entity entity)
        {
            if (entity != null)
            {
                entity.Engine = Engine;
                //entity.LoadContent();
                entities.Add(entity);
            }  
        }

        public override void Initialize()
        {
            foreach (Entity e in entities)
            {
                e.Initialize();
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Engine.game.GraphicsDevice);

            foreach (Entity e in entities)
            {
                e.LoadContent();
            }
        }
        public override void Update(GameTime gameTime)
        {
            foreach(Entity e in entities)
            {
                e.Update(gameTime);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            if (load)
            {
                foreach (Entity e in entities)
                {
                    e.LoadContent();
                }
                load = false;
            }

            foreach (Entity e in entities)
            {
                e.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
