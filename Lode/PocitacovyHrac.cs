using System;
using System.Net;

namespace Lode
{
    class PocitacovyHrac : ObecnyHrac
    {
        #region Atributy
        private static string[] _jmenaAI = new string[] { "Andy", "Boris", "Dora", "Keira", "Victor" };
        #endregion

        #region Vlastnosti
        public string Jmeno { get; private set; }
        #endregion

        #region Konstruktory
        public PocitacovyHrac() : base(new IPAddress(new byte[] { 127, 0, 0, 1 }))
        {
            Jmeno = _jmenaAI[new Random().Next(_jmenaAI.Length)];
        }
        #endregion

        #region Verejne metody
        public void OddelitDoSamostatnehoVlakna()
        {
            throw new NotImplementedException();
        }
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
