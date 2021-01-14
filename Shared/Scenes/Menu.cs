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
            this.PlayButton = new Button(
                                    rectangle: new Rectangle(100, 75, 100, 50),
                                    text: "",
                                    defaultTexture: Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.PlayButton.Default),
                                    mouseOverTexture: Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.PlayButton.MouseOver),
                                    spriteFont: Tools.GetFont(Game1.contentManager, WK.Font.MyFont),
                                    fontColor: Color.White
                                    );

            this.AboutButton = new Button(
                                    rectangle: new Rectangle(100, 150, 100, 50),
                                    text: "",
                                    defaultTexture: Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.AboutButton.Default),
                                    mouseOverTexture: Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Image.AboutButton.MouseOver),
                                    spriteFont: Tools.GetFont(Game1.contentManager, WK.Font.MyFont),
                                    fontColor: Color.White
                                    );
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
