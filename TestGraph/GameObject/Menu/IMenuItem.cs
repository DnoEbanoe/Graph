using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestGraph.GameObject.Menu
{
    interface IMenuItem: IGameObject
    {
        string Tag { get; set; }
	    bool IsActive { get; set; }
		Texture2D Texture { get; set; }
		Vector2 Position { get; set; }
        event Action<MenuItem, EventArgs> Click;
    }
}
