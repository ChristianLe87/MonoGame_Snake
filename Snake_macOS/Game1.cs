using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Snake_macOS
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphicsDeviceManager;
        SpriteBatch spriteBatch;
        public static ContentManager contentManager;

        int Width = 300;
        int Height = 300;


        public Game1()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            string localPath = "../../../../MonoGame_Snake/Content/bin/";
            DirectoryInfo directory = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, localPath)));

            contentManager = this.Content;
            contentManager.RootDirectory = directory.ToString();

            graphicsDeviceManager.PreferredBackBufferWidth = Width;
            graphicsDeviceManager.PreferredBackBufferHeight = Height;
        }


        protected override void Initialize()
        {
            // code
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }


        protected override void Update(GameTime gameTime)
        {

            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphicsDeviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
