using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class _1_Menu: IScene
    {

        Button PlayButton;
        Button AboutButton;

        public _1_Menu()
        {
            this.PlayButton = new Button(new Rectangle(50, 50, 200, 50), Color.Pink, Color.Gray);
            this.AboutButton = new Button(new Rectangle(50, 150, 200, 50), Color.Yellow, Color.Gray);
            Game1.isMouseVisible = true;
        }

        public void Update()
        {
            PlayButton.Update(PlayButtonLogic, "Play");
            AboutButton.Update(AboutButtonLogic, "About");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            PlayButton.Draw(spriteBatch);
            AboutButton.Draw(spriteBatch);
        }

        
        public void ChangeScene()
        {
            Game1.actualScene = new _3_Level_1();
        }


        public void PlayButtonLogic()
        {
            Console.WriteLine("Play");
            Game1.actualScene = new _3_Level_1();
        }

        public void AboutButtonLogic()
        {
            Console.WriteLine("About");
            Game1.actualScene = new _2_About();
        }


    }
}
