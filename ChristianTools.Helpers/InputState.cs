using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ChristianTools.Helpers
{
    public class InputState
    {
        KeyboardState keyboardState = Keyboard.GetState();
        GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
        MouseState mouseState = Mouse.GetState();

        // General
        public bool Right => keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right) || (gamePadState.ThumbSticks.Left.X > 0);
        public bool Left => keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left) || (gamePadState.ThumbSticks.Left.X < 0);
        public bool Up => keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up) || (gamePadState.ThumbSticks.Left.Y > 0);
        public bool Down => keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down) || (gamePadState.ThumbSticks.Left.Y < 0);

        /// <summary>
        /// keyboardState.IsKeyDown(Keys.Space) || gamePadState.IsButtonDown(Buttons.A);
        /// </summary>
        public bool Jump => keyboardState.IsKeyDown(Keys.Space) || gamePadState.IsButtonDown(Buttons.A);

        public bool NotJump => !(keyboardState.IsKeyDown(Keys.Space) || gamePadState.IsButtonDown(Buttons.A));
        public bool Action => keyboardState.IsKeyDown(Keys.Enter) || gamePadState.IsButtonDown(Buttons.X) || (mouseState.LeftButton == ButtonState.Pressed);

        // Keyboard
        public bool IsKeyboardKeyDown(Keys key) => keyboardState.IsKeyDown(key);
        public bool IsKeyboardKeyUp(Keys key) => keyboardState.IsKeyUp(key);

        // Gamepad
        public bool IsGamePadButtonDown(Buttons button) => gamePadState.IsButtonDown(button);
        public bool IsGamePadButtonUp(Buttons button) => gamePadState.IsButtonUp(button);

        // Mouse
        public Point Mouse_Position => mouseState.Position;
        public ButtonState Mouse_LeftButton => mouseState.LeftButton;
    }
}
