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
    class FruitBuilder : IBuilder
    {
        private GameObject gameObject;

        public GameObject GetResult()
        {
            return gameObject;
        }

        public void BuildGameObject(Vector2 position, float speed, float dmg,GameObject enemy)
        {
            gameObject = new GameObject();

            gameObject.AddComponent(new SpriteRenderer(gameObject, "mid player", 1, position));

            gameObject.AddComponent(new Fruits(gameObject));

            gameObject.AddComponent(new Animator(gameObject));

            gameObject.AddComponent(new Collider(gameObject));
        }
    }
}
