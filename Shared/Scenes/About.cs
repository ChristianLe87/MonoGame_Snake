using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class About : IScene
    {
        Text text;
        Button toMenu;

        public About()
        {
            string aboutText =
                "Game inspired by the Snake Game\n" +
                "I coded to keep my C# skills on shape\n" +
                "Created using MonoGame\n\n" +
                "I know, I know...\n" +
                "I need a designer...";
            this.text = new Text(WK.Font.MyFont, new Vector2(20, 50), aboutText);
            this.toMenu = new Button(new Rectangle(100, 200, 100, 50), WK.Image.MenuButton.Default, WK.Image.MenuButton.MouseOver);
            Game1.isMouseVisible = true;
        }

        public void Update(GameTime gameTime)
        {
            toMenu.Update(GoToMenu);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            toMenu.Draw(spriteBatch);
            text.Draw(spriteBatch, Color.White);
        }

        internal void GoToMenu()
        {
            Game1.actualScene = WK.Scene.Menu;
        }
    }
}
