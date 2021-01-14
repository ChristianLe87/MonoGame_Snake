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
                                spriteFont: Tools.GetFont(Game1.contentManager, WK.Font.MyFont),
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
