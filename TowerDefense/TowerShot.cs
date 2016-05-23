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

        private float liveTime = 500;
        private Transform transform;
        private Animator animator;
        private Collider collider;


        public TowerShot(GameObject gameObject, float dmg, float speed, Vector2 pos, GameObject enemy) : base(gameObject)
        {
            this.dmg = dmg;
            this.speed = speed;
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
            Vector2 dir = transform.Position - new Vector2(500, 500);
            dir.Normalize();
            if (liveTime <= 0)
            {
                GameWorld.Instance.removeObjects.Add(gameObject);
            }
            else
                liveTime -= GameWorld.Instance.deltaTime;

            gameObject.GetTransform.Translate(dir * speed * GameWorld.Instance.deltaTime);
        }

        public void CreateAnimations()
        {
            animator.CreateAnimation("static", new Animation(1, 0, 0, 16, 16, 6, Vector2.Zero));
            animator.PlayAnimation("static");
        }

    }
}
