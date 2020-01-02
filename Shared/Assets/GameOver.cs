using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameOver
    {
        Texture2D texture;
        Rectangle rectangle;
        Text text;

        public GameOver(Rectangle rectangle)
        {
            this.texture = Tools.CreateColorTexture(Color.Green);
            this.text = new Text("MyFont", new Vector2(100, 100));
            this.rectangle = rectangle;

        }

        public void Draw(SpriteBatch spriteBatch, int topScore)
        {
            text.Update($"Game Over\n'p' to restart\n\nTopScore: {topScore}");

            spriteBatch.Draw(texture, rectangle, Color.White);
            text.Draw(spriteBatch, Color.White);
            //spriteBatch.DrawString(texture, , position, Color.White);
        }
    }
}
