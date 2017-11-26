using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TestGraph.Core;

namespace TestGraph.GameObject
{
    class Base2DGameObject: I2DGameObject
    {
        public bool IsVisable { get; set; }
        public bool IsActive { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public float Rotation { get; set; }

        public Base2DGameObject()
        {
            
        }

        public Base2DGameObject(string textureName)
        {
            Texture = GameCore.TextureManager.GetItemnByName(textureName);
        }

        public void Show()
        {
            //if(Texture == null)
            //    throw new NullReferenceException();
            IsActive = true;
            IsVisable = true;
        }

        public void Hide()
        {
            IsActive = false;
            IsVisable = false;
        }

        public void Destroy()
        {
            GameEngine.GameObjects.Remove(this);
        }

        public virtual void Draw(GameTime gameTime)
        {
            GameCore.SpriteBatch.Draw(Texture, Position, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }
    }
}
