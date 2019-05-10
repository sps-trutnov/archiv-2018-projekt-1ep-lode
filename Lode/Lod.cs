using System;
using System.Collections.Generic;

namespace Lode
{
    enum TypLode
    {
        Clun,
        Torpedovka,
        Kriznik,
        Letadlovka,
    }

    class Lod
    {
        public Souradnice Souradnice { get; private set; }
        public TypLode Typ { get; private set; }

        private List<Souradnice> _policka;

        public bool ZasahujeNaPolicko(Souradnice policko)
        {
            throw new NotImplementedException();
        }
    }
}
