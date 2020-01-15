using AppKit;

namespace Snake_macOS
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();

            using (var game = new Shared.Game1())
            {
                game.Run();
            }
        }
    }

}
