using System;
using System.Collections.Generic;
using System.Net;

namespace Lode
{
    abstract class Hrac
    {
        public IPEndPoint Vysilac { get; protected set; }
        public IPEndPoint Prijimac { get; protected set; }

        public IPEndPoint VysilacSoupere { get; protected set; }
        public IPEndPoint PrijimacSoupere { get; protected set; }

        protected StavPolicka[,] HerniPole { get; set; }
        protected List<Lod> Lode { get; set; }

        protected Random _nahoda;

        public Hrac(IPAddress vlastniAdresa)
        {
            Vysilac = new IPEndPoint(vlastniAdresa, 10001);
            Prijimac = new IPEndPoint(vlastniAdresa, 10010);

            _nahoda = new Random((int)DateTime.Now.Ticks);

            HerniPole = new StavPolicka[10, 10];
            Lode = new List<Lod>();
        }
        public void NastavitAdresuSoupere(IPAddress adresa)
        {
            VysilacSoupere = new IPEndPoint(adresa, 10001);
            PrijimacSoupere = new IPEndPoint(adresa, 10010);
        }

        public int GenerovatToken()
        {
            return _nahoda.Next(int.MaxValue);
        }
        public int VymenitSiTokenSesouperem(int vlastniToken)
        {
            throw new System.NotImplementedException();
        }
        public bool MaPravoPrvnihoTahu()
        {
            int vlastniToken = GenerovatToken();
            int tokenSoupere = VymenitSiTokenSesouperem(vlastniToken);

            return vlastniToken < tokenSoupere;
        }

        public abstract void RozmistitLode();

        public abstract Souradnice RozhodnoutVlastniTah();
        public StavPolicka ZjistitVysledekTahuOdProtihrace(Souradnice tah)
        {
            throw new System.NotImplementedException();
        }
        public void ProvestVlastniTah(Souradnice tah, StavPolicka vysledek)
        {
            throw new NotImplementedException();
        }

        public Souradnice ZjistitTahSoupere()
        {
            throw new System.NotImplementedException();
        }
        public StavPolicka ProvestTahSoupere(Souradnice tah)
        {
            throw new System.NotImplementedException();
        }
        public void VykomunikovatTahSoupere(Souradnice tah, StavPolicka vysledek)
        {
            throw new NotImplementedException();
        }

        public bool JePorazenym()
        {
            throw new NotImplementedException();
        }
        public bool JeVitezem()
        {
            throw new NotImplementedException();
        }

        public bool NemuzeProvestDalsiTah()
        {
            throw new NotImplementedException();
        }

        public bool ExistujeLod()
        {
            throw new NotImplementedException();
        }
    }
}
