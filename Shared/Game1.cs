using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Score score;
        GameOver gameOver;
        Snake snake;
        DB dB;
        Coin coin;

        bool Continue = true;
        bool dataSaved = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            string localPath = "../../../../MonoGame_Snake/Content/bin/";
            DirectoryInfo directory = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, localPath)));
            Content.RootDirectory = directory.ToString();

            //Content.RootDirectory = "/Users/christianlehnhoff/Repositorios/GitHub/MonoGame_Snake/Content/bin";
            graphics.PreferredBackBufferWidth = 300;
            graphics.PreferredBackBufferHeight = 300;
        }


        protected override void Initialize()
        {
            snake = new Snake(Content);
            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            coin = new Coin(Content, new Vector2(50, 50));
            score = new Score(Content, new Vector2(10, 10));
            gameOver = new GameOver(Content, new Vector2(108, 130));
            dB = new DB("databaseFile", "MyTable");
            dB.InsertRowIntoDB(DateTime.Now.ToString(), "0");
        }


        protected override void Update(GameTime gameTime)
        {

            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            if (Continue)
            {

                snake.Update(Keyboard.GetState());


                // Check if touch coin
                if (snake.GetHeadRectangle().Intersects(coin.GetRectangle()))
                {
                    Random random = new Random();
                    coin.ChangePosition(new Vector2((random.Next(30) * 10), (random.Next(30) * 10)));
                    score.AddScore();
                    snake.AddBody();
                }


                // check if auto colide
                Continue = snake.GetIfColideItself();


                // Check position
                // if position outside the game: continue = false
                Continue = snake.IsInsideGame();

            }
            else if ((dataSaved == false) && (Continue == false))
            {
                dB.InsertRowIntoDB(DateTime.Now.ToString(), score.GetScore().ToString());
                dataSaved = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                score.ResetScore();
                snake.Reset();
                Continue = true;
                dataSaved = false;
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {


            graphics.GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            score.Draw(spriteBatch);
            snake.Draw(spriteBatch);
            coin.Draw(spriteBatch);
            if (Continue == false)
            {
                var bla = dB.GetAllDataFromDB();
                List<int> topScore = new List<int>();
                foreach (var i in bla)
                {
                    topScore.Add(i.Value);
                }
                topScore.Sort();
                gameOver.Draw(spriteBatch, topScore[topScore.Count - 1]);
            }

            spriteBatch.End();


            base.Draw(gameTime);
        }

    }
}