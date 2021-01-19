using System;
using System.Collections.Generic;
using System.IO;
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

        public static bool isMouseVisible = false;

        // Levels
        public static string actualScene;
        Dictionary<string, IScene> scenes;

        public Game1()
        {
            string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            this.Content.RootDirectory = absolutePath;
            contentManager = this.Content;

            // FPS
            this.IsFixedTimeStep = true;
            double fps = 60d;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1d / fps);

            // Window size
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = WK.Default.CanvasWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = WK.Default.CanvasHeight;
            graphicsDeviceManager.ApplyChanges();

            this.IsMouseVisible = true;

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
            scenes[actualScene].Update(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphicsDeviceManager.GraphicsDevice.Clear(Color.LightGreen);

            spriteBatch.Begin();

            scenes[actualScene].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}