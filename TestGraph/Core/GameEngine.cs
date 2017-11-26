using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TestGraph.GameObject;
using TestGraph.GameObject.Cursor;
using TestGraph.GameObject.Line;
using TestGraph.GameObject.Menu;
using TestGraph.GameObject.Point;
using TestGraph.Helper;

namespace TestGraph.Core
{
    public class GameEngine
    {
        internal static Cursor Cursor { get; set; } = new Cursor("cursor-blue");
        private Line CurrentLine { get; set; }
        internal static List<I2DGameObject> GameObjects { get; } = new List<I2DGameObject>();
        private Menu Menu { get; set; } = new Menu();
		private IMenuItem AddMenuItem { get; set; }
	    private IMenuItem AddLineMenuItem { get; set; }
	    private IMenuItem MoveMenuItem { get; set; }
	    private IMenuItem RemoveMenuItem { get; set; }
		public GameEngine()
        {
            AddMenu();
			GameObjects.Add(Cursor);
        }

	    private void AddMenu()
        {
	        AddMenuItem = new MenuItem("button-add", "button-add-move") {Tag = "Add", IsActive = true };
	        AddLineMenuItem = new MenuItem("button-line", "button-line-move") {Tag = "AddLine"};
	        MoveMenuItem = new MenuItem("button-move", "button-move-move") {Tag = "Move"};
	        RemoveMenuItem = new MenuItem("button-remove", "button-remove-move") {Tag = "Remove"};
            Menu.AddMenuItem(AddMenuItem);
			Menu.AddMenuItem(AddLineMenuItem);
			Menu.AddMenuItem(MoveMenuItem);
			Menu.AddMenuItem(RemoveMenuItem);
            Menu.Position = Vector2.Zero;
            Menu.Show();
            GameObjects.Add(Menu);
        }

        public void Draw(GameTime gameTime)
        {
            foreach (var gameObject in GameObjects)
            {
                if (gameObject.IsActive)
                {
                    gameObject.Draw(gameTime);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (GameCore.MouseState.LeftButton == ButtonState.Pressed)
            {
	            if (AddMenuItem.IsActive)
	            {
					CreatePoint();
				}
	            else if (AddLineMenuItem.IsActive)
	            {
		            var point = (RedPoint)GetPoint();
		            if (point != null)
		            {
						if (CurrentLine == null)
						{
							CurrentLine = new Line { StartPoint = point };
							GameObjects.Add(CurrentLine);
						}
						else
						{
							if (CurrentLine.StartPoint != point)
							{
								CurrentLine.EndPoint = point;
								CurrentLine = null;
							}
						}
					}
				}
            }
            foreach (var gameObject in GameObjects)
            {
                if (gameObject.IsActive)
                {
                    gameObject.Update(gameTime);
                }
            }
        }

        private void CreatePoint()
        {
			if (Cursor.Position.X > GameCore.DeviceManager.PreferredBackBufferWidth
				|| Cursor.Position.Y > GameCore.DeviceManager.PreferredBackBufferHeight)
				return;
			
			var newPoint = new RedPoint("point-red");
	        if (Menu.Items.FirstOrDefault(item => newPoint.GetRectangle()
					.Collide(GameHelper.GetRectangle(item.Position, item.Texture))) != null)
	        {
		        return;
	        }
	        var point = GetPoint();
			if (point == null)
            {
                GameObjects.Add(newPoint);
            }
        }

	    private I2DGameObject GetPoint()
	    {
		    var newPoint = new RedPoint("point-red");
			var point = GameObjects.FirstOrDefault(gameObject => gameObject.Tags.Contains("collider") &&
					gameObject.Collide(newPoint));
		    return point;
	    }
    }
}
