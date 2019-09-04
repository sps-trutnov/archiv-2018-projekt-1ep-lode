using System;
using System.Collections.Generic;

namespace Lode
{
    class Lod
    {
        static int[] herniPoleX = new int[10];
        static int[] herniPoleY = new int[10];
        private List<Souradnice> Policka { get; set; }
        private NatoceniLode Natoceni { get; set; }
        private Souradnice Souradnice { get; set; }
        private TypLode Typ { get; set; }
        private int Zasahy { get; set; }

        public Lod(TypLode typ)
        {
            Typ = typ;

            Policka = new List<Souradnice>();

            switch(Typ)
            {
                case TypLode.Clun:
                    Policka.Add(new Souradnice { X = Souradnice.X, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X + 1, Y = Souradnice.Y });
                break;
                case TypLode.Torpedovka:
                    Policka.Add(new Souradnice { X = Souradnice.X, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X - 1, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X + 1, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X, Y = Souradnice.Y + 1 });
                break;
                case TypLode.Letadlovka:
                    Policka.Add(new Souradnice { X = Souradnice.X, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X - 1, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X + 1, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X + 2, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X, Y = Souradnice.Y + 1 });
                    Policka.Add(new Souradnice { X = Souradnice.X + 1, Y = Souradnice.Y + 1 });
                    break;
                case TypLode.Kriznik:
                    Policka.Add(new Souradnice { X = Souradnice.X, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X - 1, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X + 1, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X + 2, Y = Souradnice.Y });
                    break;
            }
        }
        
        public void Update()
        {

            Policka = new List<Souradnice>();

            switch (Typ)
            {
                case TypLode.Clun:
                    Policka.Add(new Souradnice { X = Souradnice.X, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X + 1, Y = Souradnice.Y });
                    break;
                case TypLode.Torpedovka:
                    Policka.Add(new Souradnice { X = Souradnice.X, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X - 1, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X + 1, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X, Y = Souradnice.Y + 1 });
                    break;
                case TypLode.Letadlovka:
                    Policka.Add(new Souradnice { X = Souradnice.X, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X - 1, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X + 1, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X + 2, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X, Y = Souradnice.Y + 1 });
                    Policka.Add(new Souradnice { X = Souradnice.X + 1, Y = Souradnice.Y + 1 });
                    break;
                case TypLode.Kriznik:
                    Policka.Add(new Souradnice { X = Souradnice.X, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X - 1, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X + 1, Y = Souradnice.Y });
                    Policka.Add(new Souradnice { X = Souradnice.X + 2, Y = Souradnice.Y });
                    break;
            }
        }

        public bool BlokujePolicko(Souradnice souradnice, NatoceniLode uhel)
        {
            throw new NotImplementedException();
        }
        private bool BlokujePolicko(int x, int y)
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
        
        }
        public void Posunout(int dx, int dy, Souradnice souradnice,NatoceniLode uhelNatoceni)
        {
            if(Typ == TypLode.Clun)
            {
                if (uhelNatoceni == NatoceniLode.Stupnu0)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {

                        case 'd':
                            if (souradnice.X <= herniPoleX.Length - 3)
                            {
                                Souradnice.X++;
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
                                Souradnice.X--;
                                Console.Clear();
                            }
                            break;
                        case 'e':
                            if (muzeSeOtocit(souradnice, Natoceni, TypLode.Clun))
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
                            if (muzeSeOtocit(souradnice, Natoceni, TypLode.Clun))
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
                            if (muzeSeOtocit(souradnice, Natoceni, TypLode.Clun))
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
                            if (muzeSeOtocit(souradnice, Natoceni, TypLode.Clun))
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


        public void Premistit(Souradnice souradnice)//, NatoceniLode natoceni)
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
