using System;
using System.Net;

namespace Lode
{
    class LidskyHrac : ObecnyHrac
    {
        #region Atributy
        #endregion

        #region Vlastnosti
        #endregion

        #region Konstruktory
        public LidskyHrac(IPAddress ipAdresa) : base(ipAdresa)
        {
            
        }
        #endregion

        #region Verejne metody
        public override Souradnice RozhodnoutVlastniTah()
        {
            throw new NotImplementedException();
        }
        public override void RozmistitLode()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Soukrome metody
        #endregion
    }
}
