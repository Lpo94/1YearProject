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

enum DIRECTION { Front, Back, Left, Right }

namespace _1YearProject
{
    class Player : Component, IUpdate, ILoad, ICollisionEnter
    {
        private SpriteRenderer spriteRenderer;
        private float speed = 0.5f;
        private Animator animator;
        private Transform transform;
        private DIRECTION direction;
        Keys[] currentKey;
        
        private List<string> comboList = new List<string>();

        public void LoadContent(ContentManager content)
        {
            this.animator = (Animator)gameObject.GetComponent("Animator");
            
            CreateAnimations();
            animator.PlayAnimation("IdleBack");
        }

        public Player(GameObject gameObject) : base(gameObject)
        {
            transform = gameObject.GetTransform;
        }

        public void CreateAnimations()
        {
            animator.CreateAnimation("IdleFront", new Animation(4, 0, 0, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("IdleBack", new Animation(4, 0, 4, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("IdleLeft", new Animation(4, 0, 8, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("IdleRight", new Animation(4, 0, 12, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkFront", new Animation(4, 150, 0, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkBack", new Animation(4, 150, 4, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkLeft", new Animation(4, 150, 8, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("WalkRight", new Animation(4, 150, 12, 90, 150, 6, Vector2.Zero));
            animator.CreateAnimation("AttackFront", new Animation(4, 300, 0, 145, 160, 8, new Vector2(-50, 0)));
            animator.CreateAnimation("AttackBack", new Animation(4, 465, 0, 170, 155, 8, new Vector2(-20, 0)));
            animator.CreateAnimation("AttackRight", new Animation(4, 620, 0, 150, 150, 8, Vector2.Zero));
            animator.CreateAnimation("AttackLeft", new Animation(4, 770, 0, 150, 150, 8, new Vector2(-60, 0)));
            animator.CreateAnimation("DieFront", new Animation(3, 920, 0, 150, 150, 5, Vector2.Zero));
            animator.CreateAnimation("DieBack", new Animation(3, 920, 3, 150, 150, 5, Vector2.Zero));
            animator.CreateAnimation("DieLeft", new Animation(3, 1070, 0, 150, 150, 5, Vector2.Zero));
            animator.CreateAnimation("DieRight", new Animation(3, 1070, 3, 150, 150, 5, Vector2.Zero));

            animator.PlayAnimation("IdleBack");

        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            currentKey = keyState.GetPressedKeys();

            Move();

        }


        public void OnCollisionEnter(Collider other)
        {
            spriteRenderer = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");
            spriteRenderer.Color = Color.Red;
        }


        public void Move()
        {
            Vector2 translation = Vector2.Zero;

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Up))
            {
                translation += new Vector2(0,-1);
                animator.PlayAnimation("WalkBack");
            }

         else   if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
            {
                translation += new Vector2(-1, 0);
                animator.PlayAnimation("WalkLeft");
            }

           else if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
            {
                translation += new Vector2(1, 0);
                animator.PlayAnimation("WalkRight");
            }

           else if (keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down))
            {
                translation += new Vector2(0, 1);
                animator.PlayAnimation("WalkFront");
            }

          else  if (!keyState.IsKeyDown(Keys.W)&&!keyState.IsKeyDown(Keys.S)&&!keyState.IsKeyDown(Keys.D)&&!keyState.IsKeyDown(Keys.A))
            {
                animator.PlayAnimation("IdleFront");
            }


            gameObject.GetTransform.Translate(translation*speed*GameWorld.Instance.deltaTime);
        }
    }

}
