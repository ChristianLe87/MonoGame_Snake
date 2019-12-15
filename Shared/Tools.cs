using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    internal static class Tools
    {
        public static void AddBody(Vector2 position, string direction, List<Body> bodies, Texture2D texture)
        {
            Body body = new Body(position, texture, direction);
            bodies.Add(body);
        }


        public static Vector2 CalculateNextPosition(Vector2 oldPosition, string direction)
        {
            float x = oldPosition.X;
            float y = oldPosition.Y;

            if (direction == "u")
                y -= 10;
            else if (direction == "d")
                y += 10;
            else if (direction == "r")
                x += 10;
            else if (direction == "l")
                x -= 10;

            return new Vector2(x, y);
        }


        public static void MoveTaleToHead(List<Body> bodies, Texture2D texture)
        {
            // insert first element that at the end of the list
            Body head = bodies[bodies.Count - 1];
            Vector2 headNextPosition = Tools.CalculateNextPosition(new Vector2(head.position.X, head.position.Y), head.direction);
            Body newElement = new Body(headNextPosition, texture, head.direction);
            bodies.Add(newElement);

            // delete body[0]
            bodies.RemoveAt(0);
        }


        public static void UpdateDirection(KeyboardState keyboard, List<Body> bodies)
        {
            foreach (var i in bodies)
            {
                if (keyboard.IsKeyDown(Keys.Left) && i.direction != "r")
                    i.direction = "l";
                else if (keyboard.IsKeyDown(Keys.Right) && i.direction != "l")
                    i.direction = "r";
                else if (keyboard.IsKeyDown(Keys.Up) && i.direction != "d")
                    i.direction = "u";
                else if (keyboard.IsKeyDown(Keys.Down) && i.direction != "u")
                    i.direction = "d";
            }
        }
    }
}
