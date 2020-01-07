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

        Text title;

        public _0_Intro()
        {
            this.rectangle = new Rectangle(0, 0, 300, 300);
            this.texture = Tools.CreateColorTexture(Color.Black);
            this.startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            this.title = new Text(WK.Font.MyFont, new Vector2(100, 100), "Amazing Snake");
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
            title.Draw(spriteBatch, Color.White);
        }

    }
}
