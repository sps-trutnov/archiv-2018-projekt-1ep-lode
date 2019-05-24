using System;
using System.Collections.Generic;

namespace Lode
{
    class Lod
    {
        public readonly List<Souradnice> _policka;

        public NatoceniLode Natoceni { get; set; }
        public Souradnice Souradnice { get; set; }
        public TypLode Typ { get; private set; }

        public Lod(TypLode typ)
        {
            Typ = typ;

            _policka = new List<Souradnice>();

            switch (typ)
            {
                case TypLode.Clun:
                    _policka.Add(new Souradnice() { X = 0, Y = 0 });
                    break;
                case TypLode.Torpedovka:
                    _policka.Add(new Souradnice() { X = 0, Y = 0 });
                    _policka.Add(new Souradnice() { X = +1, Y = 0 });
                    _policka.Add(new Souradnice() { X = -1, Y = 0 });
                    _policka.Add(new Souradnice() { X = 0, Y = +1 });
                    break;
                case TypLode.Letadlovka:
                    _policka.Add(new Souradnice() { X = 0, Y = 0 });
                    _policka.Add(new Souradnice() { X = -2, Y = 0 });
                    _policka.Add(new Souradnice() { X = -1, Y = 0 });
                    _policka.Add(new Souradnice() { X = +1, Y = 0 });
                    _policka.Add(new Souradnice() { X = 0, Y = +1 });
                    break;
                case TypLode.Kriznik:
                    _policka.Add(new Souradnice() { X = 0, Y = 0 });
                    _policka.Add(new Souradnice() { X = -2, Y = 0 });
                    _policka.Add(new Souradnice() { X = -1, Y = 0 });
                    _policka.Add(new Souradnice() { X = +1, Y = 0 });
                    _policka.Add(new Souradnice() { X = +2, Y = 0 });
                    _policka.Add(new Souradnice() { X = -1, Y = +1 });
                    _policka.Add(new Souradnice() { X = +1, Y = +1 });
                    break;
                default:
                    break;
            }
        }

        public bool JeUmistenaSpravne(Souradnice rozmerHernihoPole, List<Lod> ostatniLode)
        {
            foreach (Souradnice policko in _policka)
            {
                if (policko.X + Souradnice.X < 0 || policko.Y + Souradnice.Y < 0)
                    return false;
                if (policko.X + Souradnice.X >= rozmerHernihoPole.X || policko.Y + Souradnice.Y >= rozmerHernihoPole.Y)
                    return false;

                foreach (Lod jinaLod in ostatniLode)
                    foreach (Souradnice polickoJineLode in jinaLod._policka)
                        if (Souradnice.X + policko.X == jinaLod.Souradnice.X + polickoJineLode.X && Souradnice.Y + policko.Y == jinaLod.Souradnice.Y + polickoJineLode.Y)
                            return false;
                        else if (Souradnice.X + policko.X + 1 == jinaLod.Souradnice.X + polickoJineLode.X && Souradnice.Y + policko.Y == jinaLod.Souradnice.Y + polickoJineLode.Y)
                            return false;
                        else if (Souradnice.X + policko.X - 1 == jinaLod.Souradnice.X + polickoJineLode.X && Souradnice.Y + policko.Y == jinaLod.Souradnice.Y + polickoJineLode.Y)
                            return false;
                        else if (Souradnice.X + policko.X == jinaLod.Souradnice.X + polickoJineLode.X && Souradnice.Y + policko.Y + 1 == jinaLod.Souradnice.Y + polickoJineLode.Y)
                            return false;
                        else if (Souradnice.X + policko.X == jinaLod.Souradnice.X + polickoJineLode.X && Souradnice.Y + policko.Y - 1 == jinaLod.Souradnice.Y + polickoJineLode.Y)
                            return false;
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
        public bool ZasahujeNaPolicko(int x, int y)
        {
            return ZasahujeNaPolicko(new Souradnice() { X = x, Y = y });
        }
        public bool ZasahujeNaPolicko(Souradnice policko)
        {
            for (int i = 0; i < _policka.Count; i++)
            {
                int x, y;

                switch (Natoceni)
                {
                    case NatoceniLode.Stupnu0:
                        x = _policka[i].X * (+1);
                        y = _policka[i].Y * (+1);
                        break;
                    case NatoceniLode.Stupnu90:
                        x = _policka[i].Y * (-1);
                        y = _policka[i].X * (+1);
                        break;
                    case NatoceniLode.Stupnu180:
                        x = _policka[i].X * (-1);
                        y = _policka[i].Y * (-1);
                        break;
                    case NatoceniLode.Stupnu270:
                        x = _policka[i].Y * (+1);
                        y = _policka[i].X * (-1);
                        break;
                    default:
                        x = 0;
                        y = 0;
                        break;
                }

                x += Souradnice.X;
                y += Souradnice.Y;

                if (x == policko.X && y == policko.Y)
                    return true;
            }

            return false;
        }
    }
}
