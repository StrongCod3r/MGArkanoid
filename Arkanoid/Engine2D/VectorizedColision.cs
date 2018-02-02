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
    public class VectorCollision
    {
        public bool[,] collisionMap;
        public Vector2 mapPosition;

        public VectorCollision(Texture2D sprite2D, Vector2 cornerPosition)
        {
            this.mapPosition = cornerPosition;
            //matrix with "things"
            this.collisionMap = new bool[sprite2D.Width, sprite2D.Height];

            //array with each color of the render
            Color[] colors1D = new Color[sprite2D.Width * sprite2D.Height];
            sprite2D.GetData(colors1D);

            int n = 0;
            Color currentColor;
            for (int x = 0; x < sprite2D.Width; x++)
            {
                for (int y = 0; y < sprite2D.Height; y++)
                {
                    currentColor = colors1D[n];

                    //no color -> no colision
                    if (currentColor.A < 200)
                    {
                        collisionMap[x, y] = false;
                    }

                    //color -> thing -> collision
                    else
                    {
                        collisionMap[x, y] = true;
                    }
                    n++;
                }

            }

        }//end constructor
    }
}