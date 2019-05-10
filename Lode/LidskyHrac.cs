using System;
using System.Net;

namespace Lode
{
    class LidskyHrac : Hrac
    {
        public LidskyHrac(IPAddress ipAdresa) : base(ipAdresa)
        {

        }

        public override void RozmistitLode()
        {
            throw new NotImplementedException();
        }

        public override Souradnice RozhodnoutVlastniTah()
        {
            throw new NotImplementedException();
        }
    }
}
