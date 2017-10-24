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
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class E2D
    {
        public Game game;
        public GraphicsDeviceManager graphicsDevice;
        public SceneManager sceneManager;

        public E2D()
        {
            game = new Game();
            game.Content.RootDirectory = "Content";
            graphicsDevice = new GraphicsDeviceManager(game);
            sceneManager = new SceneManager(this);
            game.Components.Add(sceneManager);
            game.Run();
        }
    }
}
