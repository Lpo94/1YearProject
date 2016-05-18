using Microsoft.Xna.Framework;
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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        static GameWorld instance;
        private List<GameObject> gameObjects = new List<GameObject>();
        private List<GameObject> inGame = new List<GameObject>();
        public float deltaTime { get; private set; }
        private Director towerDirector = new Director(new TowerBuilder());
        public bool canBuild;

        private Rectangle cursorRect;
        private Texture2D cursorTex;

        // Cursor
        Texture2D cursorTexture;
        Rectangle CursorRectangle;
        Color cursorTextureData;

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
            director.Construct(new Vector2 (545, 335));
            GameObject textBox1 = director.GetGameObject();
            director.Construct(new Vector2(545, 435));
            GameObject textBox2 = director.GetGameObject();
            director = new Director(new TowerIconBuilder());
            director.Construct(new Vector2(100, 100));
            GameObject icon = director.GetGameObject();
            director = new Director(new PlayerBuilder());
            director.Construct(new Vector2(400, 400));
            GameObject player = director.GetGameObject();
            director = new Director(new MainbuildingBuilder());
            director.Construct(new Vector2(100, 200));
            GameObject mainbuilding = director.GetGameObject();




            inGame.Add(player);
            inGame.Add(icon);
            inGame.Add(mainbuilding);
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
            cursorTex = Content.Load<Texture2D>("textbox");
            cursorRect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 32, 32);
            
            foreach (GameObject go in gameObjects)
            {
                go.LoadContent(Content);
            }
            foreach (GameObject go in inGame)
            {
                go.LoadContent(Content);
            }

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
            }

            foreach (Collider col in colliders)
            {
                if (TowerIcon.Clicked == true)
                {
                    if (!col.CollisionBox.Intersects(cursorRect))
                    {
                        
                        canBuild = true;
                    }
                    else if(col.CollisionBox.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)))
                    {
                        canBuild = false;
                    }
                }
            }

            cursorRect.X = Mouse.GetState().X-16;
            cursorRect.Y = Mouse.GetState().Y-16;
            
            
            if (Keyboard.GetState().IsKeyDown(Keys.P) && MainMenu._GameState == GameState.inGame)
            {
                MainMenu._GameState = GameState.pause;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.M))
            {
                BuildTower(new Vector2(Mouse.GetState().X,Mouse.GetState().Y));
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
                    foreach (GameObject obj in inGame)
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
                    foreach (GameObject obj in inGame)
                    {
                        obj.Draw(spriteBatch);
                    }
                    break;

                default:
                    break;
            }
                    // TODO: Add your drawing code here

                    MainMenu.Instance.Draw(spriteBatch);
            if(TowerIcon.Clicked == true)
            {
                spriteBatch.Draw(cursorTex, cursorRect, Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
            
        }

        internal void BuildTower(Vector2 pos)
        {
            if (canBuild == true)
            {

                towerDirector.Construct(pos);
                GameObject go = towerDirector.GetGameObject();
                inGame.Add(go);
                go.LoadContent(Content);
                TowerIcon.Clicked = false;
                canBuild = false;
            }

        }
    }
}
