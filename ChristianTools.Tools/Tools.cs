using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChristianTools.Components;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChristianTools.Tools
{
    public class Tools
    {
        public class Texture
        {
            /// <summary>
            /// Increase image size by a scale factor
            /// </summary>
            public static Texture2D ScaleTexture(GraphicsDevice graphicsDevice, Texture2D originalTexture, int scaleFactor)
            {
                // === Implementation ===
                {
                    Color[] originalColors = new Color[originalTexture.Width * originalTexture.Height];
                    originalTexture.GetData(0, new Rectangle(0, 0, originalTexture.Width, originalTexture.Height), originalColors, 0, (originalTexture.Width * originalTexture.Height));

                    Color[,] multidimentionalColors = ToMultidimentional(originalColors, originalTexture.Width, originalTexture.Height);

                    Color[,] expandedColors = Expand(multidimentionalColors, scaleFactor);

                    Color[] flatResult = FlattenArray(expandedColors);

                    Texture2D newTexture2D = new Texture2D(graphicsDevice, originalTexture.Width * scaleFactor, originalTexture.Height * scaleFactor, false, SurfaceFormat.Color);
                    newTexture2D.SetData(flatResult);

                    return newTexture2D;
                }

                // === Helpers ===
                Color[,] ToMultidimentional(Color[] arr, int width, int height)
                {
                    Color[,] result = new Color[height, width];

                    int count = 0;
                    for (int w = 0; w < height; w++)
                    {
                        for (int h = 0; h < width; h++)
                        {
                            result[w, h] = arr[count];
                            count++;
                        }
                    }
                    return result;
                }


                Color[,] Expand(Color[,] original, int multiply)
                {
                    // From stackoverflow: https://stackoverflow.com/questions/69705678/multiply-element-in-multidimensional-array?answertab=votes#tab-top
                    int sizeX = original.GetLength(0);
                    int sizeY = original.GetLength(1);

                    Color[,] newArray = new Color[sizeX * multiply, sizeY * multiply];

                    for (var i = 0; i < newArray.GetLength(0); i++)
                        for (var j = 0; j < newArray.GetLength(1); j++)
                            newArray[i, j] = original[i / multiply, j / multiply];

                    return newArray;
                }

                static Color[] FlattenArray(Color[,] input)
                {
                    Color[] result = new Color[input.Length];

                    int count = 0;
                    for (int w = 0; w <= input.GetUpperBound(0); w++)
                        for (int h = 0; h <= input.GetUpperBound(1); h++)
                            result[count++] = input[w, h];

                    return result;
                }
            }


            /// <summary>
            /// Generate a new texture from a PNG file
            /// </summary>
            /// <param name="imageName">File name of the PNG -> without the extension</param>
            /// <returns></returns>
            public static Texture2D GetTexture(GraphicsDevice graphicsDevice, ContentManager contentManager, string imageName)
            {
                string absolutePath = Path.Combine(contentManager.RootDirectory, $"{imageName}.png");
                Texture2D result = Texture2D.FromFile(graphicsDevice, absolutePath);
                return result;
            }

            /// <summary>
            /// Get a new Texture2D from a bigger Texture2D
            /// </summary>
            public static Texture2D CropTexture(GraphicsDevice graphicsDevice, Texture2D originalTexture, Rectangle extractRectangle)
            {
                Texture2D subtexture = new Texture2D(graphicsDevice, extractRectangle.Width, extractRectangle.Height);
                int count = extractRectangle.Width * extractRectangle.Height;
                Color[] data = new Color[count];

                originalTexture.GetData(0, new Rectangle(extractRectangle.X, extractRectangle.Y, extractRectangle.Width, extractRectangle.Height), data, 0, count);
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

            /// <summary>
            /// Tint a texture
            /// </summary>
            public static Texture2D ReColorTexture(GraphicsDevice graphicsDevice, Texture2D originalTexture, Color color)
            {
                Texture2D texture2D = new Texture2D(graphicsDevice, originalTexture.Width, originalTexture.Height, false, SurfaceFormat.Color);

                int count = originalTexture.Width * originalTexture.Height;
                Color[] data = new Color[count];

                originalTexture.GetData(0, new Rectangle(0, 0, originalTexture.Width, originalTexture.Height), data, 0, count);

                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].A != 0)
                    {
                        data[i] = new Color(color.R, color.G, color.B, data[i].A);
                    }
                }

                texture2D.SetData(data);


                return texture2D;
            }

            /// <summary>
			/// CreateCircleTexture
			/// </summary>
            public static Texture2D CreateCircleTexture(GraphicsDevice graphicsDevice, Color color, int radius = 1)
            {
                // Implementation
                {
                    List<Color> circle = new List<Color>();
                    for (int y = (radius * -1); y < radius; y++)
                    {
                        for (int x = (radius * -1); x < radius; x++)
                        {
                            float pitagoras = Pitagoras(x, y);

                            if (pitagoras <= radius)
                                circle.Add(color);
                            else
                                circle.Add(Color.Transparent);
                        }
                    }

                    Texture2D texture2D = new Texture2D(graphicsDevice, radius * 2, radius * 2, false, SurfaceFormat.Color);
                    texture2D.SetData(circle.ToArray());

                    return texture2D;
                }

                // Helpers
                float Pitagoras(int x, int y)
                {
                    // r = (x^2 + y^2)^(1/2)
                    return (float)Math.Sqrt(((x * x) + (y * y)));
                }
            }

            public static Texture2D CreateTriangle(GraphicsDevice graphicsDevice, Color color, int Width, int Height)
            {
                List<Color> colors = new List<Color>();

                Point p1 = new Point(0, 0); // top
                Point p2 = new Point(Width, Height / 2); // middle
                Point p3 = new Point(0, Height); // down

                float m1 = Tools.MyMath.M(p1.ToVector2(), p2.ToVector2());
                float m2 = Tools.MyMath.M(p3.ToVector2(), p2.ToVector2());

                for (int h = 0; h < Height; h++)
                {
                    for (int w = 0; w < Width; w++)
                    {
                        if (h < Height / 2)
                        {
                            int result = (int)(m1 * w + p1.Y);

                            if (result <= h)
                                colors.Add(color);
                            else
                                colors.Add(Color.Transparent);
                        }
                        else
                        {
                            int result = (int)(m2 * w + p3.Y);

                            if (result >= h)
                                colors.Add(color);
                            else
                                colors.Add(Color.Transparent);
                        }

                    }
                }



                Texture2D texture2D = new Texture2D(graphicsDevice, Width, Height, false, SurfaceFormat.Color);
                texture2D.SetData(colors.ToArray());

                return texture2D;
            }
        }

        public class Font
        {
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
                    this.kerning = new Vector3(0, glyphBound.Width, glyphBound.Width / 3);
                }
            }

            /// <summary>
            /// Get a SpriteFont from ContentManager
            /// </summary>
            public static SpriteFont GetFont(ContentManager contentManager, string fontName)
            {
                return contentManager.Load<SpriteFont>(fontName);
            }
        }

        public class Sound
        {
            /// <summary>
            /// Get SoundEffect from WAV file
            /// </summary>
            /// <param name="soundName">File name of the WAV -> without the extension</param>
            /// <returns></returns>
            public static SoundEffect GetSoundEffect(GraphicsDevice graphicsDevice, ContentManager contentManager, string soundName)
            {
                string absolutePath = Path.Combine(contentManager.RootDirectory, $"{soundName}.wav");
                SoundEffect result = SoundEffect.FromFile(absolutePath);
                return result;
            }
        }

        public class MyMath
        {
            /// <summary>
            /// Calculate inclination
            /// </summary>
            public static float M(Vector2 start, Vector2 direction)
            {
                float y = direction.Y - start.Y;
                float x = direction.X - start.X;

                if (x == 0f)
                    return 0;
                else
                    return y / x;
            }

            public static float B(float x, float y, float m)
            {
                return y - (m * x);
            }

            public static double DegreeToRadian(double degree)
            {
                return ((Math.PI / 180) * degree);
            }

            public static double RadianToDegree(double radian)
            {
                return radian / (Math.PI / 180);
            }


            /// <summary>
            /// Return the angle between vector p11 --> p12 and p21 --> p22.
            /// Angles less than zero are to the left. Angles greater than
            /// zero are to the right.
            /// </summary>
            public static double GetAngleInRadians(Vector2 Point1_Start, Vector2 Point1_End, Vector2 Point2_Start, Vector2 Pount2_End)
            {
                // Code thanks to: http://csharphelper.com/blog/2020/06/find-the-angle-between-two-vectors-in-c/

                // Find the vectors.
                Vector2 v1 = new Vector2(Point1_End.X - Point1_Start.X, Point1_End.Y - Point1_Start.Y);
                Vector2 v2 = new Vector2(Pount2_End.X - Point2_Start.X, Pount2_End.Y - Point2_Start.Y);

                // Calculate the vector lengths.
                double len1 = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y);
                double len2 = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y);

                // Use the dot product to get the cosine.
                double dot_product = v1.X * v2.X + v1.Y * v2.Y;
                double cos = dot_product / len1 / len2;

                // Use the cross product to get the sine.
                double cross_product = v1.X * v2.Y - v1.Y * v2.X;
                double sin = cross_product / len1 / len2;

                // Find the angle.
                double angle = Math.Acos(cos);

                if (sin < 0) angle = -angle;
                return angle;
            }


            public static double GetAngleInRadians(Vector2 Point1, Vector2 Point2)
            {

                double angle = GetAngleInRadians(
                    Point1_Start: Point1,
                    Point1_End: Point2,
                    Point2_Start: Point1,
                    Pount2_End: new Vector2(Point1.X, Point1.Y + Math.Abs(Point2.Y - Point1.Y))
                ); ;

                return angle;
            }




            public class Pitagoras
            {
                public static double r(double x, double y)
                {
                    // r = (x^2 + y^2)^(1/2)
                    return Math.Sqrt((x * x) + (y * y));
                }

                public static double y(double r, double x)
                {
                    // y = (r^2 - x^2)^(1/2)
                    return (float)Math.Sqrt((r * r) - (x * x));
                }

                public static double x(double r, double y)
                {
                    // x = (r^2 - y^2)^(1/2)
                    return Math.Sqrt((r * r) - (y * y));
                }
            }

            [Obsolete("Obsolete. \"Use Microsoft.Xna.Framework.MathHelper.Clamp\" or \"System.Math.Clamp\" instead.", error: true)]
            public static int Clamp(int Min, int Max, int Number)
            {
                if (Number <= Min) return Min;
                if (Number >= Max) return Max;
                return Number;
            }
        }

        public class GetRectangle
        {
            public static Rectangle Rectangle(Vector2 centerPosition, int Width, int Height)
            {
                Rectangle rectangle = new Rectangle(
                    x: (int)(centerPosition.X - (Width / 2)),
                    y: (int)(centerPosition.Y - (Height / 2)),
                    width: Width,
                    height: Height
                );

                return rectangle;
            }

            public static Rectangle Rectangle(Vector2 centerPosition, Texture2D texture2D)
            {
                return Rectangle(centerPosition, texture2D.Width, texture2D.Height);
            }

            public static Rectangle Up(Rectangle mainRectangle, int scaleFactor)
            {
                Rectangle rectangleUp = new Rectangle(
                    x: mainRectangle.X,
                    y: mainRectangle.Y - scaleFactor,
                    width: mainRectangle.Width,
                    height: scaleFactor
                );

                return rectangleUp;
            }

            public static Rectangle Down(Rectangle mainRectangle, int scaleFactor)
            {
                Rectangle rectangleDown = new Rectangle(
                    x: mainRectangle.X,
                    y: mainRectangle.Bottom,
                    width: mainRectangle.Width,
                    height: scaleFactor
                );

                return rectangleDown;
            }

            public static Rectangle Left(Rectangle mainRectangle, int scaleFactor)
            {
                Rectangle rectangleLeft = new Rectangle(
                    x: mainRectangle.X - scaleFactor,
                    y: mainRectangle.Y,
                    width: scaleFactor,
                    height: mainRectangle.Height
                );

                return rectangleLeft;
            }

            public static Rectangle Right(Rectangle mainRectangle, int scaleFactor)
            {
                Rectangle rectangleRight = new Rectangle(
                    x: mainRectangle.Right,
                    y: mainRectangle.Y,
                    width: scaleFactor,
                    height: mainRectangle.Height
                );

                return rectangleRight;
            }
        }

        public class Other
        {
            /// <summary>
            /// Get next new position base on a step
            /// </summary>
            /// <param name="mainRigidbody"></param>
            /// <param name="targetRigidbody"></param>
            /// <param name="maxAproximation"></param>
            /// <param name="steps"></param>
            /// <returns>New position</returns>
            public static Vector2 MoveTowards(Rigidbody mainRigidbody, Rigidbody targetRigidbody, int maxAproximation, int steps)
            {
                Vector2 mainPoint = mainRigidbody.centerPosition;
                Vector2 endPoint = targetRigidbody.centerPosition;

                Vector2 result = mainPoint;

                // target is right
                if (endPoint.X - mainPoint.X >= 0)
                {
                    // is up
                    if (endPoint.Y - mainPoint.Y <= 0)
                    {
                        int r = steps;
                        double angleRad = Tools.MyMath.GetAngleInRadians(mainPoint, endPoint);
                        double y = r * Math.Cos(angleRad);
                        double x = Tools.MyMath.Pitagoras.x(r, y);

                        result.Y += (float)y;
                        result.X += (float)x;
                    }
                    // is down
                    else if (endPoint.Y - mainPoint.Y >= 0)
                    {
                        int r = steps;
                        double angleRad = Tools.MyMath.GetAngleInRadians(mainPoint, endPoint);
                        double y = r * Math.Cos(angleRad);
                        double x = Tools.MyMath.Pitagoras.x(r, y);

                        result.Y += (float)y;
                        result.X += (float)x;
                    }
                }
                // target is left
                else if (endPoint.X - mainPoint.X < 0)
                {
                    // is up
                    if (endPoint.Y - mainPoint.Y <= 0)
                    {
                        int r = steps;
                        double angleRad = Tools.MyMath.GetAngleInRadians(mainPoint, endPoint);
                        double y = r * Math.Cos(angleRad);
                        double x = Tools.MyMath.Pitagoras.x(r, y);

                        result.Y += (float)y;
                        result.X -= (float)x;
                    }
                    // is down
                    else if (endPoint.Y - mainPoint.Y >= 0)
                    {
                        int r = steps;
                        double angleRad = Tools.MyMath.GetAngleInRadians(mainPoint, endPoint);
                        double y = r * Math.Cos(angleRad);
                        double x = Tools.MyMath.Pitagoras.x(r, y);

                        result.Y += (float)y;
                        result.X -= (float)x;
                    }
                }

                // Return
                return result;
            }
        }
    }
}