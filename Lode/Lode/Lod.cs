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
            throw new NotImplementedException();
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
