using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Lode
{
    abstract class ObecnyHrac
    {
        #region Atributy
        protected Random _nahoda;
        #endregion

        #region Vlastnosti
        public IPEndPoint VysilaciKoncovyBod { get; protected set; }
        public IPEndPoint PrijimaciKoncovyBod { get; protected set; }

        protected IPEndPoint VysilaciKoncovyBodSoupere { get; set; }
        protected IPEndPoint PrijimaciKoncovyBodSoupere { get; set; }

        protected Socket VysilaciKomunikacniKanal { get; set; }
        protected Socket PrijimaciKomunikacniKanal { get; set; }

        protected StavPolicka[,] HerniPole { get; set; }
        protected List<Lod> Lode { get; set; }
        #endregion

        #region Konstruktory
        public ObecnyHrac(IPAddress vlastniAdresa)
        {
            VysilaciKoncovyBod = new IPEndPoint(vlastniAdresa, 10001);
            PrijimaciKoncovyBod = new IPEndPoint(vlastniAdresa, 10010);

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
            VysilaciKoncovyBodSoupere = new IPEndPoint(adresa, 10001);
            PrijimaciKoncovyBodSoupere = new IPEndPoint(adresa, 10010);
        }
        public void NavazatSpojeni(ObecnyHrac souper)
        {
            bool iniciujeKomunikaci = false;

            for(int i = 0; i < PrijimaciKoncovyBod.Address.GetAddressBytes().Length; i++)
            {
                byte vlastni = PrijimaciKoncovyBod.Address.GetAddressBytes()[i];
                byte cizi = PrijimaciKoncovyBodSoupere.Address.GetAddressBytes()[i];

                if (vlastni != cizi)
                {
                    iniciujeKomunikaci = vlastni < cizi;
                    break;
                }
            }

            VysilaciKomunikacniKanal = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            PrijimaciKomunikacniKanal = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            if (iniciujeKomunikaci)
            {

            }
            else
            {

            }
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
