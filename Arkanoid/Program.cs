using System;
using Engine2D;
using Arkanoid.Scenes;


namespace Arkanoid
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var game = new E2D("Arkanoid", 1080, 700, false);
            game.SceneManager.LoadScene(new Intro(game), true);
            game.Run();
        }
    }
#endif
}
