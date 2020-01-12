using System;
namespace Shared
{
    public class WK
    {
        public class Scene
        {
            public const string Level_1 = "Level_1";
            public const string About = "About";
            public const string Menu = "Menu";
        }

        public class Font
        {
            public const string MyFont = "MyFont";
        }

        public class Image
        {
            public const string _0_Intro = "PNGs/_0_Intro";
            public const string _1_Menu = "PNGs/_1_Menu";

            public class PlayButton
            {
                public const string Default = "PNGs/Play/Play1_100x50";
                public const string MouseOver = "PNGs/Play/Play2_100x50";
            }

            public class AboutButton
            {
                public const string Default = "PNGs/About/About1_100x50";
                public const string MouseOver = "PNGs/About/About2_100x50";
            }

            public class MenuButton
            {
                public const string Default = "PNGs/Menu/Menu1_100x50";
                public const string MouseOver = "PNGs/Menu/Menu2_100x50";
            }

            public const string Snake_10_10 = "PNGs/Snake_10x10";
        }
    }
}
