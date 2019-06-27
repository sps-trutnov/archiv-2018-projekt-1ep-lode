using System;
using System.Collections.Generic;
using System.Threading;
namespace Lode
{
    class Program
    {
        static bool jeNaTahu = true;
        //static int typLode = 0;
        static List<Souradnice> Policka { get;  set;}

        static int rotace = 0;
        static NatoceniLode nat = new NatoceniLode();
        static int[] herniPoleX = new int[10];
        static int[] herniPoleY = new int[10];
        static Souradnice sour = new Souradnice();

        static void Main(string[] args)
        {
            Lod lod = new Lod(TypLode.Clun);
            LidskyHrac hrac = new LidskyHrac(new System.Net.IPAddress(new byte[] { 192,168,216,201}));

            

            sour.X = 2;
            sour.Y = 2;

            //new Hra(new TextoveRozhrani()).SpustitHru();
            while (jeNaTahu)
            {
                Console.CursorVisible = false;

                pohybLode(lod);
                nakresliPole(herniPoleX.Length, herniPoleY.Length);
                vejdeSe(herniPoleX.Length, herniPoleY.Length, lod);
                vykresliLod(lod);
                
            }
            
        }
        
        static void vykresliLod(Lod lod)
        {
            foreach (Souradnice s in lod.Policka)
            {
                Console.SetCursorPosition(s.X , s.Y );
                Console.Write('X');
                
            }

           
        }

        static void pohybLode(Lod lod)
        {
            foreach (Souradnice s in lod.Policka)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'd':

                        s.X++;
                        break;

                    case 'a':

                        s.X--;
                        break;
                }
            }

            /* if (typ == TypLode.Torpedovka)
             {
                 if (rot == NatoceniLode.Stupnu0)
                 {
                     switch (Console.ReadKey(true).KeyChar)
                     {

                         case 'd':
                             if (souradnice.X <= herniPoleX.Length - 3)
                             {
                                 souradnice.X++;
                                 Console.Clear();
                             }
                             break;

                         case 's':
                             if (souradnice.Y <= herniPoleY.Length - 2)
                             {
                                 souradnice.Y++;
                                 Console.Clear();
                             }
                             break;

                         case 'w':

                             if (souradnice.Y > 1 || souradnice.Y == herniPoleY.Length - 2)
                             {
                                 souradnice.Y--;
                                 Console.Clear();
                             }
                             break;

                         case 'a':
                             if (souradnice.X > 1 || souradnice.X == herniPoleX.Length - 2)
                             {
                                 souradnice.X--;
                                 Console.Clear();
                             }
                             break;

                         case 'e':
                             rotace++;
                             if (rotace >= 4)
                             {
                                 rotace = 0;
                             }
                             if (souradnice.Y == 0 || souradnice.Y + 1 == herniPoleY.Length || souradnice.X == 0 || souradnice.X == herniPoleX.Length)
                             {
                                 rotace--;
                             }
                             break;
                     }
                 }

                 if (rot == NatoceniLode.Stupnu90)
                 {
                     switch (Console.ReadKey(true).KeyChar)
                     {

                         case 'd':
                             if (souradnice.X <= herniPoleX.Length - 3)
                             {
                                 souradnice.X++;
                                 Console.Clear();
                             }
                             break;

                         case 's':
                             if (souradnice.Y <= herniPoleY.Length - 3)
                             {
                                 souradnice.Y++;
                                 Console.Clear();
                             }
                             break;

                         case 'w':

                             if (souradnice.Y > 1 || souradnice.Y == herniPoleY.Length - 2)
                             {
                                 souradnice.Y--;
                                 Console.Clear();
                             }
                             break;

                         case 'a':
                             if (souradnice.X > 0 || souradnice.X == herniPoleX.Length)
                             {
                                 souradnice.X--;
                                 Console.Clear();
                             }
                             break;

                         case 'e':
                             rotace++;
                             if (rotace >= 4)
                             {
                                 rotace = 0;
                             }
                             if (souradnice.Y == 0 || souradnice.Y - 1 == herniPoleY.Length || souradnice.X == 0 || souradnice.X == herniPoleX.Length)
                             {
                                 rotace--;
                             }

                             break;
                     }
                 }
                 if (rot == NatoceniLode.Stupnu180)
                 {
                     switch (Console.ReadKey(true).KeyChar)
                     {

                         case 'd':
                             if (souradnice.X <= herniPoleX.Length - 3)
                             {
                                 souradnice.X++;
                                 Console.Clear();
                             }
                             break;

                         case 's':
                             if (souradnice.Y <= herniPoleY.Length - 3)
                             {
                                 souradnice.Y++;
                                 Console.Clear();
                             }
                             break;

                         case 'w':

                             if (souradnice.Y > 0 || souradnice.Y == herniPoleY.Length - 2)
                             {
                                 souradnice.Y--;
                                 Console.Clear();
                             }
                             break;

                         case 'a':
                             if (souradnice.X > 1 || souradnice.X == herniPoleX.Length)
                             {
                                 souradnice.X--;
                                 Console.Clear();
                             }
                             break;

                         case 'e':
                             rotace++;
                             if (rotace >= 4)
                             {
                                 rotace = 0;
                             }
                             if (souradnice.Y == 0 || souradnice.Y - 1 == herniPoleY.Length || souradnice.X == 0 || souradnice.X == herniPoleX.Length)
                             {
                                 rotace--;
                             }

                             break;
                     }
                 }
                 if (rot == NatoceniLode.Stupnu270)
                 {
                     switch (Console.ReadKey(true).KeyChar)
                     {

                         case 'd':
                             if (souradnice.X <= herniPoleX.Length - 2)
                             {
                                 souradnice.X++;
                                 Console.Clear();
                             }
                             break;

                         case 's':
                             if (souradnice.Y <= herniPoleY.Length - 3)
                             {
                                 souradnice.Y++;
                                 Console.Clear();
                             }
                             break;

                         case 'w':

                             if (souradnice.Y > 1 || souradnice.Y == herniPoleY.Length - 2)
                             {
                                 souradnice.Y--;
                                 Console.Clear();
                             }
                             break;

                         case 'a':
                             if (souradnice.X > 1 || souradnice.X == herniPoleX.Length)
                             {
                                 souradnice.X--;
                                 Console.Clear();
                             }
                             break;

                         case 'e':
                             rotace++;

                             if (souradnice.Y == 0 || souradnice.Y - 1 == herniPoleY.Length || souradnice.X == 0 || souradnice.X == herniPoleX.Length - 1)
                             {
                                 rotace--;
                             }
                             if (rotace >= 4)
                             {
                                 rotace = 0;
                             }
                             break;
                     }
                 }
             }

             if (typ == TypLode.Clun)
             {
                 if (rot == NatoceniLode.Stupnu0)
                 {
                     switch (Console.ReadKey(true).KeyChar)
                     {

                         case 'd':
                             if (souradnice.X <= herniPoleX.Length - 3)
                             {
                                 souradnice.X++;
                                 Console.Clear();
                             }
                             break;

                         case 's':
                             if (souradnice.Y <= herniPoleY.Length - 2)
                             {
                                 souradnice.Y++;
                                 Console.Clear();
                             }
                             break;

                         case 'w':

                             if (souradnice.Y > 0 || souradnice.Y == herniPoleY.Length - 1)
                             {
                                 souradnice.Y--;
                                 Console.Clear();
                             }
                             break;

                         case 'a':
                             if (souradnice.X > 0 || souradnice.X == herniPoleX.Length - 1)
                             {
                                 souradnice.X--;
                                 Console.Clear();
                             }
                             break;
                         case 'e':
                             if (muzeSeOtocit(souradnice, nat, TypLode.Clun))
                             {
                                 nat++;
                                 if (nat > NatoceniLode.Stupnu270)
                                 {
                                     nat = NatoceniLode.Stupnu0;
                                 }
                             }
                             break;

                     }
                 }

                 if (rot == NatoceniLode.Stupnu90)
                 {
                     switch (Console.ReadKey(true).KeyChar)
                     {

                         case 'd':
                             if (souradnice.X  < herniPoleX.Length - 1)
                             {
                                 souradnice.X++;
                                 Console.Clear();
                             }
                             break;

                         case 's':
                             if (souradnice.Y <= herniPoleY.Length - 3)
                             {
                                 souradnice.Y++;
                                 Console.Clear();
                             }
                             break;

                         case 'w':

                             if (souradnice.Y > 0 || souradnice.Y == herniPoleY.Length - 1)
                             {
                                 souradnice.Y--;
                                 Console.Clear();
                             }
                             break;

                         case 'a':
                             if (souradnice.X > 0 || souradnice.X == herniPoleX.Length)
                             {
                                 souradnice.X--;
                                 Console.Clear();
                             }
                             break;
                         case 'e':
                             if (muzeSeOtocit(souradnice, nat, TypLode.Clun))
                             {
                                 nat++;
                                 if (nat > NatoceniLode.Stupnu270)
                                 {
                                     nat = NatoceniLode.Stupnu0;
                                 }
                             }
                             break;


                     }
                 }
                 if (rot == NatoceniLode.Stupnu180)
                 {
                     switch (Console.ReadKey(true).KeyChar)
                     {

                         case 'd':
                             if (souradnice.X <= herniPoleX.Length - 3)
                             {
                                 souradnice.X++;
                                 Console.Clear();
                             }
                             break;

                         case 's':
                             if (souradnice.Y <= herniPoleY.Length - 2)
                             {
                                 souradnice.Y++;
                                 Console.Clear();
                             }
                             break;

                         case 'w':

                             if (souradnice.Y > 0 || souradnice.Y == herniPoleY.Length - 1)
                             {
                                 souradnice.Y--;
                                 Console.Clear();
                             }
                             break;

                         case 'a':
                             if (souradnice.X > 0 || souradnice.X == herniPoleX.Length - 1)
                             {
                                 souradnice.X--;
                                 Console.Clear();
                             }
                             break;
                         case 'e':
                             if (muzeSeOtocit(souradnice, nat, TypLode.Clun))
                             {
                                 nat++;
                                 if (nat > NatoceniLode.Stupnu270)
                                 {
                                     nat = NatoceniLode.Stupnu0;
                                 }
                             }
                             break;

                     }
                 }
                 if (rot == NatoceniLode.Stupnu270)
                 {
                     switch (Console.ReadKey(true).KeyChar)
                     {

                         case 'd':
                             if (souradnice.X <= herniPoleX.Length - 2)
                             {
                                 souradnice.X++;
                                 Console.Clear();
                             }
                             break;

                         case 's':
                             if (souradnice.Y <= herniPoleY.Length - 3)
                             {
                                 souradnice.Y++;
                                 Console.Clear();
                             }
                             break;

                         case 'w':

                             if (souradnice.Y > 0 || souradnice.Y == herniPoleY.Length - 2)
                             {
                                 souradnice.Y--;
                                 Console.Clear();
                             }
                             break;

                         case 'a':
                             if (souradnice.X > 0 || souradnice.X == herniPoleX.Length)
                             {
                                 souradnice.X--;
                                 Console.Clear();
                             }
                             break;
                         case 'e':
                             if (muzeSeOtocit(souradnice, nat, TypLode.Clun))
                             {
                                 nat++;
                                 if (nat > NatoceniLode.Stupnu270)
                                 {
                                     nat = NatoceniLode.Stupnu0;
                                 }
                             }
                             break;

                     }
                 }
             }*/


        } 

        static void umistitLod(Souradnice souradnice, NatoceniLode natoceni, TypLode typ)
        {
            
        }

        static void nakresliPole(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                for (int l = 0; l < x; l++)
                {

                    Console.SetCursorPosition(l, i);
                    Console.Write("*");
                }
            }
        }

        

       static bool muzeSeOtocit(Souradnice souradnice, NatoceniLode uhel, TypLode lod)
        {
            if (lod == TypLode.Clun)
            {
                if (uhel == NatoceniLode.Stupnu0)
                {

                    if(souradnice.X  >= 0 && souradnice.Y  < herniPoleY.Length - 1 && souradnice.X < herniPoleX.Length && souradnice.Y > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (uhel == NatoceniLode.Stupnu90)
                {

                    if (souradnice.X >= 0 && souradnice.Y  <= herniPoleY.Length && souradnice.X + 1 <= herniPoleX.Length - 1 && souradnice.Y > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (uhel == NatoceniLode.Stupnu180)
                {

                    if (souradnice.X >= 0 && souradnice.Y < herniPoleY.Length - 1 && souradnice.X < herniPoleX.Length && souradnice.Y > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

                if (uhel == NatoceniLode.Stupnu270)
                {

                    if (souradnice.X >= 0 && souradnice.Y <= herniPoleY.Length && souradnice.X + 1 <= herniPoleX.Length - 1 && souradnice.Y > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        static bool vejdeSe(int X,int Y, Lod lod)
        {
            foreach (Souradnice s in lod.Policka)
            {
                if (s.X <= X || s.X >= 0 || s.Y <= Y || s.Y >= 0)
                {
                    return true;
                }
            }

           return false;
        }
    }
}

