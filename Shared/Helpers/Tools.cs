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
        public static Texture2D GetTexture(GraphicsDevice graphicsDevice, ContentManager contentManager, string imageName)
        {
            string absolutePath = new DirectoryInfo(Path.Combine(contentManager.RootDirectory, $"{imageName}.png")).ToString();
            Texture2D result = Texture2D.FromFile(graphicsDevice, absolutePath);
            return result;
        }

        /// <summary>
        /// Generate a new font from a Texture2D
        /// </summary>
        public static SpriteFont GenerateFont(Texture2D texture2D, char[,] chars)
        {
            int charWidth = texture2D.Width / chars.GetLength(1);
            int charHigh = texture2D.Height / chars.GetLength(0);

            // ===== Implementation =====
            {
                List<FontChar> fontChars = GetFontChar(chars);

                // The line spacing (the distance from baseline to baseline) of the font
                List<char> characters = fontChars.Select(x => x._char).ToList();

                // The rectangles in the font texture containing letters
                List<Rectangle> glyphBounds = fontChars.Select(x => x.glyphBound).ToList();

                // The cropping rectangles, which are applied to the corresponding glyphBounds to calculate the bounds of the actual character
                List<Rectangle> cropping = fontChars.Select(x => x.cropping).ToList();

                // The line spacing (the distance from baseline to baseline) of the font
                int lineSpacing = charHigh + 2;

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
                for (int column = 0; column < chars.GetLength(0); column++)
                {
                    for (int element = 0; element < chars.GetLength(1); element++)
                    {
                        fontChars.Add(new FontChar(
                                                chars[column, element],
                                                new Rectangle(element * charWidth, column * charHigh, charWidth, charHigh)));
                    }
                }
                return fontChars.Where(x => x._char != '\0').OrderBy(x => x._char).ToList();
            }
        }

        class FontChar
        {
            public char _char { get; }
            public Rectangle glyphBound { get; }
            public Rectangle cropping { get; }
            public Vector3 kerning { get; }

            public FontChar(char c, Rectangle glyphBound)
            {
                this._char = c;
                this.glyphBound = glyphBound;
                this.cropping = new Rectangle(0, 0, 0, 0);
                this.kerning = new Vector3(0, glyphBound.Width, glyphBound.Width/3);
            }
        }

        /// <summary>
        /// Get a SpriteFont from ContentManager
        /// </summary>
        /*public static SpriteFont GetFont(ContentManager contentManager, string fontName, string folder = "")
        {
            return contentManager.Load<SpriteFont>(Path.Combine(folder, fontName));
        }*/

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