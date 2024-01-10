using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Components
{
    public class Animation
    {
        Dictionary<CharacterState, Texture2D[]> animations;
        int animationFrameCount;

        public Animation(Dictionary<CharacterState, Texture2D[]> animations)
        {
            this.animations = animations;
            this.animationFrameCount = 0;
        }
        public void Update()
        {
            animationFrameCount++;
        }

        public Texture2D GetTexture(CharacterState characterState)
        {
            int framesPerTexture = 16;

            if (animationFrameCount > framesPerTexture)
                animationFrameCount = 0;

            int element = animationFrameCount < framesPerTexture / 2 ? 0 : 1;

            if (animations[characterState].Length == 1)
                return animations[characterState][0];
            else
                return animations[characterState][element];
        }

        public enum CharacterState
        {
            IdleRight,
            IdleLeft,
            WalkRight,
            WalkLeft,
            JumpRight,
            JumpLeft,
            HangRight,
            HangLeft,
            ShootRight,
            ShootLeft,
        }
    }
}