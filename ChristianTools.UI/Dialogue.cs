using System.Linq;
using ChristianTools.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChristianTools.UI
{
    public class Dialogue : IUI
    {
        Texture2D background;
        Point centerPosition;
        Label[] labels;
        int labelCount;
        bool isActive;
        InputState previousinputState;

        Rectangle rectangle { get => new Rectangle(centerPosition.X - (background.Width / 2), centerPosition.Y - (background.Height / 2), background.Width, background.Height); }

        public Dialogue(string[] texts, Point centerPosition, Texture2D background, SpriteFont spriteFont, bool isActive = true)
        {
            this.background = background;
            this.centerPosition = centerPosition;
            this.labelCount = 0;
            this.isActive = isActive;
            this.labels = texts.Select(text => new Label(rectangle, spriteFont, text, Label.TextAlignment.Midle_Left, Color.Pink)).ToArray();
        }

        public void Update()
        {
            if (isActive == false)
                return;

            InputState inputState = new InputState();
            if (inputState.IsKeyboardKeyDown(Keys.P) && previousinputState.IsKeyboardKeyUp(Keys.P))
            {
                labelCount++;

                if (labelCount >= labels.Length)
                {
                    isActive = false;
                    labelCount = 0;
                }
            }

            previousinputState = inputState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive == false) return;

            spriteBatch.Draw(background, rectangle, Color.White);
            labels[labelCount].Draw(spriteBatch);
        }

        public void SetActiveState(bool isActive)
        {
            this.isActive = isActive;
        }
    }
}