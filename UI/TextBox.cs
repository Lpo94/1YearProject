using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1YearProject.Components;
using _1YearProject.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace _1YearProject.UI
{
    class TextBox : Component,IUpdate,IDraw,ILoad
    {
        private Rectangle textBox;
        private Texture2D notClickedTex;
        private Texture2D clickedTex;


        private string myText = "";
        private bool clicked;
        private SpriteFont font;
        private List<string> myTextList;
        private float delay = 200;
        float timer = GameWorld.Instance.deltaTime;

        float height;
        float length;
        Vector2 pos;

        public bool Clicked
        {
            get { return clicked;  }
            set { clicked = value; }
        }

        public TextBox(GameObject gameObject, float length, float height, Vector2 pos) : base(gameObject)
        {
            this.length = length;
            this.height = height;
            this.pos = pos;
        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("font");
            textBox = new Rectangle((int)pos.X, (int)pos.Y, (int)length, (int)height);
            notClickedTex = content.Load<Texture2D>("Textbox");
            clickedTex = content.Load<Texture2D>("Textboxtar");
            myTextList = new List<string>();

        }

        public void Update()
        {
            if (textBox.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                clicked = true;
            }
            else if(!textBox.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Pressed) { clicked = false; }

            var timer = (float)GameWorld.Instance.deltaTime;

            if (delay > 0)
            {
                delay -= timer;
            }           

            if (clicked == true && delay < 0)
            {
                AddToString();
            }


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(clicked == false)
            {
                spriteBatch.Draw(notClickedTex, textBox, Color.White);
            }
            else
            {
                spriteBatch.Draw(clickedTex, textBox, Color.White);
            }
            spriteBatch.DrawString(font, myText, new Vector2(textBox.X+10, textBox.Y+5), Color.Black);

        }

        private void AddToString()
        {
            string h = KeyboardInput.Instance.Input();


            if (h != null)
            {
                switch (h.ToLower())
                {
                    case "backspace":
                        if (myText.Length - 1 >= 0)
                        {
                            myText = myText.Remove(myText.Length - 1);
                            delay = 200;
                        }
                        break;
                    case "enter":
                        clicked = false;
                        break;
                    case "":
                        break;

                    case " ":
                        break;
                    default:
                        if (myText.Length < 19)
                        {
                            myText += h;
                            delay = 200;
                        }
                        break;
                }
            }

            h = "";
            

        }
    }
}
