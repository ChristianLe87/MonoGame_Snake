﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Menu: IScene
    {

        Button PlayButton;
        Button AboutButton;

        public Menu()
        {
            this.PlayButton = new Button(new Rectangle(50, 50, 200, 50), Color.Pink, Color.Gray);
            this.AboutButton = new Button(new Rectangle(50, 150, 200, 50), Color.Yellow, Color.Gray);
            Game1.isMouseVisible = true;
        }

        public void Update()
        {
            PlayButton.Update(PlayButtonLogic);
            AboutButton.Update(AboutButtonLogic);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            PlayButton.Draw(spriteBatch);
            AboutButton.Draw(spriteBatch);
        }

        
        public void ChangeScene()
        {
            Game1.actualScene = new Level_1();
        }


        public void PlayButtonLogic()
        {
            Console.WriteLine("Play");
        }

        public void AboutButtonLogic()
        {
            Console.WriteLine("About");
        }


    }
}
