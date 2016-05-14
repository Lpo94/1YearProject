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
    class SpriteRenderer : Component, IDraw, ILoad
    {
        private Rectangle rectangle;
        private Texture2D sprite;
        private string spriteName;
        private float layerDepth;
        private SpriteEffects effects;
        private Vector2 offset;
        private Vector2 pos;
        private Transform transform;
        private Color color = Color.White;

        internal Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public Vector2 Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        public Texture2D Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }


        public SpriteRenderer(GameObject gameObject, string spriteName, float layerDepth,Vector2 pos) : base(gameObject)
        {
            this.spriteName = spriteName;
            this.layerDepth = layerDepth;
            this.transform = (Transform)gameObject.GetComponent("transform");        }

        public void Update()
        {
            
        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, gameObject.GetTransform.Position, rectangle, color, 0, Vector2.Zero, 1, SpriteEffects.None, layerDepth);
        }
    }
}
