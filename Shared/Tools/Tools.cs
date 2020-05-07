using System;
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
            string relativePath = $"{imageName}.png";
#if __MACOS__
            string absolutePath = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, relativePath))).ToString();
#else
            string s1 = Assembly.GetExecutingAssembly().Location;
            string s2 = Assembly.GetExecutingAssembly().ManifestModule.Name;
            bool first = true;
            string absolutePath = Regex.Replace(s1, s2, (m) => {
                if (first)
                {
                    first = false;
                    return "";
                }
                return s2;
            });
            absolutePath = absolutePath + relativePath;
#endif

            FileStream fileStream = new FileStream(absolutePath, FileMode.Open);

            var result = Texture2D.FromStream(Game1.graphicsDeviceManager.GraphicsDevice, fileStream);
            fileStream.Dispose();

            return result;

        }
    }
}
