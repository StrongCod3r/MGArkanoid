using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Engine2D.Managers;


namespace Engine2D
{
    public class Scene
    {
        private String name;
        public bool Loaded = false;
        public bool Pause = false;
        public E2D Game;
        public EntityManager EntityManager;
        private ColliderManager ColliderManager;

        public string Name { get { return name; } set { name = value; } }
        public ContentManager Content { get { return Game.Content; } }

        protected SpriteBatch SB;

        public Scene(string name) : this()
        {
            this.name = name;
        }
        public Scene()
        {
            EntityManager = new EntityManager(this);
            ColliderManager = new ColliderManager(this);
        }


        public virtual void Initialize()
        {
            this.LoadContent();
            Loaded = true;
        }

        public virtual void LoadContent()
        {
            SB = new SpriteBatch(Game.GraphicsDevice);

            if (!EntityManager.Initialized)
                EntityManager.Initialize();

            if (!ColliderManager.Initialized)
                ColliderManager.Initialize();
        }

        public virtual void UnloadContent() { }


        public virtual void Update(GameTime gameTime)
        {
            EntityManager.Update(gameTime);
            ColliderManager.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime)
        {
            SB.Begin();
            //-------------------------------------
            EntityManager.Draw(gameTime, SB);
            if (Game.Debug)
                ColliderManager.Draw(gameTime, SB);
            //-------------------------------------
            SB.End();
        }
    }
}
