using System;

namespace Snake_MultiPlatform
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            using (var game = new Shared.Game1())
            {
                game.Run();
            }
        }
    }
}
