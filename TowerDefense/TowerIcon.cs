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
    class TowerIcon : Component, IUpdate,ILoad,IDraw
    {
        Texture2D tex;
        Vector2 pos;
        Rectangle rect;

        public TowerIcon(GameObject gameObject) : base(gameObject)
        {

        }


        public void LoadContent(ContentManager content)
        {
            
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
