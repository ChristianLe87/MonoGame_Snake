using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChristianTools.UI
{
    public class Button : IUI
    {
        Rectangle rectangle;
        Texture2D defaultTexture;
        Texture2D mouseOverTexture;
        InputState previousInputState;
        bool isMouseOver;
        Label label;
        public string ButtonID { get; private set; }

        public delegate void DxOnClickAction();

        public Button(Rectangle rectangle, string text, Texture2D defaultTexture, Texture2D mouseOverTexture, SpriteFont spriteFont, Color fontColor, string ButtonID)
        {
            this.rectangle = rectangle;
            this.defaultTexture = defaultTexture;
            this.mouseOverTexture = mouseOverTexture;
            this.isMouseOver = false;

            this.label = new Label(rectangle, spriteFont, text, Label.TextAlignment.Midle_Center, fontColor);

            this.ButtonID = ButtonID;
            this.previousInputState = new InputState();
        }

        public void Update(DxOnClickAction OnClickAction)
        {
            InputState inputState = new InputState();

            if (rectangle.Contains(inputState.Mouse_Position))
            {
                isMouseOver = true;
                if (previousInputState.Mouse_LeftButton == ButtonState.Released && inputState.Mouse_LeftButton == ButtonState.Pressed)
                {
                    OnClickAction();
                }
            }
            else
            {
                isMouseOver = false;
            }

            previousInputState = inputState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isMouseOver)
                spriteBatch.Draw(mouseOverTexture, rectangle, Color.White);
            else
                spriteBatch.Draw(defaultTexture, rectangle, Color.White);

            label.Draw(spriteBatch);
        }
    }
}