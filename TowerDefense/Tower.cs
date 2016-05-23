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
    class Tower : Component, IUpdate, ILoad
    {

        private Transform transform;
        private Collider collider;
        private Animator animator;
        private static bool upgDMG = false;

        public static bool UpgDMG
        {
            get { return upgDMG; }
            set { upgDMG = value; }
        }

        public float upgSpeed { get; set; }
        public bool Clicked { get; set; }
        public float Dmg { get; set; }
        public float atkSpeed { get; set; }
        private float myAttackSpeed;
        public float Range { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

        public Tower(GameObject gameObject, string type, Vector2 pos) : base(gameObject)
        {
            this.Type = type;

            transform = gameObject.GetTransform;
            switch (type)
            {
                case "normal":
                    Dmg = 1;
                    atkSpeed = 500;
                    myAttackSpeed = atkSpeed;
                    Range = 3;
                    Price = 100;
                    break;
            }
            transform.Position = pos;
        }


        public void Update()
        {
            bool kage = false;
            if (kage == false)
            {
                Shoot();
                kage = true;
            }

            if(upgDMG == true && upgSpeed <= 0)
            {
                UPGDamage();
                upgDMG = false;
            }
        }

        public void LoadContent(ContentManager content)
        {
            this.collider = (Collider)gameObject.GetComponent("Collider");
            this.animator = (Animator)gameObject.GetComponent("Animator");
            CreateAnimations();
        }

        public void CreateAnimations()
        {
            animator.CreateAnimation("static", new Animation(1, 0, 0, 36, 36, 6, Vector2.Zero));
            animator.PlayAnimation("static");
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Shoot()
        {
            if (atkSpeed <= 0)
            {
                GameWorld.Instance.CreateBullet(new Vector2(transform.Position.X + 9, transform.Position.Y), 0.5f, 1);
                atkSpeed = myAttackSpeed;
            }
            else
                atkSpeed -= GameWorld.Instance.deltaTime;
        }

        public void UPGDamage()
        {
            if(Mainbuilding.Gold >= Price)
            {
                Dmg += 2;
                Mainbuilding.Gold -= Price;
            }
        }
    }
}
