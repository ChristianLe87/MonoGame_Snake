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

        public delegate void DxOnClickAction();

        public Button(Rectangle rectangle, Color defaultColor, Color mouseOverColor)
        {
            this.rectangle = rectangle;
            this.defaultTexture = Tools.CreateColorTexture(defaultColor);
            this.mouseOverTexture = Tools.CreateColorTexture(mouseOverColor);
        }

        public void Update(DxOnClickAction OnClickAction)
        {
            MouseState mouseState = Mouse.GetState();

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
        }
    }
}