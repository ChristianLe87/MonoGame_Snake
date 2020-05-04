using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Scene1 : IScene
    {
        Snake snake;
        public static Coin coin;
        Text textScore;
        public static int scoreVal;
        public static bool isGameOver;
        GameOver gameOver;


        public Scene1()
        {
            Reset();
        }

        private void Reset()
        {
            this.snake = new Snake();
            coin = new Coin();
            textScore = new Text(WK.Font.MyFont, new Vector2(0, 0));
            scoreVal = 0;
            isGameOver = false;
            gameOver = new GameOver(new Rectangle(0, 0, 300, 300));
            Game1.isMouseVisible = false;
        }

        public void Update(GameTime gameTime)
        {

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.P) && isGameOver)
            {
                Game1.actualScene = WK.Scene.Menu;
                Reset();
            }

            snake.Update();
            textScore.Update($"Score: {scoreVal}");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            snake.Draw(spriteBatch);
            coin.Draw(spriteBatch);
            textScore.Draw(spriteBatch, Color.White);


            if (isGameOver == true)
            {
                gameOver.Draw(spriteBatch, scoreVal);
            }
        }

    }
}
