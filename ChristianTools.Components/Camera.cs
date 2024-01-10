using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Camera
    {
        public Matrix transform;
        public Viewport viewport;
        public Vector2 center;
        public int zoom = 1;

        public Camera(Viewport viewport)
        {
            this.viewport = viewport;
        }

        public void Update(Vector2 targetPosition)
        {
            center = new Vector2(
                targetPosition.X - viewport.Width / 2,
                targetPosition.Y - viewport.Height / 2);
            transform = Matrix.CreateScale(new Vector3(zoom, zoom, 0)) * Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }
    }
}
