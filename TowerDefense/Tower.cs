using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1YearProject.Components;
using _1YearProject.Interfaces;
using _1YearProject.UI;
using _1YearProject.Builder;
using _1YearProject.TowerDefense;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace _1YearProject
{
    class Tower : Component, IUpdate, ILoad, IDraw
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
        private List<GameObject> myTargets;
        private GameObject tar;

        public float upgSpeed { get; set; }
        public bool Clicked { get; set; }
        public float Dmg { get; set; }
        public float atkSpeed { get; set; }
        private float myAttackSpeed;

        public float Range { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

        private SpriteFont font;

        public static bool towerClicked = false;
        private bool clicked = false;

        private Director bulletDirector = new Director(new BulletBuilder());


        public Tower(GameObject gameObject, string type, Vector2 pos) : base(gameObject)
        {
            this.Type = type;
            myTargets = new List<GameObject>();
            transform = gameObject.GetTransform;
            switch (type)
            {
                case "normal":
                    Dmg = 1;
                    atkSpeed = 500;
                    myAttackSpeed = atkSpeed;
                    Range = 3000;
                    Price = 100;
                    break;
            }
            transform.Position = pos;
        }


        public void Update()
        {
            if (collider.CollisionBox.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                clicked = true;
                towerClicked = true;
            }
            else if (!collider.CollisionBox.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                clicked = false;
                towerClicked = false;
            }

            foreach (GameObject go in GameWorld.Instance.tempObj)
            {
                if (go.CheckComponent("Player") == true)
                {
                    if (Vector2.Distance(go.GetTransform.Position, transform.Position) < Range)
                    {
                        myTargets.Add(go);
                    }
                }
            }
            if (upgDMG == true && upgSpeed <= 0)
            {
                UPGDamage();
                upgDMG = false;
            }
            myTargets.Sort();

            if (myTargets.Count != 0)
            {
                Shoot(myTargets[0]);
            }
        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("font");
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
            if (clicked == true)
            {
                spriteBatch.DrawString(font, "Attack DMG " + Dmg + "\n Attack Speed " + myAttackSpeed / 1000 + "\n Range " + Range, new Vector2(50, 650), Color.Pink);
            }
        }

        public void Shoot(GameObject tar)
        {
            if (atkSpeed <= 0)
            {
                CreateBullet(new Vector2(transform.Position.X + 9, transform.Position.Y), 0.5f, 1, tar);
                atkSpeed = myAttackSpeed;
            }
            else
                atkSpeed -= GameWorld.Instance.deltaTime;
        }

        public void UPGDamage()
        {
            if (Mainbuilding.Gold >= 10)
            {
                Dmg += 2;
                Mainbuilding.Gold -= 10;
            }
        }

        internal void CreateBullet(Vector2 pos, float speed, float dmg, GameObject enemy)
        {

            bulletDirector.Construct(pos, speed, dmg, enemy);
            GameObject bullet = bulletDirector.GetGameObject();
            bullet.LoadContent(GameWorld.Instance.Content);
            GameWorld.Instance.inGame.Add(bullet);


        }
    }
}
