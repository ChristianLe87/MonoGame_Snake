using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace proyecto_Compartido
{
    public class Game2 : Game
    {
        public static GraphicsDeviceManager graphicsDeviceManager;
        SpriteBatch spriteBatch;
        public static ContentManager contentManager;

        int Width = 300;
        int Height = 300;

        public static bool isMouseVisible = false;
        //public static IScene actualScene;

        public Game2()
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
            //actualScene = new _0_Intro();
        }


        protected override void Update(GameTime gameTime)
        {

            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (isMouseVisible == true)
                IsMouseVisible = true;
            else
                IsMouseVisible = false;


            //actualScene.Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphicsDeviceManager.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            //actualScene.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
