using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Engine2D;
using Arkanoid.Scenes;


namespace Arkanoid.Scenes
{
    class Intro : Scene
    {
        Texture2D backgrounTexture;
        float timeCount = 0f;

        public Intro()
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent()
        {
            backgrounTexture = Content.Load<Texture2D>("Sprites/background1");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            timeCount += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeCount > 2f)
                Game.SceneManager.LoadScene(new StartScene(), true);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SB.Begin();
            //-------------------------------------
            SB.Draw(backgrounTexture, new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height), Color.White);

            //-------------------------------------
            SB.End();

            base.Draw(gameTime);
        }
    }
}
