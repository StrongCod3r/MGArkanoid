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

        public Microsoft.Xna.Framework.Game game;
        public ContentManager Content { get => Game.Content; }

        protected List<Entity> entities;
        public List<Entity> Entities
        {
            get { return this.entities; }
        }

        private bool load = true;
        

        public Scene(Game game) : base(game)
        {
            entities = new List<Entity>();
        }

        public void AddEntity(Entity entity)
        {
            if (entity != null)
            {
                entity.Game = Game;
                entity.LoadContent();
                entities.Add(entity);
            }  
        }

        protected override void LoadContent()
        {
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

        public override void Draw(GameTime gameTimeç)
        {
            if (load)
            {
                foreach (Entity e in entities)
                {
                    e.Game = Game;
                    e.LoadContent();
                }
                load = false;
            }

            foreach (Entity e in entities)
            {
                e.Draw(spriteBatch);
            }

            base.Draw()
        }
    }
}
