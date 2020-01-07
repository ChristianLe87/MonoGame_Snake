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

        public static Texture2D GetImageFromPipeline(string assetName)
        {
            return Game1.contentManager.Load<Texture2D>(assetName);
        }
    }
}
