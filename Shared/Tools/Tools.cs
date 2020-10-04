﻿using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        public static Texture2D GetImageFromPipeline(string imageName)
        {
#if __MACOS__
            string absolutePath = Path.Combine(Environment.CurrentDirectory, $"{imageName}.png");
#else
            string absolutePath = Path.GetFullPath($"{WK.Content.Shared.RelativePath}{imageName}.png");
#endif

            FileStream fileStream = new FileStream(absolutePath, FileMode.Open);

            var result = Texture2D.FromStream(Game1.graphicsDeviceManager.GraphicsDevice, fileStream);
            fileStream.Dispose();

            return result;

        }
    }
}
