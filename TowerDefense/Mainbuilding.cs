using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1YearProject.Components;
using _1YearProject.Interfaces;
using _1YearProject.UI;
using _1YearProject.TowerDefense;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace _1YearProject.TowerDefense
{
    class Mainbuilding : Component, IUpdate, ILoad, ICollisionEnter, ICollisionExit
    {
        private Animator animator;
        private Collider collider;
        private Transform transform;
        private SpriteRenderer spriteRenderer;
        private Vector2 startPos = Vector2.Zero;

        public int lives = 25;
        public int money = 999;
        public float startHealth;
        public float currentHealth;

        public float CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }
        public int Money
        {
            get { return Money; }
            set { Money = value; }
        }
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        public Mainbuilding(GameObject gameObject, float startHealth, float currentHealth, Vector2 startPos) : base(gameObject)
        {
            this.startHealth = startHealth;
            this.currentHealth = currentHealth;
            transform = gameObject.GetTransform;
            transform.Position = startPos;
        }
        public void Update()
        {
            
        }
        public void LoadContent(ContentManager content)
        {
            this.collider = (Collider)gameObject.GetComponent("Collider");
            this.animator = (Animator)gameObject.GetComponent("Animator");
            CreateAnimations();
        }
        public void OnCollisionEnter(Collider other)
        {
            spriteRenderer = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");
            spriteRenderer.Color = Color.Blue;
        }

        public void OnCollisionExit(Collider other)
        {
            spriteRenderer = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");
            spriteRenderer.Color = Color.White;
        }
        public void CreateAnimations()
        {
            animator.CreateAnimation("Static", new Animation(1, 0, 0, 512, 512, 1, Vector2.Zero));
            animator.PlayAnimation("Static");
        }
    }
}
