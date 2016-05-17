using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1YearProject.Components;

namespace _1YearProject
{
    interface ICollisionExit
    {
        void OnCollisionExit(Collider other);
    }
}
