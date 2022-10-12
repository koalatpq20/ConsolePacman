using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePacman
{
    public class Pacman : Character
    {
        public const int MAXLIFE = 3;

        // TODO: mở rộng kiểm tra giá trị setter, nếu Life < 0 không gán giá trị nữa
        public int Life { get; set; }

        public string Information 
        { 
            get => $"Pacman : Mạng {Life} - Tọa độ: X {Location.X}-Y {Location.Y}";
        }

        public Pacman(int width, int height, Color color, Point location) : base(width, height, color, location)
        {
            Life = 3;
        }
    }
}
