using System;
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
            this.PlayButton = new Button(new Rectangle(100, 75, 100, 50), WK.Image.PlayButton.Default, WK.Image.PlayButton.MouseOver);
            this.AboutButton = new Button(new Rectangle(100, 150, 100, 50), WK.Image.AboutButton.Default, WK.Image.AboutButton.MouseOver);
            Game1.isMouseVisible = true;
        }

        public void Update(GameTime gameTime)
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
            Game1.actualScene = WK.Scene.Scene1;
        }


        public void PlayButtonLogic()
        {
            Console.WriteLine("Play");
            Game1.actualScene = WK.Scene.Scene1;
        }

        public void AboutButtonLogic()
        {
            Console.WriteLine("About");
            Game1.actualScene = WK.Scene.About;
        }

    }
}
