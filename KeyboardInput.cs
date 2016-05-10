using System.Text;
using System;
using System.Threading.Tasks;
using _1YearProject.Components;
using _1YearProject.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace _1YearProject
{
    class KeyboardInput
    {
        KeyboardState oldKey;
        static KeyboardInput instance;
        public static KeyboardInput Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KeyboardInput();
                }
                return instance;
            }
        }

        public string Input()
        {
            KeyboardState keyState = Keyboard.GetState(); 
            
            string input = "";

            if(keyState.IsKeyDown(Keys.Q))
            {
                if (oldKey != keyState)
                {
                    input = "Q";
                }
            }
            else if(keyState.IsKeyDown(Keys.W))
            {
                input = "W";
            }
            else if (keyState.IsKeyDown(Keys.E))
            {
                input = "E";
            }
            else if (keyState.IsKeyDown(Keys.R))
            {
                input = "R";
            }
            else if (keyState.IsKeyDown(Keys.T))
            {
                input = "T";
            }
            else if (keyState.IsKeyDown(Keys.Y))
            {
                input = "Y";
            }
            else if (keyState.IsKeyDown(Keys.U))
            {
                input = "U";
            }
            else if (keyState.IsKeyDown(Keys.I))
            {
                input = "I";
            }
            else if (keyState.IsKeyDown(Keys.O))
            {
                input = "O";
            }
            else if (keyState.IsKeyDown(Keys.P))
            {
                input = "P";
            }
            else if (keyState.IsKeyDown(Keys.A))
            {
                input = "A";
            }
            else if (keyState.IsKeyDown(Keys.S))
            {
                input = "S";
            }
            else if (keyState.IsKeyDown(Keys.D))
            {
                input = "D";
            }
            else if (keyState.IsKeyDown(Keys.F))
            {
                input = "F";
            }
            else if (keyState.IsKeyDown(Keys.G))
            {
                input = "G";
            }
            else if (keyState.IsKeyDown(Keys.H))
            {
                input = "H";
            }
            else if (keyState.IsKeyDown(Keys.J))
            {
                input = "J";
            }
            else if (keyState.IsKeyDown(Keys.K))
            {
                input = "K";
            }
            else if (keyState.IsKeyDown(Keys.L))
            {
                input = "L";
            }
            else if (keyState.IsKeyDown(Keys.Z))
            {
                input = "Z";
            }
            else if (keyState.IsKeyDown(Keys.X))
            {
                input = "X";
            }
            else if (keyState.IsKeyDown(Keys.C))
            {
                input = "C";
            }
            else if (keyState.IsKeyDown(Keys.V))
            {
                input = "V";
            }
            else if (keyState.IsKeyDown(Keys.B))
            {
                input = "B";
            }
            else if (keyState.IsKeyDown(Keys.N))
            {
                input = "N";
            }
            else if (keyState.IsKeyDown(Keys.M))
            {
                input = "M";
            }
            else if (keyState.IsKeyDown(Keys.NumPad0))
            {
                input = "0";
            }
            else if (keyState.IsKeyDown(Keys.NumPad1))
            {
                input = "1";
            }
            else if (keyState.IsKeyDown(Keys.NumPad2))
            {
                input = "2";
            }
            else if (keyState.IsKeyDown(Keys.NumPad3))
            {
                input = "3";
            }
            else if (keyState.IsKeyDown(Keys.NumPad4))
            {
                input = "4";
            }
            else if (keyState.IsKeyDown(Keys.NumPad5))
            {
                input = "5";
            }
            else if (keyState.IsKeyDown(Keys.NumPad6))
            {
                input = "6";
            }
            else if (keyState.IsKeyDown(Keys.NumPad7))
            {
                input = "7";
            }
            else if (keyState.IsKeyDown(Keys.NumPad8))
            {
                input = "8";
            }
            else if (keyState.IsKeyDown(Keys.NumPad9))
            {
                input = "9";
            }
            else if (keyState.IsKeyDown(Keys.Back))
            {
                input = "BackSpace";
            }
            else if (keyState.IsKeyDown(Keys.Space))
            {
                input = " ";
            }
            else if (keyState.IsKeyDown(Keys.Enter))
            {
                input = "Enter";
            }
            else
            {
                input = "";
            }

            keyState = oldKey;
            return input;
        }
    }
}
