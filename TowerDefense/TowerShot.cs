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

        private Transform enemyTransform;


        public TowerShot(GameObject gameObject, float dmg, float speed, Vector2 pos, GameObject enemy) : base(gameObject)
        {
            enemyTransform = enemy.GetTransform;
            this.dmg = dmg;
            this.speed = speed;
            transform = gameObject.GetTransform;
            transform.Position = pos;
        }

        public void LoadContent(ContentManager content)
        {
            this.animator = (Animator)gameObject.GetComponent("Animator");
            CreateAnimations();
        }

        public void Update()
        {
            Vector2 dir = transform.Position - enemyTransform.Position;
            dir.Normalize();

            if (liveTime <= 0)
            {
                GameWorld.Instance.removeObjects.Add(gameObject);

            }
            else
                liveTime -= GameWorld.Instance.deltaTime;

            if (200 > transform.Position.Y || 4000 < transform.Position.Y || 200 > transform.Position.X || 4000 < transform.Position.X)
            {
                GameWorld.Instance.removeObjects.Add(gameObject);
            }
            gameObject.GetTransform.Translate(-dir * speed * GameWorld.Instance.deltaTime);
        }

        public void CreateAnimations()
        {
            animator.CreateAnimation("static", new Animation(1, 0, 0, 6, 6, 6, Vector2.Zero));
            animator.PlayAnimation("static");
        }

    }
}
