using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using _1YearProject.Interfaces;

namespace _1YearProject.Components
{
    class Collider : Component, ILoad, IDraw, IUpdate
    {
        private SpriteRenderer spriteRenderer;
        private Texture2D texture2D;
        private bool doCollisionChecks;
        private Animator animator;
        private List<Collider> otherColliders = new List<Collider>();
        private Dictionary<string, Color[][]> pixels;

        /**private Color[] CurrentPixels
        {
            get { return pixels.Value[animator.AnimationName][animator.currentIndex]};
        }*/

        public Collider(GameObject gameObject) : base(gameObject)
        {
            doCollisionChecks = true;

            GameWorld.colliders.Add(this);
        }

        public void Update()
        {
            CheckCollision();
        }

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle
                    (
                    (int)(gameObject.GetTransform.Position.X + spriteRenderer.Offset.X),
                    (int)(gameObject.GetTransform.Position.Y + spriteRenderer.Offset.Y),
                    spriteRenderer.Rectangle.Width,
                    spriteRenderer.Rectangle.Height
                    );
            }
        }

        public void LoadContent(ContentManager content)
        {
            spriteRenderer = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");

            texture2D = content.Load<Texture2D>("CollisionTexture");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle topLine = new Rectangle(CollisionBox.X, CollisionBox.Y, CollisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(CollisionBox.X, CollisionBox.Y + CollisionBox.Height, CollisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(CollisionBox.X + CollisionBox.Width, CollisionBox.Y, 1, CollisionBox.Height);
            Rectangle leftLine = new Rectangle(CollisionBox.X, CollisionBox.Y, 1, CollisionBox.Height);
            spriteBatch.Draw(texture2D, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture2D, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture2D, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture2D, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }

        public void SetDoCollisionChecks()
        {

        }

        private void CheckCollision()
        {
            if (doCollisionChecks)
            {
                foreach (Collider other in GameWorld.colliders)
                {
                    if (other != this)
                    {
                        if (CollisionBox.Intersects(other.CollisionBox))
                        {

                            gameObject.OnCollisionEnter(other);
                            otherColliders.Add(other);

                        }
                        else if (!CollisionBox.Intersects(other.CollisionBox))
                        {

                            otherColliders.Remove(other);
                        }
                    }
                }
            }
        }
    }
    }
