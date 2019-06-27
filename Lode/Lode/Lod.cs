using System;
using System.Collections.Generic;

namespace Lode
{
    class Lod
    {
        //private int _zasahy = 0;
        static int[] herniPoleX = new int[10];
        static int[] herniPoleY = new int[10];
        public List<Souradnice> Policka { get; private set; }
        public NatoceniLode Natoceni { get; set; }
        public Souradnice Souradnice { get; set; }
        public TypLode Typ { get; private set; }

        public Lod(TypLode typ)
        {
            Typ = typ;

            Policka = new List<Souradnice>();

            switch(Typ)
            {
                case TypLode.Clun:
                    Policka.Add(new Souradnice { X = 0, Y = 0 });
                    Policka.Add(new Souradnice { X = 1, Y = 0 });
                break;
                case TypLode.Torpedovka:
                    Policka.Add(new Souradnice { X = 0, Y = 0 });
                    Policka.Add(new Souradnice { X = -1, Y = 0 });
                    Policka.Add(new Souradnice { X = 1, Y = 0 });
                    Policka.Add(new Souradnice { X = 0, Y = 1 });
                break;
                case TypLode.Letadlovka:
                    Policka.Add(new Souradnice { X = 0, Y = 0 });
                    Policka.Add(new Souradnice { X = -1, Y = 0 });
                    Policka.Add(new Souradnice { X = 1, Y = 0 });
                    Policka.Add(new Souradnice { X = 2, Y = 0 });
                    Policka.Add(new Souradnice { X = 0, Y = 1 });
                    Policka.Add(new Souradnice { X = 1, Y = 1 });
                    break;
                case TypLode.Kriznik:
                    Policka.Add(new Souradnice { X = 0, Y = 0 });
                    Policka.Add(new Souradnice { X = -1, Y = 0 });
                    Policka.Add(new Souradnice { X = 1, Y = 0 });
                    Policka.Add(new Souradnice { X = 2, Y = 0 });
                    break;
            }
        }

        public bool BlokujePolicko(Souradnice souradnice, NatoceniLode uhel)
        {
            throw new NotImplementedException();
        }
        public bool JePotopena()
        {
            throw new NotImplementedException();
        }
        public bool JeUmistenaSpravne(Souradnice rozmerHernihoPole, List<Lod> ostatniLode)
        {
            throw new NotImplementedException();
        } 
        public void Otocit(NatoceniLode uhel)
        {
            throw new NotImplementedException();
        }
        public void Posunout(int dx, int dy, Souradnice rozsahPohybu,NatoceniLode uhelNatoceni)
        {
            if(Typ == TypLode.Clun)
            {
                if (uhelNatoceni == NatoceniLode.Stupnu0)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {

                        case 'd':
                            if (rozsahPohybu.X <= herniPoleX.Length - 3)
                            {
                                rozsahPohybu.X++;
                                Console.Clear();
                            }
                            break;

                        case 's':
                            if (rozsahPohybu.Y <= herniPoleY.Length - 2)
                            {
                                rozsahPohybu.Y++;
                                Console.Clear();
                            }
                            break;

                        case 'w':

                            if (rozsahPohybu.Y > 0 || rozsahPohybu.Y == herniPoleY.Length - 1)
                            {
                                rozsahPohybu.Y--;
                                Console.Clear();
                            }
                            break;

                        case 'a':
                            if (rozsahPohybu.X > 0 || rozsahPohybu.X == herniPoleX.Length - 1)
                            {
                                rozsahPohybu.X--;
                                Console.Clear();
                            }
                            break;
                        case 'e':
                            if (muzeSeOtocit(rozsahPohybu, Natoceni, TypLode.Clun))
                            {
                                Natoceni++;
                                if (Natoceni > NatoceniLode.Stupnu270)
                                {
                                    Natoceni = NatoceniLode.Stupnu0;
                                }
                            }
                            break;

                    }
                }

                if (uhelNatoceni == NatoceniLode.Stupnu90)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {

                        case 'd':
                            if (rozsahPohybu.X <= herniPoleX.Length - 2)
                            {
                                rozsahPohybu.X++;
                                Console.Clear();
                            }
                            break;

                        case 's':
                            if (rozsahPohybu.Y <= herniPoleY.Length - 3)
                            {
                                rozsahPohybu.Y++;
                                Console.Clear();
                            }
                            break;

                        case 'w':

                            if (rozsahPohybu.Y > 0 || rozsahPohybu.Y == herniPoleY.Length - 1)
                            {
                                rozsahPohybu.Y--;
                                Console.Clear();
                            }
                            break;

                        case 'a':
                            if (rozsahPohybu.X > 0 || rozsahPohybu.X == herniPoleX.Length)
                            {
                                rozsahPohybu.X--;
                                Console.Clear();
                            }
                            break;
                        case 'e':
                            if (muzeSeOtocit(rozsahPohybu, Natoceni, TypLode.Clun))
                            {
                                Natoceni++;
                            }
                            break;


                    }
                }
                if (uhelNatoceni == NatoceniLode.Stupnu180)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {

                        case 'd':
                            if (rozsahPohybu.X <= herniPoleX.Length - 3)
                            {
                                rozsahPohybu.X++;
                                Console.Clear();
                            }
                            break;

                        case 's':
                            if (rozsahPohybu.Y <= herniPoleY.Length - 2)
                            {
                                rozsahPohybu.Y++;
                                Console.Clear();
                            }
                            break;

                        case 'w':

                            if (rozsahPohybu.Y > 0 || rozsahPohybu.Y == herniPoleY.Length - 1)
                            {
                                rozsahPohybu.Y--;
                                Console.Clear();
                            }
                            break;

                        case 'a':
                            if (rozsahPohybu.X > 0 || rozsahPohybu.X == herniPoleX.Length - 1)
                            {
                                rozsahPohybu.X--;
                                Console.Clear();
                            }
                            break;
                        case 'e':
                            if (muzeSeOtocit(rozsahPohybu, Natoceni, TypLode.Clun))
                            {
                                Natoceni++;
                            }
                            break;

                    }
                }
                if (uhelNatoceni == NatoceniLode.Stupnu270)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {

                        case 'd':
                            if (rozsahPohybu.X <= herniPoleX.Length - 2)
                            {
                                rozsahPohybu.X++;
                                Console.Clear();
                            }
                            break;

                        case 's':
                            if (rozsahPohybu.Y <= herniPoleY.Length - 3)
                            {
                                rozsahPohybu.Y++;
                                Console.Clear();
                            }
                            break;

                        case 'w':

                            if (rozsahPohybu.Y > 0 || rozsahPohybu.Y == herniPoleY.Length - 2)
                            {
                                rozsahPohybu.Y--;
                                Console.Clear();
                            }
                            break;

                        case 'a':
                            if (rozsahPohybu.X > 0 || rozsahPohybu.X == herniPoleX.Length)
                            {
                                rozsahPohybu.X--;
                                Console.Clear();
                            }
                            break;
                        case 'e':
                            if (muzeSeOtocit(rozsahPohybu, Natoceni, TypLode.Clun))
                            {
                                Natoceni++;
                            }
                            break;

                    }
                }
            
            }
        }

        static bool muzeSeOtocit(Souradnice souradnice, NatoceniLode uhel, TypLode lod)
        {
            if (lod == TypLode.Clun)
            {
                if (uhel == NatoceniLode.Stupnu0)
                {

                    if (souradnice.X >= 0 || souradnice.Y + 1 <= herniPoleY.Length || souradnice.X <= herniPoleX.Length || souradnice.Y > 0)
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

                    if (souradnice.X >= 0 || souradnice.Y <= herniPoleY.Length || souradnice.X + 1 <= herniPoleX.Length || souradnice.Y > 0)
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

                    if (souradnice.X >= 0 || souradnice.Y + 1 <= herniPoleY.Length || souradnice.X <= herniPoleX.Length || souradnice.Y > 0)
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

                    if (souradnice.X >= 0 || souradnice.Y <= herniPoleY.Length || souradnice.X + 1 <= herniPoleX.Length || souradnice.Y > 0)
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


        public void Premistit(Souradnice souradnice, NatoceniLode natoceni)
        {

        }
        public void Zasahnout()
        {
            throw new NotImplementedException();
        }
        public bool ZasahujeNaPolicko(Souradnice policko)
        {
            throw new NotImplementedException();
        }
    }
}
