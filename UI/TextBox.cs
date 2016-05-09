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
        private Texture2D debugColor;

        private string myText = "";
        private bool clicked = true;
        private Keys[] currentKeys;
        private SpriteFont font;
        private Transform transform;
        private Animator animator;

        String parsedText;
        String typedText = "";
        double typedTextLength;
        int delayInMilliseconds;
        bool isDoneDrawing;

        public bool Clicked
        {
            get { return clicked;  }
            set { clicked = value; }
        }

        public TextBox(GameObject gameObject) : base(gameObject)
        {
            this.animator = (Animator)GameObject.GetComponent("Animator");
        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("font");
            textBox = new Rectangle(10, 10, 100, 100);
            debugColor = content.Load<Texture2D>("Textbox");
            myText = "Hello World thasdasd asd asdasdas jdasodasklck amskdamkds asd";

            parsedText = parseText(myText);
            delayInMilliseconds = 50;
            isDoneDrawing = false;
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            currentKeys = keyState.GetPressedKeys();


            if (clicked == true)
            {
                foreach (Keys k in currentKeys)
                {
                    switch (k)
                    {
                        case Keys.Back:
                            myText = "";
                            break;

                        default:
                            myText += k;
                            break;
                    }

                }
            }
            if (!isDoneDrawing)
            {
                if (delayInMilliseconds == 0)
                {
                    typedText = parsedText;
                    isDoneDrawing = true;
                }
                else if (typedTextLength < parsedText.Length)
                {
                    typedTextLength = typedTextLength + GameWorld.Instance.deltaTime / delayInMilliseconds;

                    if (typedTextLength >= parsedText.Length)
                    {
                        typedTextLength = parsedText.Length;
                        isDoneDrawing = true;
                    }

                    typedText = parsedText.Substring(0, (int)typedTextLength);
                }

            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(debugColor, textBox, Color.White);
            spriteBatch.DrawString(font, typedText, new Vector2(textBox.X, textBox.Y), Color.White);

        }

        private String parseText(String text)
        {
            String line = String.Empty;
            String returnString = String.Empty;
            String[] wordArray = text.Split(' ');

            foreach (String word in wordArray)
            {
                if (font.MeasureString(line + word).Length() > textBox.Width)
                {
                    returnString = returnString + line + '\n';
                    line = String.Empty;
                }

                line = line + word + ' ';
            }

            return returnString + line;
        }
    }
}
