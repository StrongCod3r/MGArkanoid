using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    public static class Assets
    {
        #region SPRITES
        public static readonly String[] background =
{
            "Sprites/background_1",
            "Sprites/background_2"
        };

        public static readonly String[] ball =
        {
            "Sprites/ball_blue",
            "Sprites/ball_blue"
        };


        public static readonly String[] paddle =
        {
            "Sprites/paddle_tech",
            "Sprites/paddle_blue",
            "Sprites/paddle_red"
        };

        public static readonly String[] brick =
        {
            "Sprites/brick_blue_rectangle",
            "Sprites/brick_gray_rectangle",
            "Sprites/brick_green_rectangle",
            "Sprites/brick_purple_rectangle",
            "Sprites/brick_yellow_rectangle"
        };
        #endregion

        #region LEVELS
        public static readonly String[] Level =
        {
            "Content/Levels/level_1.txt",
        };
        #endregion
    }
}
