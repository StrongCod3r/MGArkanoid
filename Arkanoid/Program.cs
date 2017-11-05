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
            using (var game = new E2D("Arkanoid", 1080, 700, false))
            {
#if DEBUG
                game.SceneManager.LoadScene(new StartScene(), true);
#else
                game.SceneManager.LoadScene(new IntroScene(), true);
#endif
                game.Run();
            }
            

        }
    }
#endif
}
