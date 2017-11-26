using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TestGraph.Core.Manager
{
    public class FontManager: IManager<SpriteFont>
    {
        Dictionary<string, SpriteFont> collection = new Dictionary<string, SpriteFont>();
        public SpriteFont GetItemnByName(string name)
        {
            return collection[name];
        }

        public void AddItem(string name, SpriteFont item)
        {
            collection.Add(name, item);
        }

        public void RemoveItem(string name)
        {
            collection.Remove(name);
        }
    }
}
