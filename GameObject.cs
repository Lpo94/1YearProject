using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using _1YearProject.Components;
using _1YearProject.Interfaces;

namespace _1YearProject
{
    class GameObject : Component
    {
        private Transform transform;
        private List<Component> components;
        private bool isloaded = false;


        public Transform GetTransform
        {
            get { return transform; }
        }

        public List<Component> Components
        {
            get { return components; }
            set { components = value; }
        }

        public GameObject()
        {
            components = new List<Component>();
            transform = GetTransform;
            this.transform = new Transform(this, Vector2.Zero);

        }

        public void LoadContent(ContentManager content)
        {
            if (!isloaded)
            {


                foreach (Component com in components)
                {

                    if (com is ILoad)
                    {
                        (com as ILoad).LoadContent(content);
                    }
                }
                isloaded = true;
            }
        }

        public void Update()
        {
            foreach (Component com in components)
            {
                if (com is IUpdate)
                {
                    (com as IUpdate).Update();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component com in components)
            {
                if (com is IDraw)
                {
                    (com as IDraw).Draw(spriteBatch);
                }
            }
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
        }

        public Component GetComponent(string component)
        {
            return components.Find(x => x.GetType().Name == component);
        }

        public void OnAnimationDone(string animationName)
        {
            foreach (Component component in components)
            {
                if (component is IAnimateable)
                {
                    (component as IAnimateable).OnAnimationDone(animationName);
                }
            }
        }

        public void OnCollisionEnter(Collider other)
        {
            foreach (Component comp in components)
            {
                if (comp is ICollisionEnter)
                {
                    (comp as ICollisionEnter).OnCollisionEnter(other);
                }
            }
        }

        public void OnCollisionExit(Collider other)
        {
            foreach (Component comp in components)
            {
                if (comp is ICollisionExit)
                {
                    (comp as ICollisionExit).OnCollisionExit(other);
                }
            }
        }
    }
}
