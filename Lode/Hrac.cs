using System;
using System.Collections.Generic;
using System.Net;

namespace Lode
{
    abstract class Hrac
    {
        public IPEndPoint VlastniOdesilani { get; protected set; }
        public IPEndPoint VlastniPrijem { get; protected set; }

        public IPEndPoint OdesilaniSoupere { get; protected set; }
        public IPEndPoint PrijemSoupere { get; protected set; }

        protected StavPolicka[,] HerniPole { get; set; }
        protected List<Lod> Lode { get; set; }

        protected Random nahoda;

        public Hrac(IPAddress vlastniAdresa)
        {
            VlastniOdesilani = new IPEndPoint(vlastniAdresa, 10001);
            VlastniPrijem = new IPEndPoint(vlastniAdresa, 10010);

            nahoda = new Random((int)DateTime.Now.Ticks);

            HerniPole = new StavPolicka[10, 10];
            Lode = new List<Lod>();
        }
        public void StanovitAdresuSoupere(IPAddress adresa)
        {
            OdesilaniSoupere = new IPEndPoint(adresa, 10001);
            PrijemSoupere = new IPEndPoint(adresa, 10010);
        }

        public int GenerovatToken()
        {
            return nahoda.Next(int.MaxValue);
        }
        public int VykomunikovatTokeny(int vlastniToken)
        {
            throw new System.NotImplementedException();
        }
        public bool VyhravaPrvniTah()
        {
            int vlastniToken = GenerovatToken();
            int tokenSoupere = VykomunikovatTokeny(vlastniToken);

            return vlastniToken < tokenSoupere;
        }

        public abstract void RozmistitLode();

        public abstract Souradnice RozhodnoutVlastniTah();
        public StavPolicka VykomunikovatVlastniTah(Souradnice tah)
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
        public bool NemuzeHrat()
        {
            throw new NotImplementedException();
        }
    }
}
