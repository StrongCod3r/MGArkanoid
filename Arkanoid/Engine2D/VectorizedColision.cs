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
        public Vector2[,] vectorMap;

        public VectorCollision(Texture2D normalMap2D)
        {
            //matrix with normal vectors
            this.vectorMap = new Vector2[normalMap2D.Width, normalMap2D.Height];

            //array with each color of the render
            Color[] colors1D = new Color[normalMap2D.Width * normalMap2D.Height];
            normalMap2D.GetData(colors1D);

            int n = 0;
            Color currentColor;
            for (int x = 0; x < normalMap2D.Width ;x++)
            {
                for(int y = 0; y < normalMap2D.Height ;y++)
                {
                    currentColor = colors1D[n];

                    //no color -> no vector -> no colision
                    if (currentColor.A < 200)
                    {
                        vectorMap[x, y] = new Vector2(0, 0);
                    }

                    else
                    {
                        vectorMap[x,y].X = currentColor.B - 127;
                        vectorMap[x,y].Y = currentColor.G - 127;

                        //normal vector are sexy for geometry
                        vectorMap[x,y].Normalize();
                    }
                    n++;
                }

            }

        }//end constructor

    }

}