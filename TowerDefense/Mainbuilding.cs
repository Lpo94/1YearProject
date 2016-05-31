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

namespace _1YearProject
{
    class Mainbuilding : Component, IUpdate, IDraw, ILoad, ICollisionEnter, ICollisionExit
    {
        private Animator animator;
        private Collider collider;
        private Transform transform;
        private SpriteRenderer spriteRenderer;
        private Vector2 startPos = Vector2.Zero;
        private SpriteFont font;
        public static int health = 75;
        private static int gold = 5000;

        public static int Gold
        {
            get { return gold; }
            set { gold = value; }
        }

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
            collider = (Collider)gameObject.GetComponent("Collider");
            animator = (Animator)gameObject.GetComponent("Animator");
            spriteRenderer = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");
            CreateAnimations();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Health: " + health, new Vector2(450, 50), Color.Red);
            spriteBatch.DrawString(font, "Gold: " + gold, new Vector2(250, 50), Color.Gold);
        }
        public void OnCollisionEnter(Collider other)
        {
            if (other.gameObject.CheckComponent("enemy") == true)
            {
                spriteRenderer.Color = Color.Blue;
                health -= 1;
            }
        }

        public void OnCollisionExit(Collider other)
        {
            spriteRenderer.Color = Color.White;
        }
        public void CreateAnimations()
        {
            animator.CreateAnimation("Static", new Animation(1, 0, 0, 125, 125, 1, Vector2.Zero));
            animator.PlayAnimation("Static");
        }
    }
}
