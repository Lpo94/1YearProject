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
    class MiniGames : Component, IUpdate, ILoad
    {
        private List<Fruits> minigame1 = new List<Fruits>();
        private List<GameObject> minigame2 = new List<GameObject>();
        private int minigameNumber = 1;
        static MiniGames instance;

        private static int points;

        public static int Points
        {
            get { return points; }
            set { points = value; }
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
            switch (minigameNumber)
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
    }
}
