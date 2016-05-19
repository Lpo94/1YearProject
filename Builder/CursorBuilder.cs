using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using _1YearProject.Components;
using _1YearProject.Interfaces;
using _1YearProject.UI;
using _1YearProject.TowerDefense;

namespace _1YearProject.Builder
{
    class CursorBuilder:IBuilder
    {
        private GameObject gameObject;


        public void BuildGameObject(Vector2 position, float speed, float dmg)
        {
            gameObject = new GameObject();
            gameObject.AddComponent(new Transform(gameObject, Vector2.Zero));
            gameObject.AddComponent(new SpriteRenderer(gameObject, "Textbox", 1, position));
            gameObject.AddComponent(new MouseCursor(gameObject));
            gameObject.AddComponent(new Animator(gameObject));
            gameObject.AddComponent(new Collider(gameObject));
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}

