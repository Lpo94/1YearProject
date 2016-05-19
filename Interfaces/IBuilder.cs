using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace _1YearProject.Interfaces
{
    interface IBuilder
    {
        GameObject GetResult();

        void BuildGameObject(Vector2 position, float speed, float dmg);
    }
}
