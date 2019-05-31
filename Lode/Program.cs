using System;
namespace Lode
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Hra().SpustitHru();
            //ZACATEK 
            var policko = Console.ReadLine();
            //bool testovniString = true;
            string ZakazanaPismena = "KLMNOPQRSTUVWXYZ";
             
            string Zasah = "A4"; // Policko vybrano hracem
            while (policko.Contains(ZakazanaPismena))
            {
                Console.WriteLine("Tak to teda ne.");
                Console.WriteLine("Zkus to znovu");
                policko = Console.ReadLine();
                
            }
                if (policko == Zasah)
                {
                    System.Console.WriteLine(StavPolicka.Zasah);
                    System.Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine(StavPolicka.Mimo);
                    Console.WriteLine("Konec");
                    Console.ReadKey(true);
                }
                
            new Hra(new TextoveRozhrani()).SpustitHru();
        }
            
    }
}
