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
            _nahoda = new Random((int)DateTime.Now.Ticks);

            VlastniAdresa = vlastniAdresa;
            HerniPole = new StavPolicka[10, 10];

            HerniPoleSoupere = new StavPolicka[10, 10];
            NaplnitHerniPoleSoupereHodnotou(StavPolicka.Neznamo);

            Lode = new List<Lod>();

            for (int i = 0; i < 1; i++)
                Lode.Add(new Lod(TypLode.Kriznik));
            for (int i = 0; i < 2; i++)
                Lode.Add(new Lod(TypLode.Letadlovka));
            for (int i = 0; i < 3; i++)
                Lode.Add(new Lod(TypLode.Torpedovka));
            for (int i = 0; i < 4; i++)
                Lode.Add(new Lod(TypLode.Clun));
        }

        public abstract Souradnice RozhodnoutVlastniTah();
        public abstract void RozmistitLode();

        public int GenerovatToken()
        {
            return _nahoda.Next(int.MaxValue);
        }
        public bool JePorazenym()
        {
            foreach (Lod lod in Lode)
                if (!lod.JePotopena())
                    return false;

            return true;
        }
        public bool MaPravoPrvnihoTahu()
        {
            int vlastniToken = GenerovatToken();
            int tokenSoupere = VymenitSiTokenSeSouperem(vlastniToken);

            return vlastniToken < tokenSoupere;
        }
        public void NaplnitHerniPoleHodnotou(StavPolicka hodnota)
        {
            for (int x = 0; x < HerniPole.GetLength(0); x++)
                for (int y = 0; y < HerniPole.GetLength(1); y++)
                    HerniPole[x, y] = hodnota;
        }
        public void NaplnitHerniPoleSoupereHodnotou(StavPolicka hodnota)
        {
            for (int x = 0; x < HerniPoleSoupere.GetLength(0); x++)
                for (int y = 0; y < HerniPoleSoupere.GetLength(1); y++)
                    HerniPoleSoupere[x, y] = hodnota;
        }
        public void NastavitAdresuSoupere(IPAddress adresaSoupere)
        {
            AdresaSoupere = adresaSoupere;
        }
        public void NavazatSpojeniSeSouperem()
        {
            for (int i = 0; i < VlastniAdresa.GetAddressBytes().Length; i++)
            {
                byte vlastni = VlastniAdresa.GetAddressBytes()[i];
                byte cizi = AdresaSoupere.GetAddressBytes()[i];

                if (vlastni != cizi)
                {
                    ZahajujeKomunikaci = vlastni < cizi;
                    break;
                }
            }

            VysilaciKomunikacniKanal = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            PrijimaciKomunikacniKanal = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            PrijimaciKomunikacniKanal.Bind(new IPEndPoint(VlastniAdresa, PrijimaciPort));
            PrijimaciKomunikacniKanal.Listen(10);

            VysilaciKomunikacniKanal.Connect(AdresaSoupere, PrijimaciPort);
            PrijimaciKomunikacniKanal = PrijimaciKomunikacniKanal.Accept();
        }
        public bool NemuzeProvestDalsiTah()
        {
            for (int x = 0; x < HerniPoleSoupere.GetLength(0); x++)
                for (int y = 0; y < HerniPoleSoupere.GetLength(1); y++)
                    if (HerniPoleSoupere[x, y] == StavPolicka.Neznamo)
                        return false;

            return true;
        }
        public void OznamitVysledekTahuSouperi(StavPolicka vysledek)
        {
            VysilaciKomunikacniKanal.Send(BitConverter.GetBytes((int)vysledek));
        }
        public void PripojitRozhrani(IRozhrani rozhrani)
        {
            Rozhrani = rozhrani;
        }
        public StavPolicka ProvestTahSoupere(Souradnice tah)
        {
            switch (HerniPole[tah.X, tah.Y])
            {
                case StavPolicka.Lod:
                    foreach (Lod lod in Lode)
                    {
                        if (lod.ZasahujeNaPolicko(tah.X, tah.Y))
                        {
                            lod.Zasahnout();

                            HerniPole[tah.X, tah.Y] = StavPolicka.Zasah;

                            if (lod.JePotopena())
                            {
                                for (int x = 0; x < HerniPole.GetLength(0); x++)
                                    for (int y = 0; y < HerniPole.GetLength(1); y++)
                                        if (lod.ZasahujeNaPolicko(x, y))
                                            HerniPole[x, y] = StavPolicka.Potopena;
                            }
                        }
                    }
                    break;
                case StavPolicka.Voda:
                    HerniPole[tah.X, tah.Y] = StavPolicka.Mimo;
                    break;
            }

            return HerniPole[tah.X, tah.Y];
        }
        public void ProvestVlastniTah(Souradnice tah, StavPolicka vysledek)
        {
            HerniPoleSoupere[tah.X, tah.Y] = vysledek;

            if (vysledek == StavPolicka.Potopena)
            {
                if (tah.X + 1 < HerniPoleSoupere.GetLength(0) && HerniPoleSoupere[tah.X + 1, tah.Y] == StavPolicka.Zasah)
                    ProvestVlastniTah(new Souradnice() { X = tah.X + 1, Y = tah.Y }, StavPolicka.Potopena);
                if (tah.X - 1 >= 0 && HerniPoleSoupere[tah.X - 1, tah.Y] == StavPolicka.Zasah)
                    ProvestVlastniTah(new Souradnice() { X = tah.X - 1, Y = tah.Y }, StavPolicka.Potopena);
                if (tah.Y + 1 < HerniPoleSoupere.GetLength(1) && HerniPoleSoupere[tah.X, tah.Y + 1] == StavPolicka.Zasah)
                    ProvestVlastniTah(new Souradnice() { X = tah.X, Y = tah.Y + 1 }, StavPolicka.Potopena);
                if (tah.Y - 1 >= 0 && HerniPoleSoupere[tah.X, tah.Y - 1] == StavPolicka.Zasah)
                    ProvestVlastniTah(new Souradnice() { X = tah.X, Y = tah.Y - 1 }, StavPolicka.Potopena);
            }
        }
        public void UmistitLodeDoHernihoPole()
        {
            for (int x = 0; x < HerniPole.GetLength(0); x++)
                for (int y = 0; y < HerniPole.GetLength(1); y++)
                    foreach (Lod lod in Lode)
                        if (lod.ZasahujeNaPolicko(x, y))
                            HerniPole[x, y] = StavPolicka.Lod;
        }
        public int VymenitSiTokenSeSouperem(int vlastniToken)
        {
            byte[] data = new byte[1024];

            if (ZahajujeKomunikaci)
            {
                VysilaciKomunikacniKanal.Send(BitConverter.GetBytes(vlastniToken));
                PrijimaciKomunikacniKanal.Receive(data);
            }
            else
            {
                PrijimaciKomunikacniKanal.Receive(data);
                VysilaciKomunikacniKanal.Send(BitConverter.GetBytes(vlastniToken));
            }

            return BitConverter.ToInt32(data, 0);
        }
        public Souradnice ZjistitTahSoupere()
        {
            byte[] data = new byte[1024];

            PrijimaciKomunikacniKanal.Receive(data);
            int x = BitConverter.ToInt32(data, 0);
            PrijimaciKomunikacniKanal.Receive(data);
            int y = BitConverter.ToInt32(data, 0);

            return new Souradnice() { X = x, Y = y };
        }
        public StavPolicka ZjistitVysledekTahuOdSoupere(Souradnice tah)
        {
            byte[] data = new byte[1024];

            VysilaciKomunikacniKanal.Send(BitConverter.GetBytes(tah.X));
            VysilaciKomunikacniKanal.Send(BitConverter.GetBytes(tah.Y));

            PrijimaciKomunikacniKanal.Receive(data);

            return (StavPolicka)BitConverter.ToInt32(data, 0);
        }
    }
}
