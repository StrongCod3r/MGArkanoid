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

namespace Arkanoid
{
    public class CharacterBase : Entity
    {
        public Vector2 position;
        public String name;
        public Vector2 size;
    }
}
