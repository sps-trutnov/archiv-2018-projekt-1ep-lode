using System;
using System.Threading;
namespace Lode
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool jeNaTahu = true;
            int typLode = 0;
            int rotace = 0;
            
            int[] herniPoleX = new int[10];
            int[] herniPoleY = new int[10];
            Souradnice sour = new Souradnice();
            sour.X = 2;
            sour.Y = 2;
            //new Hra(new TextoveRozhrani()).SpustitHru();
            while (jeNaTahu)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    
                    case 'd' :
                        if (sour.X <= 10 - 3 && typLode == (int)TypLode.Torpedovka)
                        {
                            sour.X++;
                            Console.Clear();
                        }
                    break;

                    case 's':
                        if (sour.Y <= 10 - 2 && typLode == (int)TypLode.Torpedovka)
                        {
                           sour.Y++;
                            Console.Clear();
                        }
                    break;

                    case 'w':

                        if (sour.Y > 1 || sour.Y == 10 - 2 && typLode == (int)TypLode.Torpedovka)
                        {
                            sour.Y--;
                            Console.Clear();
                        }
                    break;

                    case 'a':
                        if (sour.X > 1 || sour.X == 10 - 2 && typLode == (int)TypLode.Torpedovka)
                        {
                            sour.X--;
                            Console.Clear();
                        }
                    break;
                    case 'e':
                        rotace++;
                        if (rotace >= 4)
                        {
                            rotace = 0;
                        }
                        if(rotace == 2 && sour.Y + 1 == 10)
                        {
                            rotace = 1;
                        }
                        else if(rotace == 1 && sour.Y + 1 == 10)
                        {
                            rotace = 0;
                        }
                       

                    break;
                }

                Console.CursorVisible = false;

                nakresliPole();
                vykresliLod(typLode,rotace);




            }
            void vykresliLod(int typ,int rot)

            {
                if (typ == (int)TypLode.Torpedovka)
                {

                    switch (rot)
                    {
                        case 0:
                            Console.SetCursorPosition(sour.X, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X - 1, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X + 1, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y - 1);
                            Console.Write('X');
                            break;
                        case 1:
                            Console.SetCursorPosition(sour.X, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y - 1);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y + 1);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X + 1, sour.Y);
                            Console.Write('X');
                            break;
                        case 2:
                            Console.SetCursorPosition(sour.X, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X - 1, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X + 1, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y + 1);
                            Console.Write('X');
                            break;
                        case 3:
                            Console.SetCursorPosition(sour.X, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y - 1);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y + 1);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X - 1, sour.Y);
                            Console.Write('X');
                            break;
                    }

              

                }
               else if (typ == (int)TypLode.Clun)
                {
                    switch (rot)
                    {

                        case 0:
                            Console.SetCursorPosition(sour.X, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X + 1, sour.Y);
                            Console.Write('X');
                        break;
                        case 1:
                            Console.SetCursorPosition(sour.X, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y + 1);
                            Console.Write('X');
                        break;
                        case 2:
                            Console.SetCursorPosition(sour.X, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X - 1, sour.Y);
                            Console.Write('X');
                        break;
                        case 3:
                            Console.SetCursorPosition(sour.X, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y - 1);
                            Console.Write('X');

                          break;

             

       
                    }
                }
               else if (typ == (int)TypLode.Kriznik)
                {
                    switch (rot)
                    {
                        case 0:
                            Console.SetCursorPosition(sour.X - 1, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X + 1, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X + 2, sour.Y);
                            Console.Write('X');
                        break;
                        case 1:
                            Console.SetCursorPosition(sour.X, sour.Y - 1);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y + 1);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y + 2);
                            Console.Write('X');
                        break;
                        case 2:
                            Console.SetCursorPosition(sour.X + 1, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X - 1, sour.Y);
                            Console.Write('X');

                      
                    


                

                            Console.SetCursorPosition(sour.X - 2, sour.Y);
                            Console.Write('X');
                        break;
                        case 3:
                            Console.SetCursorPosition(sour.X, sour.Y + 1);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y - 1);
                            Console.Write('X');
                            Console.SetCursorPosition(sour.X, sour.Y - 2);
                            Console.Write('X');
                        break;
                    }
                }
               
            }

           
            

           
            

           
            

           
            void nakresliPole()
            {
                for (int i = 0; i < herniPoleY.Length; i++)
                {
                    for (int l = 0; l < herniPoleX.Length; l++)
                    {
                        Console.SetCursorPosition(l, i);
                        Console.Write("*");
                    }
                }
            }
        }
    }
}
