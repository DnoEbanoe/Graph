using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestGraph.Core;
using TestGraph.Helper;

namespace TestGraph.GameObject.Point
{
    class RedPoint: Base2DGameObject
    {
        public RedPoint(string textureName) : base(textureName)
        {
            Tags.Add("point");
            Tags.Add("collider");
            var mousePosition = GameCore.MouseState.Position.ToVector2();
            Position = new Vector2(mousePosition.X - (Texture.Height / 2), mousePosition.Y - (Texture.Width / 2));
            Show();
        }

        public override void Update(GameTime gameTime)
        {
            if (this.Collide(GameEngine.Cursor))
            {
                var pointRedBlue = GameCore.TextureManager.GetItemnByName("point-red-blue");
                if (Texture != pointRedBlue)
                {
                    Texture = pointRedBlue;
                }
            }
            else
            {
                var pointRedBlue = GameCore.TextureManager.GetItemnByName("point-red");
                if (Texture != pointRedBlue)
                {
                    Texture = pointRedBlue;
                }
            }
        }
    }
}
