using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Engine2D.Colliders
{
    public abstract class Collider
    {
        public Entity Owner { get; set; }
        public Vector2 normal;
        public Vector2 Normal { get => normal; set => normal = value; }
        protected int x, y;
        protected int width, height;
        protected TypeCollider type;
        public TypeCollider Type { get => type;}
        public bool enable = true;
        protected bool initialized;
        public bool Initialized { get => initialized; }

        public virtual void Initialize() { }
        public virtual void LoadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime, SpriteBatch SB) { }

        
    }
}
