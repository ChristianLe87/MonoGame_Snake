using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Snake
    {
        Texture2D texture;
        public List<Body> bodies;
        int frameCount;

        public Snake()
        {
            this.texture = Tools.GetImageFromPipeline(WK.Image.Snake_10x10_PNG);//.CreateColorTexture(Color.White);

            bodies = new List<Body>();

            SnakeTools.AddBody(new Vector2(10, 10), "r", bodies, texture);
            SnakeTools.AddBody(new Vector2(20, 10), "r", bodies, texture);
            SnakeTools.AddBody(new Vector2(30, 10), "r", bodies, texture);
            SnakeTools.AddBody(new Vector2(40, 10), "r", bodies, texture);

            this.frameCount = 0;
        }


        public void Update()
        {

            if (IsInsideGame() == true && GetIfColideItself() == true)
            {
                KeyboardState keyboardState = Keyboard.GetState();


                frameCount++;

                // player control move
                SnakeTools.UpdateDirection(keyboardState, bodies);


                // each 5 frames, move snake
                if (frameCount > 5)
                {
                    SnakeTools.MoveTaleToHead(bodies, texture);
                    frameCount = 0;
                }

                // check if snake get coin
                if (GetHeadRectangle().Intersects(Scene1.coin.GetRectangle()))
                {
                    Scene1.coin.ChangePosition();
                    AddBody();
                    Scene1.scoreVal++;
                }
            }
            else
            {
                Scene1.isGameOver = true;
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
                snakeHead.position.X > (Game1.canvasWidth - 10) ||
                snakeHead.position.Y > (Game1.canvasHeight - 10) ||
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

        public void AddBody()
        {
            SnakeTools.AddBody(SnakeTools.CalculateNextPosition(bodies[bodies.Count - 1].position, bodies[bodies.Count - 1].direction), bodies[bodies.Count - 1].direction, bodies, texture);
            SnakeTools.AddBody(SnakeTools.CalculateNextPosition(bodies[bodies.Count - 1].position, bodies[bodies.Count - 1].direction), bodies[bodies.Count - 1].direction, bodies, texture);
            SnakeTools.AddBody(SnakeTools.CalculateNextPosition(bodies[bodies.Count - 1].position, bodies[bodies.Count - 1].direction), bodies[bodies.Count - 1].direction, bodies, texture);
        }
    }

    internal class SnakeTools
    {
        public static void AddBody(Vector2 position, string direction, List<Body> bodies, Texture2D texture)
        {
            Body body = new Body(position, texture, direction);
            bodies.Add(body);
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

        public static void MoveTaleToHead(List<Body> bodies, Texture2D texture)
        {
            // insert first element that at the end of the list
            Body head = bodies[bodies.Count - 1];
            Vector2 headNextPosition = SnakeTools.CalculateNextPosition(new Vector2(head.position.X, head.position.Y), head.direction);
            Body newElement = new Body(headNextPosition, texture, head.direction);
            bodies.Add(newElement);

            // delete body[0]
            bodies.RemoveAt(0);
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
    }


    public class Body
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
            this.rectangle = new Rectangle((int)vector2.X, (int)vector2.Y, /*texture2D.Width*/10, /*texture2D.Height*/10);
        }
    }
}
