using System;
using System.Net;
using System.Threading;

namespace Lode
{
    class PocitacovyHrac : ObecnyHrac
    {
        public delegate void HerniAlgoritmus(object souper);

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
        public void OddelitDoSamostatnehoVlakna(HerniAlgoritmus algoritmus, ObecnyHrac souper)
        {
            ParameterizedThreadStart starterVlaknaProAI = new ParameterizedThreadStart(algoritmus);
            Thread vlaknoProAI = new Thread(starterVlaknaProAI);
            vlaknoProAI.Start(souper);
            
            // TO DO
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
