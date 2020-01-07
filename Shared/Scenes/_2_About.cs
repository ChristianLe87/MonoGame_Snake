using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class _2_About : IScene
    {
        Text text;
        Button toMenu;

        public _2_About()
        {
            string aboutText = "Game inspired by the Snake Game\nI coded to keep my C# sckils on shape\n\nI need a designer...";
            this.text = new Text(WK.Font.MyFont, new Vector2(20, 50), aboutText);
            this.toMenu = new Button(new Rectangle(50, 200, 150, 50), Color.LightBlue, Color.Gray);
        }

        public void Update()
        {
            toMenu.Update(GoToMenu, "Go to menu");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            toMenu.Draw(spriteBatch);
            text.Draw(spriteBatch, Color.White);
        }

        internal void GoToMenu()
        {
            Game1.actualScene = new _1_Menu();
        }
    }
}
