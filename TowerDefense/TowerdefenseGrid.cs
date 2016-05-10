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
    class TowerdefenseGrid : Component,IUpdate,IDraw,ILoad
    {
        static TowerdefenseGrid instance;

        private Vector2[,] gridArray;
        private Rectangle gridBox;
        private Texture2D gridPic;
        private SpriteRenderer spriteRenderer;

        public static TowerdefenseGrid Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TowerdefenseGrid();
                }
                return instance;
            }
        }

        private TowerdefenseGrid()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void LoadContent(ContentManager content)
        {
            gridPic = content.Load<Texture2D>("Textboxtar");

        }
    }
}
