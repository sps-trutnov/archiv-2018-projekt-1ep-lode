using System;
using System.Collections.Generic;
using System.Net;

namespace Lode
{
    abstract class ObecnyHrac
    {
        #region Atributy
        protected Random _nahoda;
        #endregion

        #region Vlastnosti
        public IPEndPoint Vysilac { get; protected set; }
        public IPEndPoint Prijimac { get; protected set; }

        public IPEndPoint VysilacSoupere { get; protected set; }
        public IPEndPoint PrijimacSoupere { get; protected set; }

        protected StavPolicka[,] HerniPole { get; set; }
        protected List<Lod> Lode { get; set; }
        #endregion

        #region Konstruktory
        public ObecnyHrac(IPAddress vlastniAdresa)
        {
            Vysilac = new IPEndPoint(vlastniAdresa, 10001);
            Prijimac = new IPEndPoint(vlastniAdresa, 10010);

            _nahoda = new Random((int)DateTime.Now.Ticks);

            HerniPole = new StavPolicka[10, 10];
            Lode = new List<Lod>();
        }
        #endregion

        #region Abstraktni metody
        public abstract Souradnice RozhodnoutVlastniTah();
        public abstract void RozmistitLode();
        #endregion

        #region Verejne metody
        public int GenerovatToken()
        {
            return _nahoda.Next(int.MaxValue);
        }
        public bool JePorazenym()
        {
            throw new NotImplementedException();
        }
        public bool JeVitezem()
        {
            throw new NotImplementedException();
        }
        public bool MaPravoPrvnihoTahu()
        {
            int vlastniToken = GenerovatToken();
            int tokenSoupere = VymenitSiTokenSeSouperem(vlastniToken);

            return vlastniToken < tokenSoupere;
        }
        public void NastavitAdresuSoupere(IPAddress adresa)
        {
            VysilacSoupere = new IPEndPoint(adresa, 10001);
            PrijimacSoupere = new IPEndPoint(adresa, 10010);
        }
        public bool NemuzeProvestDalsiTah()
        {
            throw new NotImplementedException();
        }
        public StavPolicka ProvestTahSoupere(Souradnice tah)
        {
            throw new System.NotImplementedException();
        }
        public void ProvestVlastniTah(Souradnice tah, StavPolicka vysledek)
        {
            throw new NotImplementedException();
        }
        public void OznamitVysledekTahu(ObecnyHrac souper, StavPolicka vysledek)
        {
            throw new NotImplementedException();
        }
        public int VymenitSiTokenSeSouperem(int vlastniToken)
        {
            throw new System.NotImplementedException();
        }
        public Souradnice ZjistitTahSoupere()
        {
            throw new System.NotImplementedException();
        }
        public StavPolicka ZjistitVysledekTahu(ObecnyHrac souper, Souradnice tah)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Soukrome metody
        #endregion
    }
}
