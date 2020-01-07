using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Button
    {
        Rectangle rectangle;
        Texture2D defaultTexture;
        Texture2D mouseOverTexture;
        MouseState previousMouseState;
        bool isMouseOver = false;
        Text text;

        public delegate void DxOnClickAction();

        public Button(Rectangle rectangle, Color defaultColor, Color mouseOverColor)
        {
            this.rectangle = rectangle;
            this.defaultTexture = Tools.CreateColorTexture(defaultColor);
            this.mouseOverTexture = Tools.CreateColorTexture(mouseOverColor);
            this.text = new Text(WK.Font.MyFont, new Vector2(rectangle.X, rectangle.Y));
        }

        public void Update(DxOnClickAction OnClickAction, string text)
        {
            MouseState mouseState = Mouse.GetState();

            this.text.Update(text);

            if (rectangle.Contains(mouseState.X, mouseState.Y))
            {
                isMouseOver = true;
                if (previousMouseState.LeftButton == ButtonState.Released
                    &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    OnClickAction();
                }
            }
            else
            {
                isMouseOver = false;
            }

            previousMouseState = Mouse.GetState();
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (isMouseOver)
                spriteBatch.Draw(mouseOverTexture, rectangle, Color.White);
            else
                spriteBatch.Draw(defaultTexture, rectangle, Color.White);


            this.text.Draw(spriteBatch, Color.Black);

        }
    }
}