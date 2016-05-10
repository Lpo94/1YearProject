using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using _1YearProject.Components;
using _1YearProject.Interfaces;
using _1YearProject.UI;

namespace _1YearProject
{
    class TextBoxBuilder : IBuilder
    {
        private GameObject gameObject = new GameObject();

        public GameObject GetResult()
        {
            return gameObject;
        }

        public void BuildGameObject(Vector2 position)
        {

            gameObject.AddComponent(new TextBox(gameObject, 300,25, position));


        }
    }
}
