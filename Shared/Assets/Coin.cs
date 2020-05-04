using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Coin
    {
        Texture2D texture;
        Rectangle rectangle;
        Vector2 position;

        public Coin()
        {
            texture = Tools.GetImageFromPipeline(WK.Image.Coin_10x10_PNG);

            Random random = new Random();
            int pos_x = random.Next(30) * 10;
            int pos_y = random.Next(30) * 10;

            this.position = new Vector2(pos_x,pos_y);
            rectangle = new Rectangle((int)position.X, (int)position.Y, 10, 10);
        }

        public Rectangle GetRectangle()
        {
            return rectangle;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

        public void ChangePosition()
        {
            Random random = new Random();
            int pos_x = random.Next(30) * 10;
            int pos_y = random.Next(30) * 10;

            this.position = new Vector2(pos_x, pos_y);

            rectangle = new Rectangle((int)position.X, (int)position.Y, 10, 10);
        }
    }
}