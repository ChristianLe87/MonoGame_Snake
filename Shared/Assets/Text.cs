using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Text
    {
        Vector2 position;
        string text;
        SpriteFont spriteFont;


        public Text(string assetName, Vector2 position, string text = "")
        {
            this.position = position;
            this.text = text;
            this.spriteFont = Game1.contentManager.Load<SpriteFont>(assetName);
        }

        public void Update(string text)
        {
            this.text = text;
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.DrawString(spriteFont, text, position, color);
        }
    }
}
