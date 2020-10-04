using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Game1 : Game
    {
        SpriteBatch spriteBatch;

        public static GraphicsDeviceManager graphicsDeviceManager;
        public static ContentManager contentManager;

        public const int canvasWidth = 700;
        public const int canvasHeight = 700;

        public static bool isMouseVisible = false;

        // Levels
        public static string actualScene;
        Dictionary<string, IScene> scenes;

        public Game1()
        {

#if __MACOS__
            string absolutePath = Environment.CurrentDirectory;
#else
            string absolutePath = Path.GetFullPath(WK.Content.Shared.RelativePath);
#endif
            this.Content.RootDirectory = absolutePath;

            contentManager = this.Content;

            // FPS
            this.IsFixedTimeStep = true;
            double fps = 60d;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1d / fps);

            // Window size
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = canvasWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = canvasHeight;
            graphicsDeviceManager.ApplyChanges();
            base.Initialize();

        }

        protected override void LoadContent()
        {
            actualScene = WK.Scene.Intro;

            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.scenes = new Dictionary<string, IScene>() {
                { WK.Scene.Intro, new Intro() },
                { WK.Scene.Menu, new Menu() },
                { WK.Scene.Scene1, new Scene1() },
                { WK.Scene.About, new About() }
            };
        }


        protected override void Update(GameTime gameTime)
        {

            Console.WriteLine($"===== Running at FPS: {1f / (gameTime.ElapsedGameTime.Milliseconds / 1000f)} =====");

            scenes[actualScene].Update(gameTime);

            if (actualScene == WK.Scene.Menu)
                this.IsMouseVisible = true;
            else
                this.IsMouseVisible = true;

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphicsDeviceManager.GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            scenes[actualScene].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}