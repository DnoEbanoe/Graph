using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TestGraph.Core;

namespace TestGraph.GameObject.Cursor
{
    internal class Cursor:Base2DGameObject
    {
        public Cursor(string textureName) : base(textureName)
        {
            Show();
        }

        public override void Update(GameTime gameTime)
        {
            Position = GameCore.MouseState.Position.ToVector2();
        }
    }
}
