using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePacman
{
    public class Fruit
    {
        public Point Location { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public bool Eaten { get; set; }

        public Fruit(Point location, string name, int value)
        {
            Location = location;
            Name = name;
            Value = value;
            Eaten = false;
        }
    }
}
