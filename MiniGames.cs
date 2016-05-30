using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using _1YearProject.Interfaces;
using _1YearProject.Components;
using Microsoft.Xna.Framework.Graphics;

namespace _1YearProject
{
    class MiniGames : Component, IUpdate, ILoad, IDraw
    {
        private List<Fruits> minigame1 = new List<Fruits>();
        private List<GameObject> minigame2 = new List<GameObject>();
        static MiniGames instance;
        private SpriteFont font;
        private static int miniGameNumber = 2;

        private static int points;

        public static int Points
        {
            get { return points; }
            set { points = value; }
        }

        public static int MiniGameNumber
        {
            get { return miniGameNumber; }
            set { miniGameNumber = value; }
        }

        public static MiniGames Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MiniGames();
                }
                return instance;
            }
        }



        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("font");
            foreach (Fruits go in minigame1)
            {
                go.LoadContent(content);
            }

            foreach (GameObject go in minigame2)
            {
                go.LoadContent(content);
            }
        }


        public void Update()
        {
            if(points >= 10)
            {
                Mainbuilding.Gold += 100;
                points = 0;
            }
            switch (miniGameNumber)
            {
                case 1:
                    foreach (Fruits go in minigame1)
                    {
                        go.Update();
                    }
                    break;

                case 2:
                    foreach (GameObject go in minigame2)
                    {
                        go.Update();
                    }
                    break;

                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
