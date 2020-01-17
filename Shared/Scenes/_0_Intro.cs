using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class _0_Intro : IScene
    {
        Rectangle rectangle;
        Texture2D texture;

        long startTime;


        public _0_Intro()
        {
            this.rectangle = new Rectangle(0, 0, 300, 300);
            this.texture = Tools.GetImageFromPipeline(WK.Image._0_Intro);
            this.startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Game1.isMouseVisible = false;
        }

        public void Update()
        {

            long timeNow = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            // wait 3 seconds
            if ((timeNow - startTime) > (3 * 1000)) { Game1.actualScene = new _1_Menu(); }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

    }
}
