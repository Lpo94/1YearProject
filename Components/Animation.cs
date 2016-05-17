using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace _1YearProject.Components
{
    class Animation
    {
        int fps;
        Vector2 offset;
        Rectangle[] rectangles;

        public int Fps
        {
            get { return fps; }
            set { fps = value; }
        }

        public Vector2 Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        public Rectangle[] Rectangles
        {
            get { return rectangles; }
            set { rectangles = value; }
        }

        public Animation(int frames, int yPos, int xStratFrame, int width, int height, int FPS, Vector2 offset)
        {
            Rectangles = new Rectangle[frames];

            Offset = offset;

            this.Fps = FPS;

            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle((i + xStratFrame) * width, yPos, width, height);
            }
        }

    }
}
