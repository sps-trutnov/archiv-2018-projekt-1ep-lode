using System;
using System.Threading;
namespace Lode
{
    class Program
    {
        static bool jeNaTahu = true;
        static int typLode = 0;
        static int rotace = 0;
        static NatoceniLode nat = new NatoceniLode();
        static int[] herniPoleX = new int[10];
        static int[] herniPoleY = new int[10];
        static Souradnice sour = new Souradnice();

        static void Main(string[] args)
        {
            sour.X = 2;
            sour.Y = 2;

            //new Hra(new TextoveRozhrani()).SpustitHru();
            while (jeNaTahu)
            {
                Console.CursorVisible = false;


                pohybLode(TypLode.Clun, nat,sour);
                nakresliPole(herniPoleX.Length, herniPoleY.Length);

                vykresliLod(TypLode.Clun, nat, sour);
            }

        }

        static void vykresliLod(TypLode typ, NatoceniLode natoceni, Souradnice souradnice)
        {
            if (typ == TypLode.Torpedovka)
            {

                switch ((int)natoceni)
                {
                    case 0:
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X - 1, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 1, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y - 1);
                        Console.Write('X');
                        break;
                    case 1:
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y - 1);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y + 1);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 1, souradnice.Y);
                        Console.Write('X');
                        break;
                    case 2:
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X - 1, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 1, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y + 1);
                        Console.Write('X');
                        break;
                    case 3:
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y - 1);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y + 1);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X - 1, souradnice.Y);
                        Console.Write('X');
                        break;
                }
            }
            else if (typ == TypLode.Clun)
            {
                switch ((int)natoceni)
                {

                    case 0:
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 1, souradnice.Y);
                        Console.Write('X');
                        break;
                    case 1:
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y + 1);
                        Console.Write('X');
                        break;
                    case 2:
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 1, souradnice.Y);
                        Console.Write('X');
                        break;
                    case 3:
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y + 1);
                        Console.Write('X');
                        break;
                }
            }
            else if (typ == TypLode.Kriznik)
            {
                switch ((int)natoceni)
                {
                    case 0:
                        Console.SetCursorPosition(souradnice.X - 1, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 1, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 2, souradnice.Y);
                        Console.Write('X');
                        break;
                    case 1:
                        Console.SetCursorPosition(souradnice.X, souradnice.Y - 1);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y + 1);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y + 2);
                        Console.Write('X');
                        break;
                    case 2:
                        Console.SetCursorPosition(souradnice.X - 1, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 1, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 2, souradnice.Y);
                        Console.Write('X');
                        break;
                    case 3:
                        Console.SetCursorPosition(souradnice.X, souradnice.Y - 1);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y + 1);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y + 2);
                        Console.Write('X');
                        break;
                }
            }
            else if (typ == TypLode.Letadlovka)
            {
                switch ((int)natoceni)
                {
                    case 0:
                        Console.SetCursorPosition(souradnice.X - 1, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 1, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 2, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y - 1);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 1, souradnice.Y - 1);
                        Console.Write('X');
                        break;
                    case 1:
                        Console.SetCursorPosition(souradnice.X, souradnice.Y - 1);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y + 1);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y + 2);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 1, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 1, souradnice.Y + 1);
                        Console.Write('X');
                        break;
                    case 2:
                        Console.SetCursorPosition(souradnice.X - 1, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 1, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 2, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y + 1);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X + 1, souradnice.Y + 1);
                        Console.Write('X');
                        break;
                    case 3:
                        Console.SetCursorPosition(souradnice.X, souradnice.Y - 1);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y + 1);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X, souradnice.Y + 2);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X - 1, souradnice.Y);
                        Console.Write('X');
                        Console.SetCursorPosition(souradnice.X - 1, souradnice.Y + 1);
                        Console.Write('X');
                        break;
                }
            }
        }

        static void pohybLode(TypLode typ, NatoceniLode rot, Souradnice souradnice)
        {
            if (typ == TypLode.Torpedovka)
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
            }


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
    }
}

