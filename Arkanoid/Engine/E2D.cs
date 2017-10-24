using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Arkanoid.Scenes;

namespace Engine2D
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class E2D
    {
        public Game game;
        public GraphicsDeviceManager graphicsDevice;
        public SceneManager SceneManager;

        public E2D(String name, int with, int height, bool fullScreen = false)
        {
            game = new Game();
            game.Content.RootDirectory = "Content";
            graphicsDevice = new GraphicsDeviceManager(game);
            graphicsDevice.PreferredBackBufferWidth = with;
            graphicsDevice.PreferredBackBufferHeight = height;
            graphicsDevice.IsFullScreen = fullScreen;
            graphicsDevice.ApplyChanges();
            SceneManager = new SceneManager(this);
            game.Components.Add(SceneManager);
        }

        public void Run()
        {
            game.Run();
        }
    }
}
