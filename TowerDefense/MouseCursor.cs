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
    class MouseCursor:Component,IDraw,ILoad,IUpdate,ICollisionExit,ICollisionEnter
    {
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
            throw new NotImplementedException();
        }

        public void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
