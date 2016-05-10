using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _1YearProject.Components;
using _1YearProject.Builder;
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
        private List<GameObject> mainMenu = new List<GameObject>();
        public float deltaTime { get; private set; }

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

            GameObject mainMenu = new GameObject();
            Director director = new Director(new TextBoxBuilder());
            director.Construct(new Vector2 (250, 250));


            GameObject textBox1 = director.GetGameObject();

            gameObjects.Add(textBox1);

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
                //Exit();
                deltaTime = (float)gameTime.ElapsedGameTime.Milliseconds;
            foreach (GameObject obj in gameObjects)
            {
                obj.Update();
            }

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

            

            foreach (GameObject obj in gameObjects)
            {
                obj.Draw(spriteBatch);
            }
            // TODO: Add your drawing code here

            MainMenu.Instance.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
            
        }
    }
}
