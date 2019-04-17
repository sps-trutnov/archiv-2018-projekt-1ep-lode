using System;
using System.Net;

namespace Lode
{
    class LidskyHrac : Hrac
    {
        public LidskyHrac() : base(Dns.GetHostEntry(Dns.GetHostName()).AddressList[0])
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
