using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Level_1 : IScene
    {
        Snake snake;
        public static Coin coin;
        Text textScore;
        public static int scoreVal = 0;

        public Level_1()
        {
            this.snake = new Snake();
            coin = new Coin();
            textScore = new Text("MyFont", new Vector2(0,0));
        }

        public void Update()
        {
            snake.Update();
            textScore.Update($"Score: {scoreVal}");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            snake.Draw(spriteBatch);
            coin.Draw(spriteBatch);
            textScore.Draw(spriteBatch,Color.White);
        }
    }
}
