using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1YearProject.Components;
using _1YearProject.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace _1YearProject.TowerDefense
{
    abstract class Tower : Component
    {
        float range;
        float dmg;
        Vector2 pos;
        Texture2D tex;
        Rectangle rect;
        float prize;
        string type;
        
        public Tower(GameObject gameObject, string type, float prize, float dmg, float range, Vector2 pos) : base(gameObject)
        {
            this.type = type;
            this.prize = prize;
            this.dmg = dmg;
            this.pos = pos;
        }


        public bool Build()
        {

            return true;
        }

        private bool Targetted()
        {
            return true;
        }
    }
}
