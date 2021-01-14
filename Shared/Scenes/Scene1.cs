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
spriteFont: Tools.GenerateFont(
                                                            texture2D: Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.MyFont_PNG),
                                                            chars: new char[,]
                                                                        {
                                                                            { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                                                                            { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                                                                            { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                                                            { ',', ':', ';', '?', '.', '!', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
                                                                        }), text: "",
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
