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
    class MouseCursor:Component,ILoad,IUpdate,ICollisionExit,ICollisionEnter
    {
       
        private static MouseCursor instance;

        private Transform transform;
        private Animator animator;
        private Collider collider;


        private static GameObject myGameObject = new GameObject();

        public static MouseCursor Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MouseCursor(myGameObject);
                }
                return instance;
            }
        }

        private MouseCursor(GameObject gameObject) : base(gameObject)
        {

            gameObject.AddComponent(new Transform(gameObject, Vector2.Zero));

            transform = gameObject.GetTransform;

            gameObject.AddComponent(new SpriteRenderer(gameObject, "Textbox", 1, transform.Position));

            gameObject.AddComponent(new Player(gameObject));

            gameObject.AddComponent(new Animator(gameObject));

            gameObject.AddComponent(new Collider(gameObject));
            
           
        }

        public void OnCollisionExit(Collider other)
        {
            if (TowerIcon.Clicked == true)
            {
                GameWorld.Instance.canBuild = true;
            }
        }

        public void OnCollisionEnter(Collider other)
        {
            GameWorld.Instance.canBuild = false;
        }

        public void Update()
        {
            
            transform.Position = new Vector2(Mouse.GetState().X-16,Mouse.GetState().Y-16);
            
            
        }

        public void LoadContent(ContentManager content)
        {
            collider = (Collider)gameObject.GetComponent("Collider");
            animator = (Animator)gameObject.GetComponent("Animator");
            CreateAnimations();
        }

        public void CreateAnimations()
        {
            animator.CreateAnimation("static", new Animation(1, 0, 0, 16, 16, 6, Vector2.Zero));
            animator.PlayAnimation("static");
        }
    }
}
