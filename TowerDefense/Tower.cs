using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1YearProject.Components;
using _1YearProject.Interfaces;
using _1YearProject.UI;
using _1YearProject.TowerDefense;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace _1YearProject.TowerDefense
{
    abstract class Tower : Component,IUpdate,ILoad
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
            if(GameLogic.Instance.TowerIconClicked == true)
            {
                
            }
            return true;
        }
        public bool Space()
        {
            if (type == "asda")
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private bool Targetted()
        {
            return true;
        }

        public void Update()
        {
            rect.X = Mouse.GetState().X - 4;
            rect.Y = Mouse.GetState().Y - 4;
        }

        public void LoadContent(ContentManager content)
        {
            rect = new Rectangle(0,0, 8, 8);
        }
    }
}
