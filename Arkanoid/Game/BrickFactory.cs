using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine2D;
using Microsoft.Xna.Framework;
using Engine2D;
using Arkanoid.Entities;


namespace Arkanoid.Entities
{
    class BrickFactory
    {
        String levelFile;
        Scene scene;
        Point offset;

        public BrickFactory(Scene scene, String levelFile, Point offset)
        {
            this.scene = scene;
            this.levelFile = levelFile;
            this.offset = offset;
        }

        public void LoadLevel()
        {
            string linea = null;
            string[] brickTypes;

            Brick brick = null;
            var pos = offset.ToVector2();

            //levelFile = string.Format("Content/levels/level{0}.txt", this.numero);
            StreamReader level = File.OpenText(levelFile);

            while ((linea = level.ReadLine()) != null)
            {
                brickTypes = linea.Split(',');
                foreach (String t in brickTypes)
                {
                    if (t != "-")
                    {
                        brick = new Brick(offset.X, offset.X, UInt32.Parse(t));
                        brick.position = pos;
                        scene.AddEntity(brick);
                    }

                    pos.X += (int)brick.size.X;
                }
                pos.X = offset.X;
                pos.Y += brick.size.Y;
            }

        }
    }
}
