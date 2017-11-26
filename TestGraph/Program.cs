using System;
using TestGraph.Core;
using TestGraph.Core.Manager;

namespace TestGraph
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            using (var game = new MainGame())
            {
                GameCore.ContentManager = game.Content;
                GameCore.DeviceManager = game.Graphics;
                GameCore.TextureManager = Texture2DManager.Create();
                GameCore.FontManager = new FontManager();
                GameCore.SpriteBatch = game.SpriteBatch;
                game.Run();
            }
                
        }
    }
#endif
}
