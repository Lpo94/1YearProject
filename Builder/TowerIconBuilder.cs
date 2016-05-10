using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using _1YearProject.Components;
using _1YearProject.Interfaces;
using _1YearProject.TowerDefense;


namespace _1YearProject.Builder
{
    class TowerIconBuilder : IBuilder
    {
       private GameObject gameObject = new GameObject();

        public GameObject GetResult()
        {
            return gameObject;
        }

        public void BuildGameObject(Vector2 position)
        {
            gameObject.AddComponent(new Transform(gameObject, position));
            gameObject.AddComponent(new SpriteRenderer(gameObject, "Textbox", 1));
            gameObject.AddComponent(new TowerIcon(gameObject));


        }
    }
}
