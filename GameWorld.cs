using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _1YearProject.Components;
using _1YearProject.Builder;
using _1YearProject.TowerDefense;
using System.Collections.Generic;

namespace _1YearProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    enum GameState { loginScreen, mainMenu, inGame, pause, events, howTo, highscore, create }

    public class GameWorld : Game
    {
        private SpriteRenderer spriteRenderer;
        private static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        static GameWorld instance;
        private List<GameObject> gameObjects = new List<GameObject>();
        private List<GameObject> inGame = new List<GameObject>();
        private List<GameObject> events = new List<GameObject>();
        private List<GameObject> tempObj = new List<GameObject>();
        internal List<GameObject> removeObjects = new List<GameObject>();
        public float deltaTime { get; private set; }
        private Director globalDirector = new Director(new TowerBuilder());
        private Director bulletDirector = new Director(new BulletBuilder());
        public bool canBuild;

        WaveManager waveManager;
        Level level = new Level();
        Texture2D enemyTexture;

        public static GraphicsDeviceManager Graphics
        {
            get { return graphics; }
            set { graphics = value; }
        }

        internal static List<Collider> colliders = new List<Collider>();


        public static GameWorld Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameWorld();
                }
                return instance;
            }
        }

        private GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 1000;
            graphics.PreferredBackBufferWidth = 1400;
            IsMouseVisible = true;
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            
            Director director = new Director(new TextBoxBuilder());
            director.Construct(new Vector2 (545, 335),0,0);
            GameObject textBox1 = director.GetGameObject();
            director.Construct(new Vector2(545, 435), 0, 0);
            GameObject textBox2 = director.GetGameObject();

            director = new Director(new TowerIconBuilder());
            director.Construct(new Vector2(100, 700), 0, 0);
            GameObject icon = director.GetGameObject();

            director = new Director(new PlayerBuilder());
            director.Construct(new Vector2(400, 400), 0, 0);
            GameObject player = director.GetGameObject();

            director = new Director(new FruitBuilder());
            director.Construct(new Vector2(100, 0), 0, 0);
            GameObject fruit = director.GetGameObject();
            director.Construct(new Vector2(100, 0), 0, 0);
            GameObject fruit2 = director.GetGameObject();
            director.Construct(new Vector2(100, 0), 0, 0);
            GameObject fruit3 = director.GetGameObject();

            director = new Director(new BasketBuilder());
            director.Construct(new Vector2(0, 950), 0, 0);
            GameObject basket = director.GetGameObject();

            director = new Director(new CursorBuilder());
            director.Construct(Vector2.Zero, 0, 0);
            GameObject cursor = director.GetGameObject();

            director = new Director(new MainbuildingBuilder());
            director.Construct(new Vector2(450, 450), 0, 0);
            GameObject mainBuilding = director.GetGameObject();

            inGame.Add(basket);
            events.Add(fruit);
            events.Add(fruit2);
            events.Add(fruit3);
            inGame.Add(player);
            inGame.Add(icon);
            inGame.Add(mainBuilding);
            inGame.Add(cursor);
            gameObjects.Add(textBox1);
            gameObjects.Add(textBox2);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            foreach (GameObject go in gameObjects)
            {
                go.LoadContent(Content);
            }
            foreach (GameObject go in inGame)
            {
                go.LoadContent(Content);
            }

            foreach (GameObject go in events)
            {
                go.LoadContent(Content);
            }

            Texture2D enemyTexture = Content.Load<Texture2D>("enemy");
            Texture2D grass = Content.Load<Texture2D>("grass");
            waveManager = new WaveManager(level, 24, enemyTexture);

            Texture2D path = Content.Load<Texture2D>("path");
            level.AddTexture(grass);
            level.AddTexture(path);

            MainMenu.Instance.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            foreach (GameObject go in removeObjects)
            {
                inGame.Remove(go);
            }

            removeObjects.Clear();

            if (Keyboard.GetState().IsKeyDown(Keys.P) && MainMenu._GameState == GameState.inGame || Keyboard.GetState().IsKeyDown(Keys.P) && MainMenu._GameState == GameState.events)
                    {
                MainMenu._GameState = GameState.pause;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && MainMenu._GameState == GameState.inGame)
            {
                MainMenu._GameState = GameState.events;
            }
            
            else if (Keyboard.GetState().IsKeyDown(Keys.Space) && MainMenu._GameState == GameState.events)
            {
                MainMenu._GameState = GameState.inGame;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.M))
            {
                BuildTower(new Vector2(Mouse.GetState().X-16,Mouse.GetState().Y-16));
            }

            switch (MainMenu._GameState)
            {
                case GameState.loginScreen:
                    foreach (GameObject obj in gameObjects)
                    {
                        obj.Update();
                    }
                    break;

                case GameState.inGame:
                    tempObj = inGame.ToList();

                    foreach (GameObject obj in tempObj)
                    {
                        obj.Update();
                    }
                    waveManager.Update(gameTime);
                    break;

                case GameState.events:
                    tempObj = inGame.ToList();

                    foreach (GameObject obj in events)
                    {
                        obj.Update();
                    }
                    foreach (GameObject obj in tempObj)
                    {
                        obj.Update();
                    }
                    break;

                   
                default:
                    break;

            }
            //Exit();
            
            deltaTime = (float)gameTime.ElapsedGameTime.Milliseconds;

            // TODO: Add your update logic here
            
            

            MainMenu.Instance.Update();
            MiniGames.Instance.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (MainMenu._GameState)
            {
                case GameState.loginScreen:
                    foreach (GameObject obj in gameObjects)
                    {
                        obj.Draw(spriteBatch);
                    }
                    break;
                case GameState.inGame:
                    level.Draw(spriteBatch);
                    foreach (GameObject obj in tempObj)
                    {
                        obj.Draw(spriteBatch);
                    }
                    waveManager.Draw(spriteBatch);
                    
                    break;
                case GameState.events:
                    foreach (GameObject obj in events)
                    {
                        obj.Draw(spriteBatch);
                    }
                    break;

                default:
                    break;
            }
            // TODO: Add your drawing code here
           
            MainMenu.Instance.Draw(spriteBatch);
          
            spriteBatch.End();

            base.Draw(gameTime);
            
        }

        internal void BuildTower(Vector2 pos)
        {
            if (canBuild == true)
            {

                globalDirector.Construct(pos, 0, 0);
                GameObject tower = globalDirector.GetGameObject();
                inGame.Add(tower);
                tower.LoadContent(Content);
                TowerIcon.Clicked = false;
                canBuild = false;
            }

        }

        internal void CreateBullet(Vector2 pos, float speed, float dmg)
        {
            
            bulletDirector.Construct(pos, speed, dmg);
            GameObject bullet = bulletDirector.GetGameObject();
            bullet.LoadContent(Content);
            inGame.Add(bullet);
            

        }


    }
}
