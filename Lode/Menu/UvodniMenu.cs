namespace Lode
{
    class UvodniMenu
    {
        public bool HraProtiPocitaci { get; private set; }

        public void Zobrazit(Hra hraSeKterouSePracuje)
        {
            bool opakovatMenu = true;

            while (opakovatMenu)
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


                if (odpoved.ToUpper() == "HRÁT PROTI PC")
                {
                    HraProtiPocitaci = true;
                    opakovatMenu = false;
                }
                else if (odpoved.ToUpper() == "MULTIPLAYER")
                {
                    HraProtiPocitaci = false;
                    opakovatMenu = false;
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
