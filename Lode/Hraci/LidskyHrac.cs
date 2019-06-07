using System;
using System.Collections.Generic;
using System.Net;

namespace Lode
{
    class LidskyHrac : ObecnyHrac
    {
        private Souradnice PoziceZamerovace { get; set; }
       
        
        public LidskyHrac(IPAddress ipAdresa) : base(ipAdresa)
        {
            
        }

        public override Souradnice RozhodnoutVlastniTah()
        {
            throw new NotImplementedException();
        }
        // Synek
        // Springer
        // Poliak
        public override void RozmistitLode()
        {
            throw new NotImplementedException();

        }
    }
}
