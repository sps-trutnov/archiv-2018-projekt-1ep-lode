using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    class Meňuňu
    {
        public void UvodniMenu()
        {
            Console.SetWindowSize(120, 35);
            Console.WriteLine("## # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # ##");
            Console.WriteLine(" ## # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # ##");
            Console.WriteLine();
            Console.WriteLine(" ####        ####     ########       ##########             ## ##                                  ##   ##");
            Console.WriteLine(" ####      ###  ###   ####  ####     ###                   #########                              #   #   #");
            Console.WriteLine(" ####     ###    ###  ####   ####    ###                   ###########         ###### ");
            Console.WriteLine(" ####     ###    ###  ####    ####   ##########         ###################################");
            Console.WriteLine(" ####     ###    ###  ####   ####    ###                ### ## ## ## ## ## ## ## ## ##### ");
            Console.WriteLine(" ####      ###  ###   ####  ####     ###                ################################");
            Console.WriteLine(" ########    ####     ########       ##########          #############################");
            Console.WriteLine();
            Console.WriteLine(" ## # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # ##");
            Console.WriteLine("## # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # ##");
            Console.ReadKey();

            Console.WriteLine("                                               HRÁT ");
            Console.WriteLine("                                            NASTAVENÍ");
            Console.WriteLine("                                              KONEC");
            Console.WriteLine(" ");
            Console.WriteLine("                      CO CHCETE UDĚLAT?");
            string odpoved = Console.ReadLine();

            Hra novaHra;
        
            if (odpoved.ToUpper() == "HRÁT")
            {
                novaHra = new Hra();
                novaHra.SpustitHru();

            }
            else if(odpoved.ToUpper() == "NASTAVENÍ")
            {
                new NastaveniHry().MenuNastaveni();
            }
            else if (odpoved.ToUpper() == "KONEC")
            {
                Environment.Exit(0);
            }
        }
    }
}
