using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1YearProject.Interfaces;
using _1YearProject.Components;
using _1YearProject.TowerDefense;
using Microsoft.Xna.Framework;

namespace _1YearProject.Builder
{
    class BulletBuilder : IBuilder
    {
        private GameObject gameObject;

        public void BuildGameObject(Vector2 position, float speed, float dmg, GameObject enemy)
        {
            gameObject = new GameObject();

            gameObject.AddComponent(new SpriteRenderer(gameObject, "Textbox", 1, position));

            gameObject.AddComponent(new TowerShot(gameObject, dmg, speed, position, enemy));

            gameObject.AddComponent(new Animator(gameObject));

            gameObject.AddComponent(new Collider(gameObject));

            gameObject.AddComponent(new Transform(gameObject,position));
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
