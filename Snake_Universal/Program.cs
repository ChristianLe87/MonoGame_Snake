using System;

namespace Snake_Universal
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string relativePath = "../../../Shared/Content/bin";
            using (var game = new Shared.Game1(relativePath))
            {
                game.Run();
            }
        }
    }
}
