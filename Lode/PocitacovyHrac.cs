using System;
using System.Net;

namespace Lode
{
    class PocitacovyHrac : Hrac
    {
        private static string[] _jmenaAI = new string[] { "Andy", "Boris", "Dora","Filip", "Keira", "Victor" };

        public string Jmeno { get; private set; }

        public PocitacovyHrac() : base(new IPAddress(new byte[] { 127, 0, 0, 1 }))
        {
            Jmeno = _jmenaAI[new Random().Next(_jmenaAI.Length)];
        }

        public void OddelitDoSamostatnehoVlakna()
        {
            throw new NotImplementedException();
        }

        public override void RozmistitLode()
        {
            throw new NotImplementedException();
        }

        public override Souradnice RozhodnoutVlastniTah()
        {
            int min = 1;
            int max = 10;

            Random x = new Random((int)DateTime.Now.Ticks);
            {

                Console.WriteLine(x.Next(min, max));

            }

            Random y = new Random((int)DateTime.Now.Ticks);
            {
                Console.WriteLine(y.Next(min, max));

            }
            throw new NotImplementedException();
        }
    }
}
