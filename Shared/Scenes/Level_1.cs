using System;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Level_1 : IScene
    {
        Snake snake;

        public Level_1()
        {
            this.snake = new Snake();
        }

        public void Update()
        {
            snake.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            snake.Draw(spriteBatch);
        }
    }
}
