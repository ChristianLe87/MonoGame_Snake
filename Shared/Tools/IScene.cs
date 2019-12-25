using System;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IScene
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
