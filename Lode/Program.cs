using System;
namespace Lode
{
    class Program
    {
        static void Main(string[] args)
        {
            int Vystrel = 1;
            bool Trefa = false;


            Lod clun;
            clun.JePotopen = false;
            clun.Zasazen = 0000f;
            clun.PocetZasahu = 0;
            clun.PocetZivotu = 4;
            if (clun.JePotopen == true)
            {
                Console.WriteLine("...");
            }
            Console.ReadKey(true);

            

            //new Hra(new TextoveRozhrani()).SpustitHru();
        }

        struct Lod
        {
            public int PocetZasahu;
            public int PocetZivotu;
            public float Zasazen;
            public bool JePotopen;
        }

        
    }
}
