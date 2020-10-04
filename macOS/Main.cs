using System;
using System.Reflection;
using AppKit;
using Shared;

namespace macOS
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            //NSApplication.Init();
            //NSApplication.Main(args);

            using (var game = new Game1())
            {
                game.Run();
            }
        }
    }
}
