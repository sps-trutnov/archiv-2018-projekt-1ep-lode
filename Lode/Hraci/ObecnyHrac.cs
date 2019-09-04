using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lode
{
    abstract class ObecnyHrac
    {
        int FinalToken1 = new Int32();
        int FinalToken2 = new Int32();
        int FinalDataX = new Int32();
        int FinalDataY= new Int32();
        int startIndex = 0;

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
            VlastniAdresa = vlastniAdresa;
        }

        public abstract Souradnice RozhodnoutVlastniTah();
        public abstract void RozmistitLode();
        
        public int GenerovatToken()
        {
            if (MojeAdresaJeVetsi(VlastniAdresa.ToString(), AdresaSoupere.ToString()))
            {
                Random rnd = new Random();
                int token1 = rnd.Next(1, 2);
                return token1;
            }
            else
            {
                Random rnd = new Random();
                int token2 = rnd.Next(1, 2);
                return token2;
            }

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

        /*public int ConvertnutIpNaString(VlastniAdresa, AdresaSoupere)
        {
            int MeinAdresa = Convert.ToInt32(VlastniAdresa);
            int JehoAdresa = Convert.ToInt32(AdresaSoupere);
            return MeinAdresa;
            return JehoAdresa;

        }
        */
        public bool MaPravoPrvnihoTahu()
        {
            GenerovatToken();
            //VRÁTÍ TOKEN1 A TOKEN2
            
            VymenitSiTokenSeSouperem(FinalToken1,FinalToken2);
            {
                if (FinalToken1 > FinalToken2)

                    return true;

                else

                    return false;
            }
        }
        public void NastavitAdresuSoupere(IPAddress adresa)
        {
            AdresaSoupere = adresa;
        }
        public void NastavitAdresuSoupere(ObecnyHrac souper)
        {
            AdresaSoupere = souper.VlastniAdresa;
        }
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
            /*
            Console.WriteLine(value1_1);
            Console.WriteLine(value1_2);
            Console.WriteLine(value1_3);
            Console.WriteLine(value1_4);
            */
            string ip2 = jehoAdresa;
            string[] tokens2 = ip2.Split('.');
            int value2_1 = Int32.Parse(tokens2[0]);
            int value2_2 = Int32.Parse(tokens2[1]);
            int value2_3 = Int32.Parse(tokens2[2]);
            int value2_4 = Int32.Parse(tokens2[3]);
            /*
            Console.WriteLine(value2_1);
            Console.WriteLine(value2_2);
            Console.WriteLine(value2_3);
            Console.WriteLine(value2_4);
            */
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

            Socket VysilaciKomunikacniKanal = new Socket(VlastniAdresa.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Socket PrijimaciKomunikacniKanal = new Socket(VlastniAdresa.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            if (zacinam)
            {
                ///ČÁST1
                PrijimaciKomunikacniKanal.Bind(new IPEndPoint(VlastniAdresa, PrijimaciPort  ));
                PrijimaciKomunikacniKanal.Listen(10);
                PrijimaciKomunikacniKanal = PrijimaciKomunikacniKanal.Accept();


                ///ČÁST2
                VysilaciKomunikacniKanal.Connect(new IPEndPoint(AdresaSoupere, PrijimaciPort));


            }
            else
            {
                ///ČÁST1    
                VysilaciKomunikacniKanal.Connect(new IPEndPoint(AdresaSoupere, PrijimaciPort));

                ///ČÁST2
                PrijimaciKomunikacniKanal.Bind(new IPEndPoint(VlastniAdresa, PrijimaciPort));
                PrijimaciKomunikacniKanal.Listen(10);
                PrijimaciKomunikacniKanal = PrijimaciKomunikacniKanal.Accept();
            }
            Console.WriteLine("IP " + VlastniAdresa.ToString() + " připojena");
        }
        public bool NemuzeProvestDalsiTah()
        {
            throw new NotImplementedException();
        }
        public void OznamitVysledekTahuSouperi(StavPolicka vysledek)
        {
            Socket postak = VysilaciKomunikacniKanal;
            int data = (int)vysledek;
            byte[] Pet = BitConverter.GetBytes(data);
            postak.Send(Pet);

        }
        public void PripojitRozhrani(IRozhrani rozhrani)
        {
            Rozhrani = rozhrani;
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
        public int VymenitSiTokenSeSouperem(int token1, int token2)
        {

            if(MojeAdresaJeVetsi(VlastniAdresa.ToString(), AdresaSoupere.ToString()))
            {
                byte[] zasilka = BitConverter.GetBytes(token1);
                Socket postak = VysilaciKomunikacniKanal;
                postak.Send(zasilka);
                postak = PrijimaciKomunikacniKanal;
                postak.Receive(zasilka);
                FinalToken1 = Convert.ToInt32(zasilka);
                return FinalToken1;


            }
            else
            {
                byte[] zasilka = BitConverter.GetBytes(token2);
                Socket postak = VysilaciKomunikacniKanal;
                postak.Send(zasilka);
                postak = PrijimaciKomunikacniKanal;
                postak.Receive(zasilka);
                FinalToken2 = Convert.ToInt32(zasilka);
                return FinalToken2;
            }
        }
        public Souradnice ZjistitTahSoupere()
        {
            /*
            byte[] dataX = BitConverter.GetBytes(tah.X);
            byte[] dataY = BitConverter.GetBytes(tah.Y);
            Socket postak = VysilaciKomunikacniKanal;
            postak.Send(dataX);
            postak.Send(dataY);
            postak.Close();
            postak.Shutdown(SocketShutdown.Both);
            */
            Socket postak = PrijimaciKomunikacniKanal;
            byte[] dataX = new byte[100];
            byte[] dataY = new byte[100];
            postak.Receive(dataX);
            postak.Receive(dataY);
            FinalDataX = BitConverter.ToInt32(dataX, startIndex);
            FinalDataY = BitConverter.ToInt32(dataY, startIndex);
            return new Souradnice { X = FinalDataX, Y = FinalDataY };
           

            /*FinalDataX = Convert.ToInt32(dataX);
             FinalDataY = Convert.ToInt32(dataY);
             return FinalDataX;
             return FinalDataY;
             */
        }
        public StavPolicka ZjistitVysledekTahuOdSoupere(Souradnice DataSouradnice)
        {
            
            BitConverter.GetBytes(DataSouradnice.X);
            BitConverter.GetBytes(DataSouradnice.Y);
            byte[] SouradniceX = new byte[100];
            byte[] SouradniceY = new byte[100];

            Socket postak = VysilaciKomunikacniKanal;

            postak.Send(SouradniceX);
            postak.Send(SouradniceY);

            postak = PrijimaciKomunikacniKanal;

            byte[] jakToDopadlo = new byte[100];
            postak.Receive(jakToDopadlo);

            int vysledekJakoInt = BitConverter.ToInt32(jakToDopadlo, startIndex);
            StavPolicka vysledekJakoStavPolicka = (StavPolicka)vysledekJakoInt;

            return vysledekJakoStavPolicka;
        }

        public bool ExistujeLod()
        {
            throw new NotImplementedException();
        }
    }
}
