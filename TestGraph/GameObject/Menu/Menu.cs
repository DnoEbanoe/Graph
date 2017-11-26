using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TestGraph.Core;
using TestGraph.Helper;

namespace TestGraph.GameObject.Menu
{
    class Menu: Base2DGameObject
    {
	    public List<IMenuItem> Items { get; } = new List<IMenuItem>();
        public MenuOrientation Orientation { get; set; } = MenuOrientation.Horisontal;
	    public event Action<MenuItem, EventArgs> OnMenuItemClick;
        public int OffsetX { get; set; } = 5;
        public int OffsetY { get; set; } = 5;
        public Menu()
        {
            Tags.Add("collider");
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var menuItem in Items)
            {
                menuItem.Draw(gameTime);
            }
        }

        public override void Update(GameTime gameTime)
        {
			var offserSum = 0;
            foreach (var menuItem in Items)
            {
                var positionX = OffsetX + Position.X;
                var positionY = OffsetY + Position.Y;
                if (Orientation == MenuOrientation.Horisontal)
                {
                    positionX += offserSum;
                    offserSum += OffsetX + menuItem.Texture.Width;
                } else if (Orientation == MenuOrientation.Vertical)
                {
                    positionY += offserSum;
                    offserSum += OffsetY + menuItem.Texture.Height;
                }
                menuItem.Position = new Vector2(positionX, positionY);
	            menuItem.Update(gameTime);

			}
            base.Update(gameTime);
        }

	    public void AddMenuItem(IMenuItem item)
	    {
			Items.Add(item);
		    item.Click += ItemOnClick;
		}

	    private void ItemOnClick(MenuItem menuItem, EventArgs eventArgs)
	    {
		    OnOnMenuItemClick(menuItem);
	    }

	    protected virtual void OnOnMenuItemClick(MenuItem arg1)
	    {
		    OnMenuItemClick?.Invoke(arg1, EventArgs.Empty);
	    }

	    #region Private


	    #endregion
    }
}
