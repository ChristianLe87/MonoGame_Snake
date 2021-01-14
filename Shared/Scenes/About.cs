using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class About : IScene
    {
        Label label;
        Button toMenu;
        string aboutText =
                        "Game inspired by the Snake Game\n" +
                        "I coded to keep my C# skills on shape\n" +
                        "Created using MonoGame\n\n" +
                        "I know, I know...\n" +
                        "I need a designer...";

        public About()
        {

            this.label = new Label(
                                rectangle: new Rectangle(0, 0, WK.Default.CanvasWidth, WK.Default.CanvasHeight),
spriteFont: Tools.GenerateFont(
                                                            texture2D: Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.MyFont_PNG),
                                                            chars: new char[,]
                                                                        {
                                                                            { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                                                                            { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                                                                            { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                                                            { ',', ':', ';', '?', '.', '!', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
                                                                        }), text: aboutText,
                                textAlignment: Label.TextAlignment.Midle_Center,
                                fontColor: Color.White,
                                lineSpacing: 20
                                );

            this.toMenu = new Button(
                                rectangle: new Rectangle(100, 200, 100, 50),
                                text: "",
                                defaultTexture: Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.MenuButton.Default),
                                mouseOverTexture: Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.MenuButton.MouseOver),
spriteFont: Tools.GenerateFont(
                                                            texture2D: Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.MyFont_PNG),
                                                            chars: new char[,]
                                                                        {
                                                                            { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                                                                            { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                                                                            { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                                                            { ',', ':', ';', '?', '.', '!', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
                                                                        }), fontColor: Color.Black
                                );
        }

        public void Update(GameTime gameTime)
        {
            toMenu.Update(GoToMenu);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            toMenu.Draw(spriteBatch);
            label.Draw(spriteBatch);
        }

        internal void GoToMenu()
        {
            Game1.actualScene = WK.Scene.Menu;
        }
    }
}
