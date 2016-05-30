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
    class Dodge_Enemy : Component, IUpdate, ILoad, ICollisionEnter, IDraw
    {
        private Animator animator;
        private Collider collider;
        private Transform transform;
        private float speed = 1f;
        private Vector2 startPos = Vector2.Zero;
        private Random r = new Random();
        private Random r2 = new Random();
        private Random r3 = new Random();
        private int movement = 1;
        private SpriteFont font;


        public Dodge_Enemy(GameObject gameObject, Vector2 pos) : base(gameObject)
        {
            transform = gameObject.GetTransform;
            transform.Position = pos;
        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("font");
            this.animator = (Animator)gameObject.GetComponent("Animator");
            this.collider = (Collider)gameObject.GetComponent("Collider");
            CreateAnimations();
        }

        public void OnCollisionEnter(Collider other)
        {
            GameWorld.Instance.removeObjects.Add(gameObject);
        }

        public void Update()
        {
            Vector2 translation = Vector2.Zero;
            if (transform.Position.Y > GameWorld.Graphics.PreferredBackBufferHeight)
            {
                movement = 3;
                transform.Position = new Vector2(5, r.Next(5, 950));
            }
            if (transform.Position.Y < 30)
            {
                movement = 4;
                transform.Position = new Vector2(1350, r.Next(5, 950));
            }
            if (transform.Position.X > GameWorld.Graphics.PreferredBackBufferWidth)
            {
                movement = 2;
                transform.Position = new Vector2(r.Next(5, 1350), 995);
            }
            if (transform.Position.X < 0)
            {
                movement = 1;
                transform.Position = new Vector2(r.Next(5, 1350), 30);
            }

            if (MainMenu._GameState == GameState.events && movement == 1)
            {
                translation += new Vector2(0, 1);
            }
            else if (MainMenu._GameState == GameState.events && movement == 2)
            {
                translation += new Vector2(0, -1);
            }
            else if (MainMenu._GameState == GameState.events && movement == 4)
            {
                translation += new Vector2(-1, 0);
            }
            else if (MainMenu._GameState == GameState.events && movement == 3)
            {
                translation += new Vector2(1, 0);
            }
            gameObject.GetTransform.Translate(translation * speed * GameWorld.Instance.deltaTime);
        }

        public void CreateAnimations()
        {
            animator.CreateAnimation("static", new Animation(1, 0, 0, 44, 42, 1, Vector2.Zero));
            animator.PlayAnimation("static");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Required points to win: " + MiniGames.Points, new Vector2(450, 5), Color.Black);
            spriteBatch.DrawString(font, "Points: " + MiniGames.Points, new Vector2(50, 5), Color.Black);
        }
    }
}
