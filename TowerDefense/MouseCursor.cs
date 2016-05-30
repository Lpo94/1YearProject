using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1YearProject.Components;
using _1YearProject.Interfaces;
using _1YearProject.Builder;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace _1YearProject.TowerDefense
{
    class MouseCursor : Component, ILoad, IUpdate, ICollisionExit, ICollisionEnter
    {
        private Transform transform;
        private Animator animator;
        private Collider collider;


        public bool canBuild { get; set; }

        public MouseCursor(GameObject gameObject) : base(gameObject)
        {
            transform = gameObject.GetTransform;

        }

        public void OnCollisionExit(Collider other)
        {

        }

        public void OnCollisionEnter(Collider other)
        {
            GameWorld.Instance.canBuild = false;
        }

        public void Update()
        {

            transform.Position = new Vector2(Mouse.GetState().X - 16, Mouse.GetState().Y - 16);
            if (TowerIcon.Clicked == true)
            {
                animator.PlayAnimation("static");
            }
            else
                animator.PlayAnimation("hidden");

            if (collider.otherColliders.Count != 0 && TowerIcon.Clicked == true)
            {
                GameWorld.Instance.canBuild = true;
            }
            else
                GameWorld.Instance.canBuild = false;
        }

        public void LoadContent(ContentManager content)
        {
            collider = (Collider)gameObject.GetComponent("Collider");
            animator = (Animator)gameObject.GetComponent("Animator");
            CreateAnimations();
        }

        public void CreateAnimations()
        {
            animator.CreateAnimation("static", new Animation(1, 0, 0, 32, 32, 6, Vector2.Zero));
            animator.CreateAnimation("hidden", new Animation(1, 32, 0, 32, 32, 6, Vector2.Zero));
            animator.PlayAnimation("static");
        }


    }
}
