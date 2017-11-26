using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestGraph.Core.Manager;

namespace TestGraph.Core
{
    public static class GameCore
    {
        public static GraphicsDevice GraphicsDevice { get; set; }
        public static GraphicsDeviceManager DeviceManager { get; set; }
        public static ContentManager ContentManager { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static IManager<Texture2D> TextureManager { get; set; }
        public static IManager<SpriteFont> FontManager { get; set; }
        public static KeyboardState KeyboardState
        {
            get { return Keyboard.GetState(); }
        }
        public static MouseState MouseState
        {
            get { return Mouse.GetState(); }
        }
    }
}
