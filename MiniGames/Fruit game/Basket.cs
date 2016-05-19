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
    class Basket : Component, IUpdate, ILoad, ICollisionEnter
    {
        private Animator animator;
        private Collider collider;
        private Transform transform;
        private float speed = 1f;
        private Vector2 startPos = Vector2.Zero;

        public Basket(GameObject gameObject, Vector2 startPos) : base(gameObject)
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
            KeyboardState keyState = Keyboard.GetState();
                if (MainMenu._GameState == GameState.events && keyState.IsKeyDown(Keys.A) && transform.Position.X > 0)
                {
                    translation += new Vector2(-1, 0);
                }
                else if (MainMenu._GameState == GameState.events && keyState.IsKeyDown(Keys.D) && transform.Position.X < 1360)
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
