using System;
namespace Lode
{
    class Program
    {
        static void Main(string[] args)
        {
            bool jeNaTahu = true;
            int y = 1;
            int x = 1;
            int[] herniPoleX = new int[10];
            int[] herniPoleY = new int[10];
            //new Hra(new TextoveRozhrani()).SpustitHru();
            while (jeNaTahu)
            {
                Console.CursorVisible = false;
                if (Console.ReadKey(true).KeyChar == 'd' && x <= 10-1)
                {
                    x++;
                    
                    Console.Clear();
                }

                else if (Console.ReadKey(true).KeyChar == 's' && y <= 10-1 )
                {
                    y++;
                    Console.Clear();
                }
                else if (Console.ReadKey(true).KeyChar == 'w' && y > 1 || y == 10-1)
                {
                    y--;
                    Console.Clear();
                }
                else if (Console.ReadKey(true).KeyChar == 'a' && x > 1 || x == 10-1)
                {
                    x--;
                    Console.Clear();
                }
                nakresliPole();
                Console.SetCursorPosition(x, y);
                Console.Write('X');
                Console.SetCursorPosition(x - 1, y);
                Console.Write('X');
                Console.SetCursorPosition(x + 1, y);
                Console.Write('X');
                Console.SetCursorPosition(x, y - 1);
                Console.Write('X');

            }
            void nakresliPole()
            {
                for (int i = 0; i < herniPoleY.Length; i++)
                {
                    for (int l = 0; l < herniPoleY.Length; l++)
                    {
                        Console.SetCursorPosition(l, i);
                        Console.Write("*");
                    }
                }
            }

        }
    }
}
