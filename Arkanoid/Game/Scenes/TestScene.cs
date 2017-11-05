using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Engine2D;
using Arkanoid;
using Arkanoid.Entities;


namespace Arkanoid.Scenes
{

    class TestScene : Scene
    {

        SpriteAnimation paddleSprite;

        public TestScene()
        {
            paddleSprite = new SpriteAnimation();
        }

        public override void Initialize()
        {
            
            base.Initialize();

        }

        public override void LoadContent()
        {
            
            Texture2D[] paddleTextures =
            {
                Content.Load<Texture2D>(Assets.paddle[0]),
                Content.Load<Texture2D>(Assets.paddle[1]),
                Content.Load<Texture2D>(Assets.paddle[2]),
                Content.Load<Texture2D>(Assets.paddle[3]),
                Content.Load<Texture2D>(Assets.paddle[4])
            };

            paddleSprite.AddAnimation("capture", paddleTextures, 2);
            paddleSprite.PlayAnimation("capture");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            paddleSprite.Update(gameTime);

            base.Update(gameTime);
            
        }

        public override void Draw(GameTime gameTime)
        {
            SB.Begin();
            //-------------------------------------

            paddleSprite.Draw(SB, 300, 200, 500, 300);

            //-------------------------------------
            SB.End();
            base.Draw(gameTime);
        }
    }
}
