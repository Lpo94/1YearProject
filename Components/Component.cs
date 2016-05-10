using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1YearProject.Components
{
    abstract class Component
    {
        public GameObject gameObject { get; private set; }

        public Component()
        {

        }

        public Component(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }


    }
}
