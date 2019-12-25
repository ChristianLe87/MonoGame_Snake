using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Text
    {
        Vector2 position;
        string text = "";
        SpriteFont spriteFont;


        public Text(string assetName, Vector2 position)
        {
            this.spriteFont = Game1.contentManager.Load<SpriteFont>(assetName);
            this.position = position;
        }

        public void Update(string text)
        {
            this.text = text;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, text, position, Color.Black);
        }
    }
}
