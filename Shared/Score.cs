using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Score
    {
        SpriteFont spriteFont;
        Vector2 position;
        int score = 0;

        public Score(ContentManager Content, Vector2 position)
        {
            spriteFont = Content.Load<SpriteFont>("MyFont");
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, $"{score}", position, Color.White);
        }


        public int GetScore()
        {
            return score;
        }


        public void AddScore()
        {
            score += 10;
        }

        public void ResetScore()
        {
            score = 0;
        }
    }
}
