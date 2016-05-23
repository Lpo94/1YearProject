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
    class Fruits : Component, IUpdate, ILoad, ICollisionEnter
    {
        private Animator animator;
        private Collider collider;
        private Transform transform;
        private float speed = 0.2f;
        private Vector2 startPos = Vector2.Zero;
        private Random r = new Random();
        

        public Fruits(GameObject gameObject) : base(gameObject)
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
            MiniGames.Points += 1;
            transform.Position = new Vector2(r.Next(0, 1350), 0);
        }

        public void Update()
        {
            Vector2 translation = Vector2.Zero;
            if(transform.Position.Y > GameWorld.Graphics.PreferredBackBufferHeight)
            {
                transform.Position = new Vector2(r.Next(0, 1350), 0);
            }

            if (MainMenu._GameState == GameState.events)
            {
                translation += new Vector2(0,1);
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
