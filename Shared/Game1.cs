using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphicsDeviceManager;
        SpriteBatch spriteBatch;

        int Width = 300;
        int Height = 300;

        public static bool isMouseVisible = false;
        public static IScene actualScene;

        public Game1()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            string localPath = "../../../../MonoGame_Snake/Content/bin/";
            DirectoryInfo directory = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, localPath)));
            Content.RootDirectory = directory.ToString();

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
            actualScene = new Menu();
        }


        protected override void Update(GameTime gameTime)
        {

            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(isMouseVisible == true)
                IsMouseVisible = true;
            else
                IsMouseVisible = false;


            actualScene.Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphicsDeviceManager.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            actualScene.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}