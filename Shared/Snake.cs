using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Snake
    {
        Texture2D texture;
        List<Body> bodies = new List<Body>();
        int frameCount = 0;


        public Snake(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Snake_10_10");

            Tools.AddBody(new Vector2(10, 10), "r", bodies, texture);
            Tools.AddBody(new Vector2(20, 10), "r", bodies, texture);
            Tools.AddBody(new Vector2(30, 10), "r", bodies, texture);
            Tools.AddBody(new Vector2(40, 10), "r", bodies, texture);
        }


        public void Update(KeyboardState keyboard)
        {
            frameCount++;

            // player control move
            Tools.UpdateDirection(keyboard, bodies);


            // each 5 frames, move snake
            if (frameCount > 5)
            {
                Tools.MoveTaleToHead(bodies, texture);
                frameCount = 0;
            }
        }


        public bool GetIfColideItself()
        {
            var snakeHead = bodies[bodies.Count - 1];

            List<bool> result = bodies
                .Select(x => x.position == snakeHead.position)
                .Where(x => x == true)
                .ToList();

            if (result.Count > 1)
                return false;
            else
                return true;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var i in bodies)
            {
                spriteBatch.Draw(i.texture2D, i.rectangle, Color.White);
            }
        }


        public Rectangle GetHeadRectangle()
        {
            return bodies[bodies.Count - 1].rectangle;
        }


        internal bool IsInsideGame()
        {
            var snakeHead = bodies[bodies.Count - 1];

            if (
                snakeHead.position.X > 290 ||
                snakeHead.position.Y > 290 ||
                snakeHead.position.X < 0 ||
                snakeHead.position.Y < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal void AddBody()
        {
            Tools.AddBody(Tools.CalculateNextPosition(bodies[bodies.Count - 1].position, bodies[bodies.Count - 1].direction), bodies[bodies.Count - 1].direction, bodies, texture);
            Tools.AddBody(Tools.CalculateNextPosition(bodies[bodies.Count - 1].position, bodies[bodies.Count - 1].direction), bodies[bodies.Count - 1].direction, bodies, texture);
            Tools.AddBody(Tools.CalculateNextPosition(bodies[bodies.Count - 1].position, bodies[bodies.Count - 1].direction), bodies[bodies.Count - 1].direction, bodies, texture);
        }

        internal void Reset()
        {
            bodies = new List<Body>() { };
            Tools.AddBody(new Vector2(10, 10), "r", bodies, texture);
            Tools.AddBody(new Vector2(20, 10), "r", bodies, texture);
            Tools.AddBody(new Vector2(30, 10), "r", bodies, texture);
            Tools.AddBody(new Vector2(40, 10), "r", bodies, texture);
        }
    }


    internal class Body
    {
        public Rectangle rectangle { get; set; }
        public Vector2 position { get; set; }
        public Texture2D texture2D { get; }
        public string direction { get; set; }

        public Body(Vector2 vector2, Texture2D texture2D, string direction)
        {
            this.position = vector2;
            this.texture2D = texture2D;
            this.direction = direction;
            this.rectangle = new Rectangle((int)vector2.X, (int)vector2.Y, texture2D.Width, texture2D.Height);
        }
    }
}
