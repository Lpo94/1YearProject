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

namespace _1YearProject.UI
{
    class GameLogic
    {
        private static GameLogic instance;

        public static GameLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameLogic();
                   
                }
                return instance;
            }
        }
        
        
        
        public void CreateObjects()
        {
            
        }
    }
}
