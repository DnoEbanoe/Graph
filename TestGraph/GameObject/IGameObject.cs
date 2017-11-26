using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TestGraph.GameObject
{
    public interface IGameObject
    {
        void Draw(GameTime gameTime);
        void Update(GameTime gameTime);
    }
}
