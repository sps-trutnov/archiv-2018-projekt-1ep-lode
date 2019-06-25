using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Lode
{
    abstract class ObecnyHrac
    {
        protected Random _nahoda;

        public IRozhrani Rozhrani { get; protected set; }

        public IPAddress VlastniAdresa { get; protected set; }
        public IPAddress AdresaSoupere { get; protected set; }

        protected short PrijimaciPort { get; set; } = 10001;

        protected Socket VysilaciKomunikacniKanal { get; set; }
        protected Socket PrijimaciKomunikacniKanal { get; set; }

        protected bool ZahajujeKomunikaci;

        public StavPolicka[,] HerniPole { get; protected set; }
        public StavPolicka[,] HerniPoleSoupere { get; protected set; }
        public List<Lod> Lode { get; protected set; }

        public ObecnyHrac(IPAddress vlastniAdresa)
        {

        }

        public abstract Souradnice RozhodnoutVlastniTah();
        public abstract void RozmistitLode();

        public int GenerovatToken()
        {
            throw new NotImplementedException();
        }
        public bool JePorazenym()
        {
            throw new NotImplementedException();
        }
        public bool MaPravoPrvnihoTahu()
        {
            throw new NotImplementedException();
        }
        public void NastavitAdresuSoupere(IPAddress adresaSoupere)
        {
            throw new NotImplementedException();
        }
        public void NavazatSpojeniSeSouperem()
        {
            throw new NotImplementedException();
        }
        public bool NemuzeProvestDalsiTah()
        {
            throw new NotImplementedException();
        }
        public void OznamitVysledekTahuSouperi(StavPolicka vysledek)
        {
            throw new NotImplementedException();
        }
        public void PripojitRozhrani(IRozhrani rozhrani)
        {
            throw new NotImplementedException();
        }
        public StavPolicka ProvestTahSoupere(Souradnice tah)
        {
            if (HerniPole[tah.X, tah.Y] == StavPolicka.Lod)
            {
                HerniPole[tah.X, tah.Y] = StavPolicka.Zasah;
                return StavPolicka.Zasah;
            }
            else 
            {
                HerniPole[tah.X, tah.Y] = StavPolicka.Mimo;
                return StavPolicka.Mimo;
            }

        }

        public void ProvestVlastniTah(Souradnice tah, StavPolicka vysledek)
        {
            HerniPoleSoupere[tah.X, tah.Y] = vysledek;
        }
        public int VymenitSiTokenSeSouperem(int vlastniToken)
        {
            throw new NotImplementedException();
        }
        public Souradnice ZjistitTahSoupere()
        {
            throw new NotImplementedException();
        }
        public StavPolicka ZjistitVysledekTahuOdSoupere(Souradnice tah)
        {
            throw new NotImplementedException();
        }

        public bool ExistujeLod()
        {
            throw new NotImplementedException();
        }
    }
}
