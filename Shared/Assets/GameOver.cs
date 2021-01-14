using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameOver
    {
        Texture2D texture2D;
        Rectangle rectangle;
        Label label;

        public GameOver(Rectangle rectangle)
        {
            this.texture2D = Tools.CreateColorTexture(
                                                    graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                                                    color: new Color(Color.Green,255)
                                                    );

            this.label = new Label(
                                rectangle: rectangle,// new Rectangle(100, 100, 100, 100),
                                spriteFont: Tools.GenerateFont(
                                                            texture2D: Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.MyFont_PNG),
                                                            chars: new char[,]
                                                                        {
                                                                            { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                                                                            { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                                                                            { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                                                            { ',', ':', ';', '?', '.', '!', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
                                                                        }),
                                text: "",
                                textAlignment: Label.TextAlignment.Midle_Center,
                                fontColor: Color.White
                                );

            this.rectangle = rectangle;
        }

        public void Update(int topScore)
        {
            label.Update($"Game Over\n'p' to restart\n\nTopScore: {topScore}");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
            label.Draw(spriteBatch);
        }
    }
}
