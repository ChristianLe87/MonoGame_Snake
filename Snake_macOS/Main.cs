using AppKit;

namespace Snake_macOS
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();

            using (var game = new proyecto_Compartido.Game2())
            {
                game.Run();
            }
        }
    }

}
