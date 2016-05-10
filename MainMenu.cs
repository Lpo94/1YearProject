using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _1YearProject.Components;
using _1YearProject.Interfaces;

namespace _1YearProject
{
    class MainMenu : Component, ILoad, IDraw, IUpdate
    {
        private static List<GUIElement> main = new List<GUIElement>();
        private static List<GUIElement> login = new List<GUIElement>();
        private static List<GUIElement> howTo = new List<GUIElement>();
        private static List<GUIElement> highscore = new List<GUIElement>();
        private static List<GUIElement> inGame = new List<GUIElement>();
        private static List<GUIElement> pause = new List<GUIElement>();
        static MainMenu instance;

        private static GameState gameState;

        public static GameState _GameState
        {
            get { return gameState; }
            set { gameState = value; }
        }

        public static MainMenu Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new MainMenu();
                }
                return instance;
            }
        }

        private MainMenu()
        {
            login.Add(new GUIElement("username"));
            login.Add(new GUIElement("password"));
            login.Add(new GUIElement("login"));
            login.Add(new GUIElement("create"));
            login.Add(new GUIElement("exit"));

            main.Add(new GUIElement("new game"));
            main.Add(new GUIElement("load game"));
            main.Add(new GUIElement("how to"));
            main.Add(new GUIElement("highscore"));
            main.Add(new GUIElement("logout"));
            main.Add(new GUIElement("exit"));

            pause.Add(new GUIElement("pause BG"));
            pause.Add(new GUIElement("continue"));
            pause.Add(new GUIElement("save"));
            pause.Add(new GUIElement("leave game"));
        }

        public void LoadContent(ContentManager content)
        {
            foreach (GUIElement element in login)
            {
                element.LoadContent(content);
                element.CenterElement(1000, 1400);
                element.clickEvent += OnClick;
            }
            login.Find(x => x.AssetName == "username").MoveElement(0, -200);
            login.Find(x => x.AssetName == "password").MoveElement(0, -90);
            login.Find(x => x.AssetName == "login").MoveElement(0, 30);
            login.Find(x => x.AssetName == "create").MoveElement(0, 90);
            login.Find(x => x.AssetName == "exit").MoveElement(0, 150);

            foreach (GUIElement element in main)
            {
                element.LoadContent(content);
                element.CenterElement(1000, 1400);
                element.clickEvent += OnClick;
            }
            main.Find(x => x.AssetName == "new game").MoveElement(0, -200);
            main.Find(x => x.AssetName == "load game").MoveElement(0, -100);
            main.Find(x => x.AssetName == "how to").MoveElement(0, 0);
            main.Find(x => x.AssetName == "highscore").MoveElement(0, 100);
            main.Find(x => x.AssetName == "logout").MoveElement(0, 200);
            main.Find(x => x.AssetName == "exit").MoveElement(0, 300);

            foreach (GUIElement element in pause)
            {
                element.LoadContent(content);
                element.CenterElement(1000, 1400);
                element.clickEvent += OnClick;
            }
            pause.Find(x => x.AssetName == "continue").MoveElement(0, -100);
            pause.Find(x => x.AssetName == "save").MoveElement(0, 0);
            pause.Find(x => x.AssetName == "leave game").MoveElement(0, 100);
        }

        public void Update()
        {
            switch (gameState)
            {
                case GameState.loginScreen:
                    foreach (GUIElement element in login)
                    {
                        element.Update();
                    }
                    break;

                case GameState.mainMenu:
                    foreach (GUIElement element in main)
                    {
                        element.Update();
                    }
                    break;

                case GameState.pause:
                    foreach (GUIElement element in pause)
                    {
                        element.Update();
                    }
                    break;

                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            switch (gameState)
            {
                case GameState.loginScreen:
                    foreach (GUIElement element in login)
                    {
                        element.Draw(spritebatch);
                    }
                    break;

                case GameState.mainMenu:
                    foreach (GUIElement element in main)
                    {
                        element.Draw(spritebatch);
                    }
                    break;

                case GameState.pause:
                    foreach (GUIElement element in pause)
                    {
                        element.Draw(spritebatch);
                    }
                    break;

                default:
                    break;
            }
        }

        public void OnClick(string element)
        {
            if (element == "login")
            {
                gameState = GameState.mainMenu;
            }

            if (element == "how to")
            {
                gameState = GameState.pause;
            }

            if (element == "leave game")
            {
                gameState = GameState.mainMenu;
            }

            if (element == "logout")
            {
                gameState = GameState.loginScreen;
            }

            if (element == "continue")
            {
                gameState = GameState.inGame;
            }

            if (element == "new game")
            {
                gameState = GameState.inGame;
            }

            if (element == "create")
            {
                gameState = GameState.create;
            }
        }
    }
}
