using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestGraph.Core;
using TestGraph.GameObject.Point;
using TestGraph.Helper;

namespace TestGraph.GameObject.Line
{
    class Line: Base2DGameObject
    {
        private RedPoint _startPoint;

        internal RedPoint StartPoint
        {
            get { return _startPoint; }
            set
            {
                _startPoint = value;
                Show();
            }
        }
        internal RedPoint EndPoint { get; set; }
        private SpriteFont Font { get; set; }
        public Line()
        {
            Texture = new Texture2D(GameCore.GraphicsDevice, 1, 1);
            Texture.SetData<Color>(
                new Color[] { Color.White });
            Font = GameCore.FontManager.GetItemnByName("font-default");
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 endPosition;
            if (EndPoint == null)
            {
                endPosition = GameEngine.Cursor.Position;
            }
            else
            {
                endPosition = new Vector2(EndPoint.Position.X + EndPoint.Texture.Height / 2,
                    EndPoint.Position.Y + EndPoint.Texture.Width / 2);
            }
            var startPosition = new Vector2(StartPoint.Position.X + StartPoint.Texture.Height / 2,
                StartPoint.Position.Y + StartPoint.Texture.Width / 2);
            DrawLine(startPosition, //start of line
                endPosition//end of line
            );
            GameCore.SpriteBatch.DrawString(Font,
                Vector2.Distance(startPosition, endPosition).ToString(CultureInfo.InvariantCulture),
                new Vector2((startPosition.X + endPosition.X) / 2, (startPosition.Y + endPosition.Y) / 2),
                Color.White );
        }

        public override void Update(GameTime gameTime)
        {
            if(EndPoint != null)
                return;
            if (GameCore.MouseState.LeftButton == ButtonState.Pressed)
            {
                if(StartPoint == null)
                    throw new NullReferenceException();
                var endPoint =
                    GameEngine.GameObjects.FirstOrDefault(
                        gameObject => gameObject.Tags.Contains("point") && this.Collide(gameObject));
                if (endPoint != null)
                {
                    EndPoint = (RedPoint)endPoint;
                }
            }
            if (GameCore.MouseState.RightButton == ButtonState.Pressed)
            {
                Hide();
            }

            base.Update(gameTime);
        }

        void DrawLine(Vector2 start, Vector2 end)
        {
            Vector2 edge = end - start;
            float angle =
                (float)Math.Atan2(edge.Y, edge.X);


            GameCore.SpriteBatch.Draw(Texture,
                new Rectangle(// rectangle defines shape of line and position of start of line
                    (int)start.X,
                    (int)start.Y,
                    (int)edge.Length(), //sb will strech the texture to fill this rectangle
                    1), //width of line, change this to make thicker line
                null,
                Color.Red, //colour of line
                angle,     //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);

        }
    }
}
