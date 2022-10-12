using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePacman
{
    public class Monster : Character
    {
        public string Information
        {
            get => $"Monster : Tọa độ X {Location.X}-Y {Location.Y}";
        }

        public Monster(int width, int height, Color color, Point location) : base(width, height, color, location)
        {
        }
    }
}
