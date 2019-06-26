using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Lode
{
    abstract class ObecnyHrac
    {
        protected Random Nahoda { get; set; }

        private IPAddress VlastniAdresa { get; set; }
        private IPAddress AdresaSoupere { get; set; }
        private short PrijimaciPort { get; set; } = 10001;
        private Socket VysilaciKomunikacniKanal { get; set; }
        private Socket PrijimaciKomunikacniKanal { get; set; }

        private bool ZahajujeKomunikaci { get; set; }

        public StavPolicka[,] HerniPole { get; protected set; }
        public StavPolicka[,] HerniPoleSoupere { get; protected set; }
        public List<Lod> Lode { get; protected set; }

        protected IRozhrani Rozhrani { get; set; }

        public ObecnyHrac(IPAddress vlastniAdresa)
        {
<<<<<<< HEAD
            Lode = new List<Lod>();
            Lode.Add(new Lod(TypLode.Clun));
            Lode.Add(new Lod(TypLode.Clun));
            Lode.Add(new Lod(TypLode.Clun));
            Lode.Add(new Lod(TypLode.Torpedovka));
            Lode.Add(new Lod(TypLode.Torpedovka));
            Lode.Add(new Lod(TypLode.Letadlovka));
            Lode.Add(new Lod(TypLode.Kriznik));
=======

>>>>>>> master
        }

        public abstract Souradnice RozhodnoutVlastniTah();
        public abstract void RozmistitLode();

        private int GenerovatToken()
        {
            throw new NotImplementedException();
        }
        private int VymenitSiTokenSeSouperem(int vlastniToken)
        {
            throw new NotImplementedException();
        }

        protected void NaplnitHerniPoleHodnotou(StavPolicka hodnota)
        {
            throw new NotImplementedException();
        }
        protected void NaplnitHerniPoleSoupereHodnotou(StavPolicka hodnota)
        {
            throw new NotImplementedException();
        }
        protected void UmistitLodeDoHernihoPole()
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
        public void NastavitAdresuSoupere(IPAddress adresa)
        {
            throw new NotImplementedException();
        }
        public void NastavitAdresuSoupere(ObecnyHrac souper)
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
            Console.WriteLine(vysledek);
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
