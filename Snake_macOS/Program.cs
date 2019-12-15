using System;

namespace Snake_macOS
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
