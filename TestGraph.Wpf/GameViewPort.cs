using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Framework.WpfInterop;
using MonoGame.Framework.WpfInterop.Input;
using TestGraph.Core;

namespace TestGraph.Wpf
{
    public class GameViewPort: WpfGame
    {
        private WpfKeyboard _keyboard;
        private WpfMouse _mouse;

        public WpfGraphicsDeviceService Graphics { get; }
        public SpriteBatch SpriteBatch { get; private set; }
        private GameEngine GameEngine { get; set; }

        public GameViewPort()
        {
            Graphics = new WpfGraphicsDeviceService(this);
            Content.RootDirectory = "Content";
            _keyboard = new WpfKeyboard(this);
            _mouse = new WpfMouse(this);

            // must be called after the WpfGraphicsDeviceService instance was created
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            GameCore.SpriteBatch = SpriteBatch;
            GameCore.GraphicsDevice = GraphicsDevice;

            GameCore.TextureManager.AddItem("point-red", Content.Load<Texture2D>("Point/point-red"));
            GameCore.TextureManager.AddItem("point-red-blue", Content.Load<Texture2D>("Point/point-red-blue"));
            GameCore.TextureManager.AddItem("cursor-blue", Content.Load<Texture2D>("Cursor/cursor-blue"));
            GameCore.TextureManager.AddItem("line - black", Content.Load<Texture2D>("Line/line-black"));
            GameCore.FontManager.AddItem("font-default", Content.Load<SpriteFont>("Font/font-default"));
            GameEngine = new GameEngine();
        }

        protected override void Update(GameTime gameTime)
        {
            if (!IsActive)
            {
                return;
            }
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))

            GameEngine.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteBatch.Begin();
            GameEngine.Draw(gameTime);
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
