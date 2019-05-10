using System;
using System.Collections.Generic;

namespace Lode
{
    class Lod
    {
        #region Atributy
        private List<Souradnice> _policka;
        #endregion

        #region Vlastnosti
        public Souradnice Souradnice { get; private set; }
        public TypLode Typ { get; private set; }
        #endregion

        #region Konstruktory
        #endregion

        #region Verejne metody
        public bool ZasahujeNaPolicko(Souradnice policko)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Soukrome metody
        #endregion
    }
}
