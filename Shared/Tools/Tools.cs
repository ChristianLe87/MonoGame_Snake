using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    internal static class Tools
    {
        public static Texture2D CreateColorTexture(Color color)
        {
            Texture2D newTexture = new Texture2D(Game1.graphicsDeviceManager.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            newTexture.SetData(new Color[] { color });
            return newTexture;
        }

        internal static Texture2D GetImageTexture(string imageName)
        {
            string relativePath = $"../../../../MonoGame_SpaceInvaders/Content/bin/{imageName}.png"; //Bullet_40x80.png
            string absolutePath = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, relativePath))).ToString();

            FileStream fileStream = new FileStream(absolutePath, FileMode.Open);

            var result = Texture2D.FromStream(Game1.graphicsDeviceManager.GraphicsDevice, fileStream);
            fileStream.Dispose();

            return result;
        }

        public static Texture2D GetImageFromPipeline(string assetName)
        {
            return Game1.contentManager.Load<Texture2D>(assetName);
        }

    }
}
