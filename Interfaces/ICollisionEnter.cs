using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using _1YearProject.Components;

namespace _1YearProject.Interfaces
{
    interface ICollisionEnter
    {
        void OnCollisionEnter(Collider other);
    }
}
