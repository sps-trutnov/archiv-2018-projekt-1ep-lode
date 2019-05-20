using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    interface IRozhrani
    {
        bool PolozitOtazkuAnoNe(string otazka, string chyboveHlaseni, bool defaultniOdpoved);
        void VykreslitHerniPole(StavPolicka[,] herniPole);
        void VykreslitHlaseni(string hlaseni);
    }
}
