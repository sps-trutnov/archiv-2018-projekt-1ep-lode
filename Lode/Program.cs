using System;
using System.Threading;
namespace Lode
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool jeNaTahu = true;

            int[] herniPoleX = new int[10];
            int[] herniPoleY = new int[10];
            Souradnice sour = new Souradnice();
            sour.X = 1;
            sour.Y = 1;
            //new Hra(new TextoveRozhrani()).SpustitHru();
            while (jeNaTahu)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    
                    case 'd' :
                        if (sour.X <= 10 - 3)
                        {
                            sour.X++;
                            Console.Clear();
                        }
                    break;

                    case 's':
                        if (sour.Y <= 10 - 2)
                        {
                            sour.Y++;
                            Console.Clear();
                        }
                    break;

                    case 'w':
                        if (sour.Y > 1 || sour.Y == 10 - 2)
                        {
                            sour.Y--;
                            Console.Clear();
                        }
                    break;

                    case 'a':
                        if (sour.X > 1 || sour.X == 10 - 2)
                        {
                            sour.X--;
                            Console.Clear();
                        }
                    break;
                    case 'e':

                    break;
                }

                Console.CursorVisible = false;

                nakresliPole();
                vykresliLod(0);

            }
            void vykresliLod(int typ)
            {
                if (typ == (int)TypLode.Clun)
                {
                    Console.SetCursorPosition(sour.X, sour.Y);
                    Console.Write('X');
                    Console.SetCursorPosition(sour.X - 1, sour.Y);
                    Console.Write('X');
                    Console.SetCursorPosition(sour.X + 1, sour.Y);
                    Console.Write('X');
                    Console.SetCursorPosition(sour.X, sour.Y - 1);
                    Console.Write('X');
                }
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
