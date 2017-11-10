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
    public abstract class Entity
    {
        private E2D game;
        public ContentManager Content { get { return Game.Content; } }

        public E2D Game { get => game; internal set => game = value; }

        public SpriteBatch SB;
        public string name;
        public bool visible;
        public bool enable;

        public virtual void Initialize() { }
        public virtual void LoadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime) { }
    }
}
