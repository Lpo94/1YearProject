using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _1YearProject.Components;
using _1YearProject.Interfaces;

namespace _1YearProject
{
    class MainMenu : Component, ILoad, IDraw, IUpdate
    {
        string abekat;
        private static List<GUIElement> main = new List<GUIElement>();

        private MainMenu()
        {
            main.Add(new GUIElement("bla"));
        }

        public void LoadContent(ContentManager content)
        {
            foreach (GUIElement element in main)
            {
                element.LoadContent(content);
                element.CenterElement(600, 800);
                element.clickEvent += OnClick;
            }
        }

        public void Update()
        {
            foreach (GUIElement element in main)
            {
                element.Update();
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (GUIElement element in main)
            {
                element.Draw(spritebatch);
            }
        }

        public void OnClick(string element)
        {
            if (element == "bla")
            {

            }
        }
    }
}
