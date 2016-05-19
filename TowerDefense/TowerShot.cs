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
    class TowerShot:Component,IUpdate,ILoad
    {
        private float dmg = 0;
        private float speed = 0;

        private Transform transform;
        private Animator animator;
        private Collider collider;


        public TowerShot(GameObject gameObject, float dmg, float speed) : base(gameObject)
        {
            this.dmg = dmg;
            this.speed = speed;
            transform = gameObject.GetTransform;
        }

        public void LoadContent(ContentManager content)
        {
            this.collider = (Collider)gameObject.GetComponent("Collider");
            this.animator = (Animator)gameObject.GetComponent("Animator");
            CreateAnimations();
        }

        public void Update()
        {
            Vector2 translation = Vector2.Zero;
            translation += new Vector2(0, -1);
            gameObject.GetTransform.Translate(translation * speed * GameWorld.Instance.deltaTime);
        }

        public void CreateAnimations()
        {
            animator.CreateAnimation("static", new Animation(1, 0, 0, 8, 2, 6, Vector2.Zero));
            animator.PlayAnimation("static");
        }

    }
}
