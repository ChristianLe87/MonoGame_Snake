using ChristianTools.Tools;
using ChristianTools.UI;
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
            this.texture2D = Tools.Texture.CreateColorTexture(
                                                    graphicsDevice: Game1.graphicsDeviceManager.GraphicsDevice,
                                                    color: new Color(Color.Green, 255)
                                                    );

            this.label = new Label(
                                rectangle: rectangle,
                                spriteFont: Tools.Font.GenerateFont(
                                                            texture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.MyFont_10x14_PNG),
                                                            chars: WK.Default.FontChars),
                                text: "",
                                textAlignment: Label.TextAlignment.Top_Left,
                                fontColor: Color.White
                                );

            this.rectangle = rectangle;
        }

        public void Update(int topScore)
        {
            label.Update($"Game Over\n\n\n'p' to restart\n\n\nTopScore: {topScore}");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
            label.Draw(spriteBatch);
        }
    }
}
