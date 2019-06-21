using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lode
{
    class Program
    {



        // Socket Listener acts as a server and listens to the incoming   
        // messages on the specified port and protocol.  

        public static void Main(String[] args)
        {
            StartServer();
            new Hra(new TextoveRozhrani()).SpustitHru();
        }
        public static void StartServer()
        {
            // Get Host IP Address that is used to establish a connection  
            // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
            // If a host has multiple addresses, you will get a list of addresses  
            IPAddress ipAddress = new IPAddress(new byte[] { 192, 168, 216, 207 });
            IPEndPoint pripojka = new IPEndPoint(ipAddress, 11000);
            Console.WriteLine("Poslouchám na IP adrese " + ipAddress.ToString());


            try
            {

                // Create a Socket that will use Tcp protocol      
                Socket trubka = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                // A Socket must be associated with an endpoint using the Bind method  
                trubka.Bind(pripojka);
                // Specify how many requests a Socket can listen before it gives Server busy response.  
                // We will listen 10 requests at a time  
                trubka.Listen(10);

                Console.WriteLine("Waiting for a connection...");
                Socket pripojenatrubka = trubka.Accept();

                // Incoming data from the client.    
                string prijatyText = null;
                byte[] buffer = null;

                while (true)
                {
                    buffer = new byte[1024];
                    int pocetPrijatychBytu = pripojenatrubka.Receive(buffer);
                    prijatyText += Encoding.UTF8.GetString(buffer, 0, pocetPrijatychBytu);
                    Console.WriteLine("Zatím jsem obdržel text: " + prijatyText);
                    /*Console.WriteLine("Napiš end pro konec");
                    if (prijatyText == "end")
                    {
                        break;
                    }
                    */
                    if (prijatyText.IndexOf("hotovo") > -1)
                    {
                        break;
                    }
                }

                Console.WriteLine("Text received : {0}", prijatyText);

                byte[] msg = Encoding.UTF8.GetBytes(prijatyText);
                pripojenatrubka.Send(msg);
                pripojenatrubka.Shutdown(SocketShutdown.Both);
                pripojenatrubka.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }

    //new Hra().SpustitHru();
}
