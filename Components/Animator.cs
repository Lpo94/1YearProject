using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using _1YearProject.Interfaces;

namespace _1YearProject.Components
{
    class Animator: Component,IUpdate
    {
        SpriteRenderer spriteRenderer;
        int currentIndex;
        float timeElapsed;
        float fps;
        Rectangle[] rectangles;
        private string animationName;
        public Dictionary<string, Animation> animations;

        public Animator(GameObject gameObject) : base(gameObject)
        {
            animations = new Dictionary<string, Animation>();
            fps = 5;
            this.spriteRenderer = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");
        }

        public void Update()
        {
            timeElapsed += GameWorld.Instance.deltaTime;

            currentIndex = (int)(timeElapsed * fps);

            if (currentIndex > rectangles.Length - 1)
            {
                gameObject.OnAnimationDone(animationName);
                timeElapsed = 0;
                currentIndex = 0;
            }
            spriteRenderer.Rectangle = rectangles[currentIndex];
        }

        public void CreateAnimation(string name, Animation animation)
        {
            if (!animations.ContainsKey(name))
            {
                animations.Add(name, animation);
            }


        }

        public void PlayAnimation(string animationName)
        {
            if (this.animationName != animationName)
            {
                this.rectangles = animations[animationName].Rectangles;

                this.spriteRenderer.Rectangle = rectangles[0];

                this.spriteRenderer.Offset = animations[animationName].Offset;

                this.animationName = animationName;

                this.fps = animations[animationName].Fps;

                timeElapsed = 0;

                currentIndex = 0;

            }
        }
    }
}
