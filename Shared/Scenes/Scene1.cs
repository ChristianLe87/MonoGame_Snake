using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Scene1 : IScene
    {
        Snake snake;
        public static Coin coin;
        Label labelScore;
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

            labelScore = new Label(
                                rectangle: new Rectangle(0, 0, WK.Default.CanvasWidth, WK.Default.CanvasHeight),
                                spriteFont: Tools.GetFont(Game1.contentManager, WK.Font.MyFont),
                                text: "",
                                textAlignment: Label.TextAlignment.Top_Left,
                                fontColor: Color.White
                                );

            scoreVal = 0;
            isGameOver = false;
            gameOver = new GameOver(new Rectangle(0, 0, WK.Default.CanvasWidth, WK.Default.CanvasHeight));
            Game1.isMouseVisible = false;
        }

        public void Update(GameTime gameTime)
        {

            KeyboardState keyboardState = Keyboard.GetState();
            if (isGameOver)
            {
                if (keyboardState.IsKeyDown(Keys.P))
                {
                    Game1.actualScene = WK.Scene.Menu;
                    Reset();
                }
                gameOver.Update(topScore: scoreVal);
            }            

            snake.Update();
            labelScore.Update($"Score: {scoreVal}");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            snake.Draw(spriteBatch);
            coin.Draw(spriteBatch);
            labelScore.Draw(spriteBatch);

            if (isGameOver == true) gameOver.Draw(spriteBatch);
        }

    }
}
