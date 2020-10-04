using System;
using Shared;

namespace MultiPlatform
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            using (var game = new Game1())
            {
                game.Run();
            }
        }
    }
}
