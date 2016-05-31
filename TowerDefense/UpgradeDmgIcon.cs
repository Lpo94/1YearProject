using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1YearProject.Components;
using _1YearProject.Interfaces;
using _1YearProject.UI;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace _1YearProject
{
    class UpgradeDmgIcon : Component, IUpdate, ILoad
    {
        private Transform transform;
        private Collider collider;
        private Animator animator;
        private float upgradeTime = 150;
        

        public UpgradeDmgIcon(GameObject gameObject, Vector2 pos) : base(gameObject)
        {
            transform = gameObject.GetTransform;
            transform.Position = pos;
        }


        public void LoadContent(ContentManager content)
        {
            this.collider = (Collider)gameObject.GetComponent("Collider");
            this.animator = (Animator)gameObject.GetComponent("Animator");
            CreateAnimations();
        }

        public void Update()
        {
            if (upgradeTime <= 0)
            {
                if (collider.CollisionBox.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Tower.UpgDMG = true;
                    upgradeTime = 150;
                }

            }
            else
                upgradeTime -= GameWorld.Instance.deltaTime;
        }

        public void CreateAnimations()
        {
            animator.CreateAnimation("static", new Animation(1, 0, 0, 50, 36, 6, Vector2.Zero));
            animator.PlayAnimation("static");
        }
    }
}
