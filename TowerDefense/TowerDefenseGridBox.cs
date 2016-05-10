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
    class TowerDefenseGridBox : Component, IDraw, IUpdate, ILoad
    {
        Rectangle rect;
        Texture2D tex;
        Vector2 pos;
        bool taken;

        public TowerDefenseGridBox(GameObject gameObject,Vector2 pos) : base(gameObject)
        {
            this.pos = pos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, rect, Color.White);
        }

        public void LoadContent(ContentManager content)
        {
            tex = content.Load<Texture2D>("Textboxtar");
            rect = new Rectangle((int)pos.X, (int)pos.Y, 16,16);
        }


        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
