using ChristianTools.Tools;
using ChristianTools.UI;
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
                                spriteFont: Tools.Font.GenerateFont(
                                                            texture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.MyFont_5x7_PNG),
                                                            chars: WK.Default.FontChars),
                                text: aboutText,
                                textAlignment: Label.TextAlignment.Midle_Center,
                                fontColor: Color.White
                                //lineSpacing: 20
                                );

            this.toMenu = new Button(
                                rectangle: new Rectangle(100, 200, 100, 50),
                                text: "",
                                defaultTexture: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.MenuButton.Default),
                                mouseOverTexture: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.MenuButton.MouseOver),
                                spriteFont: Tools.Font.GenerateFont(
                                                            texture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.MyFont_10x14_PNG),
                                                            chars: WK.Default.FontChars),
                                fontColor: Color.Black,
                                ButtonID: ""
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
