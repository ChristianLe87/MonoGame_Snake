using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Intro : IScene
    {
        Rectangle rectangle;
        Texture2D texture;

        public Intro()
        {
            this.rectangle = new Rectangle(0, 0, 300, 300);
            this.texture = Tools.GetImageFromPipeline(WK.Image.Intro_300_300_PNG);
            Game1.isMouseVisible = false;
        }

        public void Update(GameTime gameTime)
        {
            // wait 2 seconds
            if (gameTime.TotalGameTime.Seconds > 2) { Game1.actualScene = WK.Scene.Menu; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

    }
}
