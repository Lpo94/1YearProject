using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using _1YearProject.Components;
using _1YearProject.Interfaces;
using _1YearProject.TowerDefense;
using System;

namespace _1YearProject.Builder
{
    class TowerBuilder : IBuilder
    {
        private GameObject gameObject;

        public void BuildGameObject(Vector2 position, float speed, float dmg)
        {
            gameObject = new GameObject();
            gameObject.AddComponent(new SpriteRenderer(gameObject, "Textbox", 1, position));
            gameObject.AddComponent(new Tower(gameObject, "normal", position));
            gameObject.AddComponent(new Animator(gameObject));
            gameObject.AddComponent(new Collider(gameObject));
            gameObject.AddComponent(new Transform(gameObject, position));
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
