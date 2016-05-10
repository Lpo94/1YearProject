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
    class NormalTower : Tower,IUpdate,IDraw,ILoad
    {
        float price;
        float dmg;
        float range;

        Texture2D tex;
        Vector2 pos;
        Rectangle rect;

        
        public NormalTower(GameObject gameObject, string type, float price, float dmg, float range, Vector2 pos): base(gameObject, type, price, dmg, range, pos)
        {


        }

        public void LoadContent(ContentManager content)
        {
            rect = new Rectangle((int)pos.X, (int)pos.Y, 16, 16);
            tex = content.Load<Texture2D>("pause BG");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, rect, Color.White);
        }

        public void Update()
        {
            
        }
    }
}
