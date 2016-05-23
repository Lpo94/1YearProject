using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1YearProject.Interfaces;
using Microsoft.Xna.Framework;


namespace _1YearProject.Builder
{
    class Director
    {
        private IBuilder builder;

        public Director(IBuilder builder)
        {
            this.builder = builder;
        }

        public void Construct(Vector2 pos, float speed, float dmg, GameObject enemy)
        {
            builder.BuildGameObject(pos,speed,dmg, enemy);
        }

        public GameObject GetGameObject()
        {
            return builder.GetResult();
        }
    }
}
