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

        public StavPolicka[,] HerniPole { get; protected set; }
        public StavPolicka[,] HerniPoleSoupere { get; protected set; }
        public List<Lod> Lode { get; protected set; }
        IPAddress ipAddress = new IPAddress(new byte[] { 192, 168, 216, 207 });
        IPEndPoint IpPort = new IPEndPoint(ipAddress, 11000);

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
            int token = GenerovatToken();
            VymenitSiTokenSeSouperem(token);
            if (ipAddress > AdresaSoupere)
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
        int Hosting = 2;
        public bool MojeAdresaJeVetsi(string mojeAdresa, string jehoAdresa)
        {
            bool sesHost = false;
            bool jedemDal = false;
            bool souperJeHost = false;
            string ip = mojeAdresa;
            string[] tokens = ip.Split('.');
            int value1_1 = Int32.Parse(tokens[0]);
            int value1_2 = Int32.Parse(tokens[1]);
            int value1_3 = Int32.Parse(tokens[2]);
            int value1_4 = Int32.Parse(tokens[3]);
            Console.WriteLine(value1_1);
            Console.WriteLine(value1_2);
            Console.WriteLine(value1_3);
            Console.WriteLine(value1_4);
            string ip2 = jehoAdresa;
            string[] tokens2 = ip2.Split('.');
            int value2_1 = Int32.Parse(tokens2[0]);
            int value2_2 = Int32.Parse(tokens2[1]);
            int value2_3 = Int32.Parse(tokens2[2]);
            int value2_4 = Int32.Parse(tokens2[3]);
            Console.WriteLine(value2_1);
            Console.WriteLine(value2_2);
            Console.WriteLine(value2_3);
            Console.WriteLine(value2_4);
            if (value1_1 == value2_1)
            {
                jedemDal = true;
            }
            else
            {
                if (value1_1 > value2_1)
                {
                    sesHost = true;
                }
                else
                {
                    souperJeHost = true;
                }
            }
            if (jedemDal == true)
            {
                jedemDal = false;
                if (value1_2 == value2_2)
                {
                    jedemDal = true;
                }
                else
                {
                    if (value1_2 > value2_2)
                    {
                        sesHost = true;
                    }
                    else
                    {
                        souperJeHost = true;
                    }
                }
            }
            if (jedemDal == true)
            {
                jedemDal = false;
                if (value1_3 == value2_3)
                {
                    jedemDal = true;
                }
                else
                {
                    if (value1_3 > value2_3)
                    {
                        sesHost = true;
                    }
                    else
                    {
                        souperJeHost = true;
                    }
                }
            }
            if (jedemDal == true)
            {
                if (value1_4 == value2_4)
                {
                    Console.WriteLine("DVĚ STEJNÝ IP ADRESY?! CO MI O TOM JAKO ŘEKNEŠ? HMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM?");
                }
                else
                {
                    if (value1_4 > value2_4)
                    {
                        sesHost = true;
                    }
                    else
                    {
                        souperJeHost = true;
                    }
                }
            }
            if (sesHost == true)
            {
                return true;
            }

            if (souperJeHost == true)
            {
                return false;
            }

            throw new Exception("Uplay stoped working - ERROR 401");
        }   
        public void NavazatSpojeniSeSouperem()
        {
            bool zacinam = MojeAdresaJeVetsi(VlastniAdresa.ToString(), AdresaSoupere.ToString());


            if (zacinam)
            {
                Socket Posta = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);



                Posta.Connect(IpPort);

                Console.WriteLine("Socket connected to {0}");
                Posta.RemoteEndPoint.ToString();

                byte[] msg = Encoding.UTF8.GetBytes("tady máte zásilku");

            }
            else
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);



                Socket klient = VysilaciKomunikacniKanal;
                //Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                klient.Connect(localEndPoint);

                Console.WriteLine("Waiting for a connection...");

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
