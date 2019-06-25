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
            Policka = new List<Souradnice>();

            if (Typ == TypLode.Clun)
            {
                Policka.Add(new Souradnice { X = 0, Y = 0 });
                Policka.Add(new Souradnice { X = 1, Y = 0 });
            }
            else if (Typ == TypLode.Torpedovka)
            {
                Policka.Add(new Souradnice { X = 0, Y = 0 });
                Policka.Add(new Souradnice { X = 1, Y = 0 });
                Policka.Add(new Souradnice { X = -1, Y = 0 });
                Policka.Add(new Souradnice { X = 0, Y = 1 });
            }
            else if (Typ == TypLode.Kriznik)
            {
                Policka.Add(new Souradnice { X = 0, Y = 0 });
                Policka.Add(new Souradnice { X = 1, Y = 0 });
                Policka.Add(new Souradnice { X = 2, Y = 0 });
                Policka.Add(new Souradnice { X = 3, Y = 0 });
            }
            else if (Typ == TypLode.Letadlovka)
            {
                Policka.Add(new Souradnice { X = 0, Y = 0 });
                Policka.Add(new Souradnice { X = 1, Y = 0 });
                Policka.Add(new Souradnice { X = 2, Y = 0 });
                Policka.Add(new Souradnice { X = 3, Y = 0 });
                Policka.Add(new Souradnice { X = 1, Y = 1 });
                Policka.Add(new Souradnice { X = 2, Y = 1 });
            }
        }

        public bool BlokujePolicko(Souradnice souradnice)
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
        public void Posunout(int dx, int dy, Souradnice rozsahPohybu)
        {
            throw new NotImplementedException();
        }
        public void Premistit(Souradnice souradnice, NatoceniLode natoceni)
        {
            throw new NotImplementedException();
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
