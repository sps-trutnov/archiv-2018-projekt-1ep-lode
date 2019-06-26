using System;
using System.Threading;

namespace Lode
{
    class Program
    {
        static bool jeNaTahu = true;
        static int typLode = 0;
        static int rotace = 0;

        static int[] herniPoleX = new int[10];
        static int[] herniPoleY = new int[10];
        static Souradnice sour = new Souradnice();

        static void Main(string[] args)
        {
            //new Hra().SpustitHru();
            // p.RozhodnoutVlastniTah();

            //PocitacovyHrac p = new PocitacovyHrac();

            // new Hra(new TextoveRozhrani()).SpustitHru();

            PocitacovyHrac ai = new PocitacovyHrac();
            ai.RozmistitLode();


        }

        static void vykresliLod(int typ, int rot)
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
                        Console.SetCursorPosition(sour.X + 1, sour.Y);
                        Console.Write('X');
                        break;
                    case 3:
                        Console.SetCursorPosition(sour.X, sour.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X, sour.Y + 1);
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
                        Console.SetCursorPosition(sour.X - 1, sour.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X, sour.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X + 1, sour.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X + 2, sour.Y);
                        Console.Write('X');
                        break;
                    case 3:
                        Console.SetCursorPosition(sour.X, sour.Y - 1);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X, sour.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X, sour.Y + 1);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X, sour.Y + 2);
                        Console.Write('X');
                        break;
                }
            }
            else if (typ == (int)TypLode.Letadlovka)
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
                        Console.SetCursorPosition(sour.X, sour.Y - 1);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X + 1, sour.Y - 1);
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
                        Console.SetCursorPosition(sour.X + 1, sour.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X + 1, sour.Y + 1);
                        Console.Write('X');
                        break;
                    case 2:
                        Console.SetCursorPosition(sour.X - 1, sour.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X, sour.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X + 1, sour.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X + 2, sour.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X, sour.Y + 1);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X + 1, sour.Y + 1);
                        Console.Write('X');
                        break;
                    case 3:
                        Console.SetCursorPosition(sour.X, sour.Y - 1);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X, sour.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X, sour.Y + 1);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X, sour.Y + 2);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X - 1, sour.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(sour.X - 1, sour.Y + 1);
                        Console.Write('X');
                        break;
                }
            }
        }

        static void pohybLode(int typ, int rot)
        {
            if (typ == (int)TypLode.Torpedovka)
            {
                if (rot == 0)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {

                        case 'd':
                            if (sour.X <= herniPoleX.Length - 3)
                            {
                                sour.X++;
                                Console.Clear();
                            }
                            break;

                        case 's':
                            if (sour.Y <= herniPoleY.Length - 2)
                            {
                                sour.Y++;
                                Console.Clear();
                            }
                            break;

                        case 'w':

                            if (sour.Y > 1 || sour.Y == herniPoleY.Length - 2)
                            {
                                sour.Y--;
                                Console.Clear();
                            }
                            break;

                        case 'a':
                            if (sour.X > 1 || sour.X == herniPoleX.Length - 2)
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
                            if (sour.Y == 0 || sour.Y + 1 == herniPoleY.Length || sour.X == 0 || sour.X == herniPoleX.Length)
                            {
                                rotace--;
                            }
                            break;
                    }
                }

                if (rot == 1)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {

                        case 'd':
                            if (sour.X <= herniPoleX.Length - 3)
                            {
                                sour.X++;
                                Console.Clear();
                            }
                            break;

                        case 's':
                            if (sour.Y <= herniPoleY.Length - 3)
                            {
                                sour.Y++;
                                Console.Clear();
                            }
                            break;

                        case 'w':

                            if (sour.Y > 1 || sour.Y == herniPoleY.Length - 2)
                            {
                                sour.Y--;
                                Console.Clear();
                            }
                            break;

                        case 'a':
                            if (sour.X > 0 || sour.X == herniPoleX.Length)
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
                            if (sour.Y == 0 || sour.Y - 1 == herniPoleY.Length || sour.X == 0 || sour.X == herniPoleX.Length)
                            {
                                rotace--;
                            }

                            break;
                    }
                }
                if (rot == 2)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {

                        case 'd':
                            if (sour.X <= herniPoleX.Length - 3)
                            {
                                sour.X++;
                                Console.Clear();
                            }
                            break;

                        case 's':
                            if (sour.Y <= herniPoleY.Length - 3)
                            {
                                sour.Y++;
                                Console.Clear();
                            }
                            break;

                        case 'w':

                            if (sour.Y > 0 || sour.Y == herniPoleY.Length - 2)
                            {
                                sour.Y--;
                                Console.Clear();
                            }
                            break;

                        case 'a':
                            if (sour.X > 1 || sour.X == herniPoleX.Length)
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
                            if (sour.Y == 0 || sour.Y - 1 == herniPoleY.Length || sour.X == 0 || sour.X == herniPoleX.Length)
                            {
                                rotace--;
                            }

                            break;
                    }
                }
                if (rot == 3)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {

                        case 'd':
                            if (sour.X <= herniPoleX.Length - 2)
                            {
                                sour.X++;
                                Console.Clear();
                            }
                            break;

                        case 's':
                            if (sour.Y <= herniPoleY.Length - 3)
                            {
                                sour.Y++;
                                Console.Clear();
                            }
                            break;

                        case 'w':

                            if (sour.Y > 1 || sour.Y == herniPoleY.Length - 2)
                            {
                                sour.Y--;
                                Console.Clear();
                            }
                            break;

                        case 'a':
                            if (sour.X > 1 || sour.X == herniPoleX.Length)
                            {
                                sour.X--;
                                Console.Clear();
                            }
                            break;

                        case 'e':
                            rotace++;

                            if (sour.Y == 0 || sour.Y - 1 == herniPoleY.Length || sour.X == 0 || sour.X == herniPoleX.Length - 1)
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

            if (typ == (int)TypLode.Clun)
            {
                if (rot == 0)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {

                        case 'd':
                            if (sour.X <= herniPoleX.Length - 3)
                            {
                                sour.X++;
                                Console.Clear();
                            }
                            break;

                        case 's':
                            if (sour.Y <= herniPoleY.Length - 2)
                            {
                                sour.Y++;
                                Console.Clear();
                            }
                            break;

                        case 'w':

                            if (sour.Y > 0 || sour.Y == herniPoleY.Length -1)
                            {
                                sour.Y--;
                                Console.Clear();
                            }
                            break;

                        case 'a':
                            if (sour.X > 0 || sour.X == herniPoleX.Length - 1)
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
                            if (sour.Y == 0 || sour.Y + 1 == herniPoleY.Length || sour.X == 0 || sour.X == herniPoleX.Length )
                            {
                                rotace--;
                            }
                            break;
                    }
                }

                if (rot == 1)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {

                        case 'd':
                            if (sour.X <= herniPoleX.Length - 2)
                            {
                                sour.X++;
                                Console.Clear();
                            }
                            break;

                        case 's':
                            if (sour.Y <= herniPoleY.Length - 3)
                            {
                                sour.Y++;
                                Console.Clear();
                            }
                            break;

                        case 'w':

                            if (sour.Y > 0 || sour.Y == herniPoleY.Length - 1)
                            {
                                sour.Y--;
                                Console.Clear();
                            }
                            break;

                        case 'a':
                            if (sour.X > 0 || sour.X == herniPoleX.Length)
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
                            if (sour.Y == 0 || sour.Y - 1 == herniPoleY.Length || sour.X == 0 || sour.X == herniPoleX.Length - 1)
                            {
                                rotace--;
                            }

                            break;
                    }
                }
                if (rot == 2)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {

                        case 'd':
                            if (sour.X <= herniPoleX.Length - 3)
                            {
                                sour.X++;
                                Console.Clear();
                            }
                            break;

                        case 's':
                            if (sour.Y <= herniPoleY.Length - 2)
                            {
                                sour.Y++;
                                Console.Clear();
                            }
                            break;

                        case 'w':

                            if (sour.Y > 0 || sour.Y == herniPoleY.Length - 1)
                            {
                                sour.Y--;
                                Console.Clear();
                            }
                            break;

                        case 'a':
                            if (sour.X > 0 || sour.X == herniPoleX.Length - 1)
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
                            if (sour.Y == 0 || sour.Y + 1 == herniPoleY.Length || sour.X == 0 || sour.X == herniPoleX.Length - 1)
                            {
                                rotace--;
                            }
                            break;
                    }
                }
                if (rot == 3)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {

                        case 'd':
                            if (sour.X <= herniPoleX.Length - 2)
                            {
                                sour.X++;
                                Console.Clear();
                            }
                            break;

                        case 's':
                            if (sour.Y <= herniPoleY.Length - 3)
                            {
                                sour.Y++;
                                Console.Clear();
                            }
                            break;

                        case 'w':

                            if (sour.Y > 0 || sour.Y == herniPoleY.Length - 2)
                            {
                                sour.Y--;
                                Console.Clear();
                            }
                            break;

                        case 'a':
                            if (sour.X > 0 || sour.X == herniPoleX.Length)
                            {
                                sour.X--;
                                Console.Clear();
                            }
                            break;

                        case 'e':
                            rotace++;

                            if (sour.Y == 0 || sour.Y - 1 == herniPoleY.Length || sour.X == 0 || sour.X == herniPoleX.Length - 1)
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


        }

        static void nakresliPole(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                for (int l = 0; l < x;l++ )
                {

                    Console.SetCursorPosition(l, i);
                    Console.Write("*");
                }
            }
        }
    }
}

