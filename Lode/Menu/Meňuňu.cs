using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    class Meňuňu
    {
        public bool HraProtiPocitaci { get; private set; }

        public void UvodniMenu(Hra hraSeKterouSePracuje)
        {
            while (true)
            {
                Console.Clear();
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
                Console.WriteLine();
                Console.WriteLine("              HRÁT PROTI PC");
                Console.WriteLine();
                Console.WriteLine("               MULTIPLAYER");
                Console.WriteLine();
                Console.WriteLine("                NASTAVENÍ");
                Console.WriteLine();
                Console.WriteLine("                 CREDITS");
                Console.WriteLine();
                Console.WriteLine("                  KONEC");
                Console.WriteLine(" ");
                Console.WriteLine("CO CHCETE UDĚLAT?");
                string odpoved = Console.ReadLine().Trim();

                HraProtiPocitaci = false;

                if (odpoved.ToUpper() == "HRÁT PROTI PC")
                {
                    HraProtiPocitaci = true;
                    hraSeKterouSePracuje.BudeSeHratProtiPocitaci();
                }
                else if (odpoved.ToUpper() == "MULTIPLAYER")
                {
                    hraSeKterouSePracuje.HratHru(hraSeKterouSePracuje.Hrac);
                }
                else if (odpoved.ToUpper() == "CREDITS")
                {
                    new About().Credits();
                }
                else if (odpoved.ToUpper() == "NASTAVENÍ")
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
}
