using System;
using System.Collections.Generic;

namespace Lode
{
    class Lod
    {
        public enum TypLode
        {
            Clun, Torpedovka, Kriznik, Letadlovka
        }

        public Souradnice Souradnice { get; private set; }
        public TypLode Typ { get; private set; }

        private List<Souradnice> policka;

        public bool ZasahujeNaPolicko(Souradnice policko)
        {
            throw new NotImplementedException();
        }
    }
}
