using System;
using System.Collections.Generic;

namespace Lode
{
    class Lod
    {
        private List<Souradnice> Policka { get; set; }
        private NatoceniLode Natoceni { get; set; }
        private Souradnice Souradnice { get; set; }
        private TypLode Typ { get; set; }
        private int Zasahy { get; set; }

        public Lod(TypLode typ)
        {
            throw new NotImplementedException();
        }

        private bool BlokujePolicko(Souradnice souradnice)
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
            throw new NotImplementedException();
        }
        public void Posunout(int dx, int dy, Souradnice povolenyRozsahPohybu)
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
