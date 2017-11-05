using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Engine2D
{
    class SpriteAnimation
    {
        struct Animation
        {
            public float speed;
            public Texture2D[] textures;
            public int length;
            public int index;
        }

        private Dictionary<string, Animation> animations;
        public String currentNameAnimation;
        private int currentFrame;
        private int iFrameCount = 1;
        private Texture2D[] textures;

        private float totalElapsed;   // elapsed time


        Animation currentAnimation;

        public int CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = (int)MathHelper.Clamp(value, 0, iFrameCount - 1); }
        }

        public SpriteAnimation()
        {
            animations = new Dictionary<string, Animation>();
            totalElapsed = 0;
        }

        public void AddAnimation(String name, Texture2D[] textures, float framesPerSec = 0.1f)
        {

            foreach (Texture2D t in textures)
            {
                if (t == null)
                    throw new System.ArgumentException("The parameter textures has a null element.", "textures");
            }

            var anim = new Animation();
            anim.speed = (float)1 / framesPerSec;
            anim.length = textures.Length;
            anim.index = 0;

            anim.textures = new Texture2D[textures.Length];
            
            for (int i = 0; i < textures.Length; i++)
            {
                anim.textures[i] = textures[i];
            }

            animations.Add(name, anim);
            //currentAnimation = anim;
        }

        public void PlayAnimation(String name)
        {
            currentAnimation = animations[name];
        }

        public void Update(GameTime gameTime)
        {
            totalElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (totalElapsed > currentAnimation.speed)
            {
                currentAnimation.index++;
                totalElapsed -= currentAnimation.speed;
            }

            if (currentAnimation.index >= currentAnimation.length)
                currentAnimation.index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float x, float y, int width, int height)
        {
            spriteBatch.Draw(currentAnimation.textures[currentAnimation.index], new Rectangle((int)x, (int)y, width, height), Color.White);
        }


    }
}
