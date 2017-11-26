using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace TestGraph.Core.Manager
{
    public class Texture2DManager: IManager<Texture2D>
    {
        private readonly Dictionary<string, Texture2D> _collection = new Dictionary<string, Texture2D>();
        private static Texture2DManager manager;
        private Texture2DManager()
        {
            
        }

        public static Texture2DManager Create()
        {
            return manager ?? (manager = new Texture2DManager());
        }

        public Texture2D GetItemnByName(string name)
        {
            return _collection[name];
        }

        public void AddItem(string name, Texture2D item)
        {
            _collection.Add(name, item);
        }

        public void RemoveItem(string name)
        {
            _collection.Remove(name);
        }
    }
}
