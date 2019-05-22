using System.Collections.Generic;

namespace Lode
{
    class Lod
    {
        #region Atributy
        private readonly List<Souradnice> _policka;
        #endregion

        #region Vlastnosti
        public NatoceniLode Natoceni { get; private set; }
        public Souradnice Souradnice { get; private set; }
        public TypLode Typ { get; private set; }
        #endregion

        #region Konstruktory
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
        #endregion

        #region Verejne metody
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
        public void Umistit(Souradnice souradnice, NatoceniLode natoceni)
        {
            Souradnice = souradnice;
            Natoceni = natoceni;

            for (int i = 0; i < _policka.Count; i++)
            {
                int x, y;

                switch (Natoceni)
                {
                    case NatoceniLode.Stupnu0:
                        _policka[i].X *= +1;
                        _policka[i].Y *= +1;
                        break;
                    case NatoceniLode.Stupnu90:
                        x = _policka[i].X;
                        y = _policka[i].Y;

                        _policka[i].X = y * -1;
                        _policka[i].Y = x * +1;
                        break;
                    case NatoceniLode.Stupnu180:
                        _policka[i].X *= -1;
                        _policka[i].Y *= -1;
                        break;
                    case NatoceniLode.Stupnu270:
                        x = _policka[i].X;
                        y = _policka[i].Y;

                        _policka[i].X = y * +1;
                        _policka[i].Y = x * -1;
                        break;
                    default:
                        break;
                }
            }
        }
        public bool ZasahujeNaPolicko(int x, int y)
        {
            return ZasahujeNaPolicko(new Souradnice() { X = x, Y = y });
        }
        public bool ZasahujeNaPolicko(Souradnice policko)
        {
            foreach (Souradnice polickoLode in _policka)
                if (Souradnice.X + polickoLode.X == policko.X && Souradnice.Y + polickoLode.Y == policko.Y)
                    return true;

            return false;
        }
        #endregion

        #region Soukrome metody
        #endregion
    }
}
