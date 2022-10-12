using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsolePacman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            //Init game info - khởi tạo thông số của game
            int width = 50;
            int height = 50;
            int totalPoint = 0;

            //Initialize character - khởi tạo nhân vật
            Pacman pacman = new Pacman(Character.WIDTH, Character.HEIGHT, Color.Yellow, new Point(25, 25));
            Monster redMonster = new Monster(Character.WIDTH, Character.HEIGHT, Color.Red, new Point(25, 10));

            //Init fruit list - khởi tạo list trái cây
            List<Fruit> listFruit = new List<Fruit>();
            listFruit.Add(new Fruit(new Point(20, 20), "Cherry", 30));
            listFruit.Add(new Fruit(new Point(10, 40), "Apple", 50));

            Console.WriteLine("Bắt đầu Game Pacman...");
            Console.WriteLine("Nhập mũi tên lên - xuống - trái - phải để điều khiển Pacman \n");
            DisplayInfo(pacman, redMonster, ref totalPoint);
            
            while (pacman.Life <= Pacman.MAXLIFE)
            {
                //Move Pacman - đọc input key và di chuyển Pacman
                var inputKey = Console.ReadKey(false).Key;

                switch (inputKey)
                {
                    case ConsoleKey.UpArrow:
                        pacman.Move(Direction.Up);
                        break;
                        
                    case ConsoleKey.DownArrow:
                        pacman.Move(Direction.Down);
                        break;

                    case ConsoleKey.LeftArrow:
                        pacman.Move(Direction.Left);
                        break;

                    case ConsoleKey.RightArrow:
                        pacman.Move(Direction.Right);
                        break;
                }

                //Move monster - di chuyển quái vật theo chiều đi xuống
                redMonster.Move(Direction.Down);

                CheckStep(pacman, redMonster, listFruit,ref totalPoint);
                DisplayInfo(pacman, redMonster, ref totalPoint);

                //Exit game
                if (pacman.Life <= 0)
                {
                    Console.WriteLine("Game over... - Bạn đã mất hết mạng");
                    break;
                }
            }

            Console.WriteLine("Thoát game...");
            Console.ReadLine();
        }

        private static void CheckStep(Pacman pacman, Monster monster, List<Fruit> listFruit, ref int totalPoint)
        {
            if (pacman.CheckCollisionCharacter(monster))
            {
                pacman.Life -= 1;
                Console.WriteLine("Bạn đụng quái vật, mất mạng");                
            }
            else
            {
                //Lấy danh sách những Fruit chưa được ăn
                List<Fruit> listFruitNotEat = listFruit.Where(f => f.Eaten == false).ToList();

                foreach (var fruit in listFruitNotEat)
                {
                    if (pacman.CheckCollisionFruit(fruit))
                    {
                        totalPoint += fruit.Value;
                        fruit.Eaten = true;

                        Console.WriteLine($"Bạn ăn được {fruit.Name} - được {fruit.Value} điểm");
                    }
                }
            }
        }

        private static void DisplayInfo(Pacman pacman, Monster monster, ref int totalPoint)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine(pacman.Information);
            Console.WriteLine(monster.Information);
            Console.WriteLine(String.Format("Tổng điểm: {0}", totalPoint));
            Console.WriteLine("--------------------------");
        }
    }
}
