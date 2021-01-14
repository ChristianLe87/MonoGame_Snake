using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Tools
    {
        /// <summary>
        /// Generate a new texture from a PNG file
        /// </summary>
        public static Texture2D GetTexture(GraphicsDevice graphicsDevice, ContentManager contentManager, string imageName, string folder = "")
        {
            string absolutePath = new DirectoryInfo(Path.Combine(Path.Combine(contentManager.RootDirectory, folder), $"{imageName}.png")).ToString();

            FileStream fileStream = new FileStream(absolutePath, FileMode.Open);

            var result = Texture2D.FromStream(graphicsDevice, fileStream);
            fileStream.Dispose();

            return result;
        }

        /// <summary>
        /// Generate a new font from a Texture2D
        /// </summary>
        public static SpriteFont GenerateFont(Texture2D texture2D, char[,] chars)
        {
            // ===== Implementation =====
            {
                List<FontChar> fontChars = GetFontChar(chars);

                // The line spacing (the distance from baseline to baseline) of the font
                List<char> characters = fontChars.Select(x => x.c).ToList();

                // The rectangles in the font texture containing letters
                List<Rectangle> glyphBounds = fontChars.Select(x => x.glyphBound).ToList();

                // The cropping rectangles, which are applied to the corresponding glyphBounds to calculate the bounds of the actual character
                List<Rectangle> cropping = fontChars.Select(x => x.cropping).ToList();

                // The line spacing (the distance from baseline to baseline) of the font
                int lineSpacing = 10;

                // The spacing (tracking) between characters in the font
                float spacing = 0f;

                // The letters kernings(X - left side bearing, Y - width and Z - right side bearing)
                List<Vector3> kerning = fontChars.Select(x => x.kerning).ToList();

                // The character that will be substituted when a given character is not included in the font
                char defaultCharacter = '?';

                SpriteFont spriteFont = new SpriteFont(texture2D, glyphBounds, cropping, characters, lineSpacing, spacing, kerning, defaultCharacter);

                return spriteFont;
            }

            // ===== Helpers =====
            List<FontChar> GetFontChar(char[,] chars)
            {
                List<FontChar> fontChars = new List<FontChar>();
                for (int col = 0; col < chars.GetLength(0); col++)
                {
                    for (int el = 0; el < chars.GetLength(1); el++)
                    {
                        fontChars.Add(new FontChar(chars[col, el], new Rectangle(el * 5, 7 * col, 5, 7)));
                    }
                }
                return fontChars.Where(x => x.c != ' ').OrderBy(x => x.c).ToList();
            }
        }

        class FontChar
        {
            public char c { get; }
            public Rectangle glyphBound { get; }
            public Rectangle cropping { get; }
            public Vector3 kerning { get; }

            public FontChar(char c, Rectangle glyphBound)
            {
                this.c = c;
                this.glyphBound = glyphBound;
                this.cropping = new Rectangle(0, 0, 0, 0);
                this.kerning = new Vector3(0, 7, 0);
            }
        }

        /// <summary>
        /// Get a SpriteFont from ContentManager
        /// </summary>
        public static SpriteFont GetFont(ContentManager contentManager, string fontName, string folder = "")
        {
            return contentManager.Load<SpriteFont>(Path.Combine(folder, fontName));
        }

        /// <summary>
        /// Get a new Texture2D from a bigger Texture2D
        /// </summary>
        public static Texture2D CropTexture(GraphicsDevice graphicsDevice, Texture2D originalTexture2D, Rectangle extractRectangle)
        {
            Texture2D subtexture = new Texture2D(graphicsDevice, extractRectangle.Width, extractRectangle.Height);
            int count = extractRectangle.Width * extractRectangle.Height;
            Color[] data = new Color[count];

            originalTexture2D.GetData(0, new Rectangle(extractRectangle.X, extractRectangle.Y, extractRectangle.Width, extractRectangle.Height), data, 0, count);
            subtexture.SetData(data);

            return subtexture;
        }

        /// <summary>
        /// Create a new Texture2D from a Color
        /// </summary>
        public static Texture2D CreateColorTexture(GraphicsDevice graphicsDevice, Color color, int Width = 1, int Height = 1)
        {
            Texture2D texture2D = new Texture2D(graphicsDevice, Width, Height, false, SurfaceFormat.Color);
            Color[] colors = new Color[Width * Height];

            // Set each pixel to color
            colors = colors
                        .Select(x => x = color)
                        .ToArray();

            texture2D.SetData(colors);

            return texture2D;
        }
    }
}
