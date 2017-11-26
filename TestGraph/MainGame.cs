using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TestGraph.Core;

namespace TestGraph
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        public GraphicsDeviceManager Graphics { get; }
        public SpriteBatch SpriteBatch { get; private set; }
        private GameEngine GameEngine { get; set; }

        public MainGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            GameCore.TextureManager.AddItem("button-add", Content.Load<Texture2D>("Button/btn-add"));
            GameCore.TextureManager.AddItem("button-line", Content.Load<Texture2D>("Button/btn-line"));
            GameCore.TextureManager.AddItem("button-remove", Content.Load<Texture2D>("Button/btn-remove"));
            GameCore.TextureManager.AddItem("button-move", Content.Load<Texture2D>("Button/btn-move"));
	        GameCore.TextureManager.AddItem("button-add-move", Content.Load<Texture2D>("Button/btn-add-move"));
	        GameCore.TextureManager.AddItem("button-line-move", Content.Load<Texture2D>("Button/btn-line-move"));
	        GameCore.TextureManager.AddItem("button-remove-move", Content.Load<Texture2D>("Button/btn-remove-move"));
	        GameCore.TextureManager.AddItem("button-move-move", Content.Load<Texture2D>("Button/btn-move-move"));

			GameEngine = new GameEngine();
        }

        protected override void Update(GameTime gameTime)
        {
            if (!IsActive)
            {
                return;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
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
