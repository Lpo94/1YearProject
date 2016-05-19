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
    class Mainbuilding : Component, IUpdate, IDraw, ILoad, ICollisionEnter, ICollisionExit
    {
        private Animator animator;
        private Collider collider;
        private Transform transform;
        private SpriteRenderer spriteRenderer;
        private Vector2 startPos = Vector2.Zero;
        private SpriteFont font;
        public int Health = 75;

        public Mainbuilding(GameObject gameObject, int Health, Vector2 startPos) : base(gameObject)
        {
            transform = gameObject.GetTransform;
            transform.Position = startPos;
        }
        public void Update()
        {
        }
        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("font");
            this.collider = (Collider)gameObject.GetComponent("Collider");
            this.animator = (Animator)gameObject.GetComponent("Animator");
            CreateAnimations();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Health: " + Health, new Vector2(0, 350), Color.Black);
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
            animator.CreateAnimation("Static", new Animation(1, 0, 0, 125, 125, 1, Vector2.Zero));
            animator.PlayAnimation("Static");
        }
    }
}
