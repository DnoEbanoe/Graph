using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestGraph.Core.Manager;

namespace TestGraph.GameObject
{
    public interface I2DGameObject: IGameObject
    {
        bool IsVisable { get; set; }
        bool IsActive { get; set; }
        float Rotation { get; set; }
        Texture2D Texture { get; set; }
        Vector2 Position { get; set; }
        List<string> Tags { get; set; }
        void Show();
        void Hide();
        void Destroy();
    }
}
