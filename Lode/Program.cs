using System;
namespace Lode
{
    class Program
    {
        static void Main(string[] args)
        {
            bool jeNaTahu = true;
            int y = 0;
            int x = 0;

            //new Hra(new TextoveRozhrani()).SpustitHru();
            while (jeNaTahu)
            {

                if (Console.ReadKey(true).KeyChar == 'd' && x <= 10)
                {
                    x++;
                    Console.Clear();
                }

                else if (Console.ReadKey(true).KeyChar == 's' && y <= 10 )
                {
                    y++;
                    Console.Clear();
                }
                else if (Console.ReadKey(true).KeyChar == 'w' && y >= 0 || y == 10)
                {
                    y--;
                    Console.Clear();
                }
                else if (Console.ReadKey(true).KeyChar == 'a' && x >= 0 || x == 10)
                {
                    x--;
                    Console.Clear();
                }
                nakresliPole();
                Console.SetCursorPosition(x, y);
                
                Console.Write('X');
            }
            void nakresliPole()
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int l = 0; l < 10; l++)
                    {
                        Console.SetCursorPosition(l, i);
                        Console.Write(" ");
                    }
                }
            }

        }
    }
}
