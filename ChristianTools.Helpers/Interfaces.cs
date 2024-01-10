using System.Collections.Generic;
using ChristianTools.Components;
using Microsoft.Xna.Framework.Graphics;

namespace ChristianTools.Helpers
{
    public interface IEntity
    {
        public Rigidbody rigidbody { get; }
        public bool isActive { get; }
        public string tag { get; }
        public int health { get; }
        public void Update(InputState lastInputState, InputState inputState);
        public void Draw(SpriteBatch spriteBatch);
    }

    public interface IScene
    {
        //public IEntity player { get; set; }
        public GameState gameState { get; }
        public List<IEntity> entities { get; set; }
        public List<IUI> UIs { get; set; }
        //public List<IParticles> particles { get; set; }
        public Camera camera { get; }
        public Map map { get; }
        public void Initialize();
        public void Update(InputState lastInputState, InputState inputState);
        public void Draw(SpriteBatch spriteBatch);
    }

    /*public interface IParticles
    {
    }*/


    public interface IUI
    {
        public void Draw(SpriteBatch spriteBatch);
    }

    public interface ILanguage
    {
        public string GameWindowTitle { get; }

        public string Button_GoToMenu { get; }
        public string Button_GoToSetup { get; }
    }
}
