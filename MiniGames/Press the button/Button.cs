using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using _1YearProject.Interfaces;
using _1YearProject.Components;
using Microsoft.Xna.Framework.Graphics;

namespace _1YearProject
{
    class Button : Component, ILoad, IUpdate, IDraw
    {
        private Random r = new Random();
        private float timer = 3000;
        private Animator animator;
        private Transform transform;
        private string letter;
        private string answer = "";
        private int rNumber;
        private SpriteFont font;

        public Button(GameObject gameObject, Vector2 startPos) : base(gameObject)
        {
            transform = gameObject.GetTransform;
            transform.Position = startPos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "press the letter:" + letter, new Vector2(500, 500), Color.Black);
            spriteBatch.DrawString(font, answer, new Vector2(500, 530), Color.Black);
            spriteBatch.DrawString(font, "Required points to win: " + MiniGames.Points, new Vector2(450, 5), Color.Black);
            spriteBatch.DrawString(font, "Points: " + MiniGames.Points, new Vector2(50, 5), Color.Black);
        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("font");
            animator = (Animator)gameObject.GetComponent("Animator");
            CreateAnimations();
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (timer <= 0)
            {
                
                rNumber = r.Next(1, 9);

                if(rNumber == 1)
                {
                    letter = "a";
                    timer = 1500;
                }
                else if (rNumber == 2)
                {
                    letter = "s";
                    timer = 1500;
                }
                else if (rNumber == 3)
                {
                    letter = "d";
                    timer = 1500;
                }
                else if (rNumber == 4)
                {
                    letter = "f";
                    timer = 1500;
                }
                else if (rNumber == 5)
                {
                    letter = "g";
                    timer = 1500;
                }
                else if (rNumber == 6)
                {
                    letter = "h";
                    timer = 1500;
                }
                else if (rNumber == 7)
                {
                    letter = "j";
                    timer = 1500;
                }
                else if (rNumber == 8)
                {
                    letter = "k";
                    timer = 1500;
                }
                else if (rNumber == 9)
                {
                    letter = "l";
                    timer = 1500;
                }
            }
            
            if(keyState.IsKeyDown(Keys.A) && letter == "a")
            {
                MiniGames.Points += 1;
                letter = "";
                answer = "Correct!";
            }
            else if (keyState.IsKeyDown(Keys.A) && letter != "a" && letter != "")
            {
                MiniGames.Points -= 1;
                letter = "";
                answer = "Wrong!";
            }
            if (keyState.IsKeyDown(Keys.S) && letter == "s")
            {
                MiniGames.Points += 1;
                letter = "";
                answer = "Correct!";
            }
            else if (keyState.IsKeyDown(Keys.S) && letter != "s" && letter != "")
            {
                MiniGames.Points -= 1;
                letter = "";
                answer = "Wrong!";
            }
            if (keyState.IsKeyDown(Keys.D) && letter == "d")
            {
                MiniGames.Points += 1;
                letter = "";
                answer = "Correct!";
            }
            else if (keyState.IsKeyDown(Keys.D) && letter != "d" && letter != "")
            {
                MiniGames.Points -= 1;
                letter = "";
                answer = "Wrong!";
            }
            if (keyState.IsKeyDown(Keys.F) && letter == "f")
            {
                MiniGames.Points += 1;
                letter = "";
                answer = "Correct!";
            }
            else if (keyState.IsKeyDown(Keys.F) && letter != "f" && letter != "")
            {
                MiniGames.Points -= 1;
                letter = "";
                answer = "Wrong!";
            }
            if (keyState.IsKeyDown(Keys.G) && letter == "g")
            {
                MiniGames.Points += 1;
                letter = "";
                answer = "Correct!";
            }
            else if (keyState.IsKeyDown(Keys.G) && letter != "g" && letter != "")
            {
                MiniGames.Points -= 1;
                letter = "";
                answer = "Wrong!";
            }
            if (keyState.IsKeyDown(Keys.H) && letter == "h")
            {
                MiniGames.Points += 1;
                letter = "";
                answer = "Correct!";
            }
            else if (keyState.IsKeyDown(Keys.H) && letter != "h" && letter != "")
            {
                MiniGames.Points -= 1;
                letter = "";
                answer = "Wrong!";
            }
            if (keyState.IsKeyDown(Keys.J) && letter == "j")
            {
                MiniGames.Points += 1;
                letter = "";
                answer = "Correct!";
            }
            else if (keyState.IsKeyDown(Keys.J) && letter != "j" && letter != "")
            {
                MiniGames.Points -= 1;
                letter = "";
                answer = "Wrong!";
            }
            if (keyState.IsKeyDown(Keys.K) && letter == "k")
            {
                MiniGames.Points += 1;
                letter = "";
                answer = "Correct!";
            }
            else if (keyState.IsKeyDown(Keys.K) && letter != "k" && letter != "")
            {
                MiniGames.Points -= 1;
                letter = "";
                answer = "Wrong!";
            }
            if (keyState.IsKeyDown(Keys.L) && letter == "l")
            {
                MiniGames.Points += 1;
                letter = "";
                answer = "Correct!";
            }
            else if (keyState.IsKeyDown(Keys.L) && letter != "l" && letter != "")
            {
                MiniGames.Points -= 1;
                letter = "";
                answer = "Wrong!";
            }
            timer -= GameWorld.Instance.deltaTime;
        }

        public void CreateAnimations()
        {
            animator.CreateAnimation("static", new Animation(1, 0, 0, 50, 36, 6, Vector2.Zero));
            animator.PlayAnimation("static");
        }
    }
}
