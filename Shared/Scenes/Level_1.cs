using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Level_1 : IScene
    {
        Snake snake;
        public static Coin coin;

        public Level_1()
        {
            this.snake = new Snake();
            coin = new Coin();
        }

        public void Update()
        {
            snake.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            snake.Draw(spriteBatch);
            coin.Draw(spriteBatch);
        }
    }
}
