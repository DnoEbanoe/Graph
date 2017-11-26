using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestGraph.GameObject;

namespace TestGraph.Helper
{
    public static class GameHelper
    {
        public static bool Collide(this I2DGameObject gameObject1, I2DGameObject gameObject2)
        {
	        if (gameObject1.Texture == null || gameObject2.Texture == null)
	        {
		        return false;
	        }
            Rectangle goodSprite1 = new Rectangle((int)gameObject1.Position.X,
                (int)gameObject1.Position.Y, gameObject1.Texture.Width, gameObject1.Texture.Height);
            Rectangle goodSprite2 = new Rectangle((int)gameObject2.Position.X,
                (int)gameObject2.Position.Y, gameObject2.Texture.Width, gameObject2.Texture.Height);

            return goodSprite1.Intersects(goodSprite2);
        }

        public static bool Collide(this Rectangle rectangle1, Rectangle rectangle2)
        {
            Rectangle goodSprite1 = new Rectangle(rectangle1.X,
                rectangle1.Y, rectangle1.Width, rectangle1.Height);
            Rectangle goodSprite2 = new Rectangle(rectangle2.X,
                rectangle2.Y, rectangle2.Width, rectangle2.Height);

            return goodSprite1.Intersects(goodSprite2);
        }

        public static Rectangle GetRectangle(this I2DGameObject gameObject)
        {
            return new Rectangle((int)gameObject.Position.X, (int)gameObject.Position.Y, gameObject.Texture.Width, gameObject.Texture.Height);
        }

        public static Rectangle GetRectangle(Vector2 vector, Texture2D texture)
        {
            return new Rectangle((int)vector.X, (int)vector.Y, texture.Width, texture.Height);
        }
    }
}
