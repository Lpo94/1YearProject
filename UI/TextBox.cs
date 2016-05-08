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
        private string myText;
        private bool clicked = true;
        private Keys[] currentKeys;
        private SpriteFont font;
        private Transform transform;
        private Animator animator;

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
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            currentKeys = keyState.GetPressedKeys();


            if (clicked == true)
            {
                foreach (Keys k in currentKeys)
                {
                    switch(k)
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

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, myText, new Vector2(100, 100), Color.Black);
        }
    }
}
