using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

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
        private byte zasilka1;
        private byte zasilka2;

        public StavPolicka[,] HerniPole { get; protected set; }
        public StavPolicka[,] HerniPoleSoupere { get; protected set; }
        public List<Lod> Lode { get; protected set; }
        public int ipAddress { get; private set; }

        public ObecnyHrac(IPAddress vlastniAdresa)
        {
            
        }

        public abstract Souradnice RozhodnoutVlastniTah();
        public abstract void RozmistitLode();

        public int GenerovatToken()
        {
            Random rnd = new Random();
            int token = rnd.Next(1, 2);
            return token;

            
        }
        public bool JePorazenym()
        {
            throw new NotImplementedException();
        }
        public bool MaPravoPrvnihoTahu()
        {
            GenerovatToken();
            VymenitSiTokenSeSouperem();
            if (ipAddress > AdresaSoupere())
            {
                if (zasilka1 > zasilka2)

                return true;

                else

                return false;
            }
        }
        public void NastavitAdresuSoupere(IPAddress adresaSoupere)
        {   
            
            AdresaSoupere = adresaSoupere;
        }
        public void NavazatSpojeniSeSouperem()
        {
            
            IPAddress ipAddress = new IPAddress(new byte[] { 192, 168, 216, 207 });
            IPEndPoint IpPort = new IPEndPoint(ipAddress, 11000);

            if (ipAddress > AdresaSoupere())
            {
                Socket Posta = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    Posta.Connect(IpPort);

                    Console.WriteLine("Socket connected to {0}",
                        Posta.RemoteEndPoint.ToString());

                    byte[] msg = Encoding.UTF8.GetBytes("tady máte zásilku");
                }
            }
            else
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);


                try
                {
                    Socket klient = VysilaciKomunikacniKanal;
                    //Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                    klient.Connect(localEndPoint);

                    Console.WriteLine("Waiting for a connection...");
                }
            }
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
            throw new NotImplementedException();
        }
        public void ProvestVlastniTah(Souradnice tah, StavPolicka vysledek)
        {
            throw new NotImplementedException();
        }
        public int VymenitSiTokenSeSouperem(int token)
        {   

            if (ipAddress > AdresaSoupere())
            {
                byte[] zasilka1 = BitConverter.GetBytes(token);
                Socket postak = VysilaciKomunikacniKanal;
                postak.Send(zasilka1);
                postak.Close();
                postak.Shutdown(SocketShutdown.Both);
                postak.Receive(zasilka2);
                


            }
            else
            {
                byte[] zasilka2 = BitConverter.GetBytes(token);
                Socket postak = VysilaciKomunikacniKanal;
                postak.Send(zasilka2);
                postak.Close();
                postak.Shutdown(SocketShutdown.Both);
                postak.Receive(zasilka1);
            }
        }
        public Souradnice ZjistitTahSoupere()
        {
            byte[] dataX = BitConverter.GetBytes(tah.X);
            byte[] dataY = BitConverter.GetBytes(tah.Y);
            postak.Send(dataX);
            postak.Send(dataY);
            postak.Close();
            postak.Shutdown(SocketShutdown.Both);
     
        }
        public StavPolicka ZjistitVysledekTahuOdSoupere(Souradnice tah)
        {
            postak.Receive(dataX);
            postak.Receive(dataY);

        }
    }
}
