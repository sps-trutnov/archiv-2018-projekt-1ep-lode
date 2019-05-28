using System;
using System.Collections.Generic;

namespace Lode
{
    class Lod
    {
        private int _zasahy = 0;

        public List<Souradnice> Policka { get; private set; }
        public NatoceniLode Natoceni { get; set; }
        public Souradnice Souradnice { get; set; }
        public TypLode Typ { get; private set; }

        public Lod(TypLode typ)
        {
            Typ = typ;

            Policka = new List<Souradnice>();

            switch (typ)
            {
                case TypLode.Clun:
                    Policka.Add(new Souradnice() { X = 0, Y = 0 });
                    break;
                case TypLode.Torpedovka:
                    Policka.Add(new Souradnice() { X = 0, Y = 0 });
                    Policka.Add(new Souradnice() { X = +1, Y = 0 });
                    Policka.Add(new Souradnice() { X = -1, Y = 0 });
                    Policka.Add(new Souradnice() { X = 0, Y = +1 });
                    break;
                case TypLode.Letadlovka:
                    Policka.Add(new Souradnice() { X = 0, Y = 0 });
                    Policka.Add(new Souradnice() { X = -2, Y = 0 });
                    Policka.Add(new Souradnice() { X = -1, Y = 0 });
                    Policka.Add(new Souradnice() { X = +1, Y = 0 });
                    Policka.Add(new Souradnice() { X = 0, Y = +1 });
                    break;
                case TypLode.Kriznik:
                    Policka.Add(new Souradnice() { X = 0, Y = 0 });
                    Policka.Add(new Souradnice() { X = -2, Y = 0 });
                    Policka.Add(new Souradnice() { X = -1, Y = 0 });
                    Policka.Add(new Souradnice() { X = +1, Y = 0 });
                    Policka.Add(new Souradnice() { X = +2, Y = 0 });
                    Policka.Add(new Souradnice() { X = -1, Y = +1 });
                    Policka.Add(new Souradnice() { X = +1, Y = +1 });
                    break;
            }
        }

        public bool BlokujePolicko(Souradnice souradnice)
        {
            return BlokujePolicko(souradnice.X, souradnice.Y);
        }
        public bool BlokujePolicko(int x, int y)
        {
            if (ZasahujeNaPolicko(x, y))
                return true;
            if (ZasahujeNaPolicko(x + 1, y))
                return true;
            if (ZasahujeNaPolicko(x - 1, y))
                return true;
            if (ZasahujeNaPolicko(x, y + 1))
                return true;
            if (ZasahujeNaPolicko(x, y - 1))
                return true;

            return false;
        }
        public bool JePotopena()
        {
            return _zasahy == Policka.Count;
        }
        public bool JeUmistenaSpravne(Souradnice rozmerHernihoPole, List<Lod> ostatniLode)
        {
            for (int x = -1; x <= rozmerHernihoPole.X; x++)
            {
                for (int y = -1; y <= rozmerHernihoPole.Y; y++)
                {
                    Souradnice policko = new Souradnice() { X = x, Y = y };

                    if (ZasahujeNaPolicko(policko) && (x == -1 || y == -1))
                        return false;
                    if (ZasahujeNaPolicko(policko) && (x == rozmerHernihoPole.X || y == rozmerHernihoPole.Y))
                        return false;

                    foreach (Lod lod in ostatniLode)
                        if (ZasahujeNaPolicko(policko) && lod.BlokujePolicko(policko))
                            return false;
                        else if (BlokujePolicko(policko) && lod.ZasahujeNaPolicko(policko))
                            return false;
                }
            }

            return true;
        }
        public void Otocit(NatoceniLode uhel)
        {
            Natoceni += (int)uhel;

            if ((int)Natoceni >= Enum.GetValues(typeof(NatoceniLode)).Length)
                Natoceni -= Enum.GetValues(typeof(NatoceniLode)).Length;
        }
        public void Posunout(int dx, int dy, Souradnice rozsahPohybu)
        {
            Souradnice.X += dx;
            Souradnice.Y += dy;

            if (Souradnice.X < 0)
                Souradnice.X = 0;
            if (Souradnice.Y < 0)
                Souradnice.Y = 0;
            if (Souradnice.X >= rozsahPohybu.X)
                Souradnice.X = rozsahPohybu.X - 1;
            if (Souradnice.Y >= rozsahPohybu.Y)
                Souradnice.Y = rozsahPohybu.Y - 1;
        }
        public void Premistit(int x, int y, NatoceniLode natoceni)
        {
            Premistit(new Souradnice() { X = x, Y = y }, natoceni);
        }
        public void Premistit(Souradnice souradnice, NatoceniLode natoceni)
        {
            Souradnice = souradnice;
            Natoceni = natoceni;
        }
        public void Zasahnout()
        {
            _zasahy += 1;
        }
        public bool ZasahujeNaPolicko(int x, int y)
        {
            return ZasahujeNaPolicko(new Souradnice() { X = x, Y = y });
        }
        public bool ZasahujeNaPolicko(Souradnice policko)
        {
            for (int i = 0; i < Policka.Count; i++)
            {
                int x, y;

                switch (Natoceni)
                {
                    case NatoceniLode.Stupnu0:
                        x = Policka[i].X * (+1);
                        y = Policka[i].Y * (+1);
                        break;
                    case NatoceniLode.Stupnu90:
                        x = Policka[i].Y * (-1);
                        y = Policka[i].X * (+1);
                        break;
                    case NatoceniLode.Stupnu180:
                        x = Policka[i].X * (-1);
                        y = Policka[i].Y * (-1);
                        break;
                    case NatoceniLode.Stupnu270:
                        x = Policka[i].Y * (+1);
                        y = Policka[i].X * (-1);
                        break;
                    default:
                        x = 0;
                        y = 0;
                        break;
                }

                if (x + Souradnice.X == policko.X && y + Souradnice.Y == policko.Y)
                    return true;
            }

            return false;
        }
    }
}
