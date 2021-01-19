
namespace Shared
{
    public class WK
    {
        public class Default
        {
            public const int CanvasWidth = 300;
            public const int CanvasHeight = 300;

            public static readonly char[,] FontChars = new char[,]
            {
                { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' },
                { ',', ':', ';', '?', '.', '!', ' ','\'','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' }
            };
        }

        public class Scene
        {
            public const string Intro = "Intro";
            public const string Menu = "Menu";
            public const string About = "About";
            public const string Scene1 = "Scene1";
        }

        public class Font
        {
            public const string MyFont = "MyFont";
        }

        public class Image
        {
            //public const string MyFont_5x7_PNG = "MyFont_PNG_130x28";
            public const string MyFont_10x14_PNG = "MyFont_PNG_260x56";

            public const string Intro_300_300_PNG = "Intro_300_300_PNG";
            public const string Menu_300_300_PNG = "Menu_300_300_PNG";

            public class PlayButton
            {
                public const string Default = "Play1_100x50_PNG";
                public const string MouseOver = "Play2_100x50_PNG";
            }

            public class AboutButton
            {
                public const string Default = "About1_100x50_PNG";
                public const string MouseOver = "About2_100x50_PNG";
            }

            public class MenuButton
            {
                public const string Default = "Menu1_100x50_PNG";
                public const string MouseOver = "Menu2_100x50_PNG";
            }

            public const string Snake_10x10_PNG = "Snake_10x10_PNG";

            public const string Coin_10x10_PNG = "Coin_10x10_PNG";
        }
    }
}
