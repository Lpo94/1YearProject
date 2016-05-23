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
    class Dodge_Enemy : Component, IUpdate, ILoad, ICollisionEnter
    {
        private Animator animator;
        private Collider collider;
        private Transform transform;
        private float speed = 0.5f;
        private Vector2 startPos = Vector2.Zero;
        private Random r = new Random();
        private int movement = 1;


        public Dodge_Enemy(GameObject gameObject) : base(gameObject)
        {
            transform = gameObject.GetTransform;
            transform.Position = startPos;
        }

        public void LoadContent(ContentManager content)
        {
            this.animator = (Animator)gameObject.GetComponent("Animator");
            this.collider = (Collider)gameObject.GetComponent("Collider");
            CreateAnimations();
        }

        public void OnCollisionEnter(Collider other)
        {

        }

        public void Update()
        {
            Vector2 translation = Vector2.Zero;
            if (transform.Position.Y > GameWorld.Graphics.PreferredBackBufferHeight)
            {
                movement = 3;
                transform.Position = new Vector2(5, r.Next(5, 950));
            }
            if (transform.Position.Y < 0)
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
                transform.Position = new Vector2(r.Next(5, 1350), 5);
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
            animator.CreateAnimation("static", new Animation(1, 0, 0, 32, 32, 1, Vector2.Zero));
            animator.PlayAnimation("static");
        }
    }
}
