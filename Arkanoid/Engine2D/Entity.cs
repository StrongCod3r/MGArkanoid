using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Engine2D.Colliders;

namespace Engine2D
{
    public abstract class Entity
    {
        #region FIELDS
        private E2D game;
        public string name = "";
        public string tag = "";
        public bool visible;
        public bool enable;
        private List<Collider> collidersList;
        public Vector2 position = Vector2.Zero;
        public Vector2 size = new Vector2(40, 40);

        #endregion

        #region PROPERTIES
        public ContentManager Content { get { return Game.Content; } }
        public E2D Game { get => game; internal set => game = value; }
        internal List<Collider> Colliders { get => collidersList;}
        #endregion

        #region METHODS
        public void AddCollider(Collider collider)
        {
            if (collider == null)
                throw new ArgumentNullException(nameof(collider));

            if (collidersList == null)
                collidersList = new List<Collider>();

            if (this == null)
                throw new NullReferenceException();

            collider.Owner = this;
            collider.Initialize();
            collidersList.Add(collider);

        }

        public bool RemoveCollider(Collider collider)
        {
            if (collider == null)
                throw new ArgumentNullException(nameof(collider));

           if (collidersList != null)
            {
                return collidersList.Remove(collider);
            }
            return false;
        }

        #endregion

        #region METHODS OVERRIDE
        public virtual void Initialize() { }
        public virtual void LoadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime, SpriteBatch SB) { }

        public virtual void OnCollisionEnter(Collider other) { }
        #endregion
    }
}
