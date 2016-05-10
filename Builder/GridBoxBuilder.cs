using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1YearProject.Components;
using _1YearProject.Interfaces;
using _1YearProject.TowerDefense;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace _1YearProject.Builder
{
    class GridBoxBuilder : IBuilder
    {
        private GameObject gameObject = new GameObject();

        public GameObject GetResult()
        {
            return gameObject;
        }

        public void BuildGameObject(Vector2 position)
        {

            gameObject.AddComponent(new TowerDefenseGridBox(gameObject,position));


        }
    }
}
