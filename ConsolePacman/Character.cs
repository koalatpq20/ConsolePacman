using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Text;


namespace ConsolePacman
{
    /// <summary>
    /// Kiểu hướng đi
    /// </summary>
    public enum Direction
    { 
        Right,
        Left,
        Up,
        Down,
    }

    /// <summary>
    /// Lớp cha nhân vật
    /// </summary>
    public class Character
    {
        public const int WIDTH = 5;
        public const int HEIGHT = 5;
        protected const int STEP = 1;
        
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Color { get; set; }
        public Point Location { get; set; }

        public Character(int width, int height, Color color, Point location)
        {
            Width = width;
            Height = height;
            Color = color;
            Location = location;
        }        

        /// <summary>
        /// Phương thức di chuyển nhân vật
        /// </summary>
        /// <param name="direction">Tham số hướng di chuyển</param>
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    Location = new Point(Location.X + STEP, Location.Y);
                    break;

                case Direction.Left:
                    Location = new Point(Location.X - STEP, Location.Y);
                    break;

                case Direction.Up:
                    Location = new Point(Location.X, Location.Y - STEP);
                    break;

                case Direction.Down:
                    Location = new Point(Location.X, Location.Y + STEP);
                    break;
            }
        }

        /// <summary>
        /// Hàm kiểm tra xung đột với nhân vật
        /// </summary>
        /// <param name="character">Nhân vật kiểm tra</param>
        /// <returns>boolean đúng sai</returns>
        public bool CheckCollisionCharacter(Character character)
        {
            //Kiểm tra va chạm theo các hướng Up - Down - Right - Left            
            int spaceX = Convert.ToInt32(Math.Abs(character.Location.X - Location.X));
            int spaceY = Convert.ToInt32(Math.Abs(character.Location.Y - Location.Y));

            if ((spaceX < character.Width || spaceX < Width) && (spaceY < character.Height || spaceY < Height))
                return true;
            else
                return false;

            // Kiểm tra va chạm đơn giản  - 2 tọa độ trùng nhau
            //if (Location.X == character.Location.X && Location.Y == character.Location.Y)
            //    return true;
            //else
            //    return false;
        }

        /// <summary>
        /// Kiểm tra xung đột với fruit
        /// </summary>
        /// <param name="fruit">Trái cây</param>
        /// <returns>Boolean</returns>
        public bool CheckCollisionFruit(Fruit fruit)
        {
            //TODO: kiểm tra va chạm theo các hướng Up - Down - Right - Left
            

            // Kiểm tra va chạm đơn giản  - 2 tọa độ trùng nhau
            if (Location.X == fruit.Location.X && Location.Y == fruit.Location.Y)
                return true;
            else
                return false;
        }
    }
}
