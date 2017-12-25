using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Engine2D.Managers
{
    public abstract class Manager
    {
        protected bool initialized;
        public bool Initialized { get => initialized; }

        #region METHODS OVERRIDE
        public virtual void Initialize() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime, SpriteBatch SB) { }
        #endregion
    }
}
