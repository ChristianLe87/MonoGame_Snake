using System;
using Shared;

namespace MultiPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new Game1())
            {
                game.Run();
            }
        }
    }
}
