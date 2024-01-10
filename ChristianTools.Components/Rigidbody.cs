using Microsoft.Xna.Framework;

namespace ChristianTools.Components
{
    public class Rigidbody
    {
        public Vector2 force { get; private set; }
        public Vector2 gravity { get; private set; }

        public Vector2 centerPosition { get; set; }

        public Rectangle rectangle { get => Tools.Tools.GetRectangle.Rectangle(centerPosition, Width, Height); }

        public Rectangle rectangleUp { get => Tools.Tools.GetRectangle.Up(rectangle, scaleFactor); }
        public Rectangle rectangleDown { get => Tools.Tools.GetRectangle.Down(rectangle, scaleFactor); }
        public Rectangle rectangleLeft { get => Tools.Tools.GetRectangle.Left(rectangle, scaleFactor); }
        public Rectangle rectangleRight { get => Tools.Tools.GetRectangle.Right(rectangle, scaleFactor); }

        int Width;
        int Height;

        int scaleFactor;
        public Rigidbody(Vector2 centerPosition, int Width, int Height, Vector2? gravity = null, Vector2? force = null, int scaleFactor = 0)
        {
            this.gravity = gravity == null ? Vector2.Zero : gravity.Value;
            this.force = force == null ? Vector2.Zero : force.Value;
            this.centerPosition = centerPosition;
            this.Width = Width;
            this.Height = Height;
            this.scaleFactor = scaleFactor;
        }

        public void Update()
        {
            // Force
            centerPosition += force;

            // Gravity
            centerPosition += gravity;
        }

        public void AddForce(Vector2 forceToAdd)
        {
            force += forceToAdd;
        }

        public void SetForce(Vector2 force)
        {
            this.force = force;
        }

        public void SetForce_X(float X)
        {
            this.force = new Vector2(X, force.Y);
        }

        public void SetForce_Y(float Y)
        {
            this.force = new Vector2(force.X, Y);
        }

        public void Move_X(float X)
        {
            centerPosition = new Vector2(centerPosition.X + X, centerPosition.Y);
        }

        public void Move_Y(float Y)
        {
            centerPosition = new Vector2(centerPosition.X, centerPosition.Y + Y);
        }
    }
}