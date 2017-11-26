using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestGraph.Core;
using TestGraph.Helper;

namespace TestGraph.GameObject.Menu
{
    class MenuItem: IMenuItem
    {
	    private readonly string _textureName;
	    private readonly string _textureMoveName;
	    public string Tag { get; set; }
        public Texture2D Texture { get; set; }
		public Vector2 Position { get; set; }
	    public bool IsActive { get; set; }
		public event Action<MenuItem, EventArgs> Click;
        public MenuItem(string textureName, string textureMoveName = null)
        {
	        _textureName = textureName;
	        _textureMoveName = textureMoveName;
	        Texture = GameCore.TextureManager.GetItemnByName(textureName);
        }

        public void Update(GameTime gameTime)
        {
	        var cursorRectangle = GameEngine.Cursor.GetRectangle();
	        var menuItemRectangle = GameHelper.GetRectangle(Position, Texture);
			if (GameCore.MouseState.LeftButton == ButtonState.Pressed)
            {
                if (menuItemRectangle.Collide(cursorRectangle))
                {
                    OnClick();
                }
            }
	        if (_textureMoveName != null && IsActive)
	        {
		        Texture = GameCore.TextureManager.GetItemnByName(_textureMoveName);
			} else
	        {
				Texture = GameCore.TextureManager.GetItemnByName(_textureName);
			}
        }

        public void Draw(GameTime gameTime)
        {
            GameCore.SpriteBatch.Draw(Texture, Position, Color.White);
        }

        protected virtual void OnClick()
        {
	        IsActive = !IsActive;
			Click?.Invoke(this, EventArgs.Empty);
        }
    }
}
