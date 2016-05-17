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
    abstract class Tower : Component, IUpdate, ILoad
    {

        
        Vector2 pos;
        Texture2D tex;
        Rectangle rect;
        

        public bool Clicked { get; set; }
        public float Dmg {get; }
        public float Range { get; }
        public string Type { get; }
        public float Price { get;  }

        public Tower(GameObject gameObject, string type, Vector2 pos) : base(gameObject)
        {
            this.Type = type;

            this.pos = pos;
        }


        public bool Build(Vector2 pos)
        {
            if(GameLogic.Instance.TowerIconClicked == true)
            {
                
            }
            return true;
        }

        
        public bool Space()
        {
            if (Clicked == true)
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
