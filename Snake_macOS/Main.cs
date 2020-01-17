using AppKit;

namespace Snake_macOS
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();

            string relativePath = "../../../../../../Shared/Content/bin";
            using (var game = new Shared.Game1(relativePath))
            {
                game.Run();
            }
        }
    }

}
