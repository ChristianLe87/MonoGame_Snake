﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class About : IScene
    {
        Button toMenu;
        public About()
        {
            this.toMenu = new Button(new Rectangle(50, 200, 100, 50), Color.LightBlue, Color.Gray);
        }

        public void Update()
        {
            toMenu.Update(GoToMenu, "Go to menu");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            toMenu.Draw(spriteBatch);
        }

        internal void GoToMenu()
        {
            Game1.actualScene = new Menu();
        }
    }
}
