﻿using System;

namespace Snake_Universal
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            using (var game = new proyecto_Compartido.Game2())
            {
                game.Run();
            }
        }
    }
}
