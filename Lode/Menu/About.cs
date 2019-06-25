using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    class About
    {
        string[] rolovaciText = new string[] {
        "##########################################################################################################",
        "                                            SPŠ TRUTNOV                                                   ",
        "                                         #################                                                ",
        "                                                                                                          ",
        "                                             SENSEI                                                       ",
        "                                          ############                                                    ",
        "                                                                                                          ",
        "                                          ŠENKÝŘ JAKUB                                                    ",
        "                                                                                                          ",
        "                                           TÝM 1 - A.I.                                                   ",
        "                                         ################                                                 ",
        "                                                                                                          ",
        "                                            POVR FILIP                                                    ",
        "                                        ŠTĚPÁNEK DOMINIK                                                  ",
        "                                         ŽATECKÝ DUŠAN                                                    ",
        "                                                                                                          ",
        "                                      TÝM 2 - PROPOJENÍ HRÁČŮ                                             ",
        "                                    ###########################                                           ",
        "                                                                                                          ",
        "                                          BINAR DAVID                                                     ",
        "                                        MLEJNEK STANISLAV                                                 ",
        "                                        PCHÁLEK JAN                                                       ",
        "                                                                                                          ",
        "                                     TÝM 3 - PROVEDENÍ TAHŮ                                               ",
        "                                   ##########################                                             ",
        "                                                                                                          ",
        "                                          PETRŮ JAN                                                       ",
        "                                           RODR MICHAL                                                    ",
        "                                         ŠPRINC JAN                                                       ",
        "                                                                                                          ",
        "                                    TÝM 4 - ROZMÍSTENÍ LODÍ                                               ",
        "                                  ###########################                                             ",
        "                                                                                                          ",
        "                                         POLIAK TADEÁŠ                                                    ",
        "                                          SYNEK MARTIN                                                    ",
        "                                       ŠPRINGER DAVID                                                     ",
        "                                                                                                          ",
        "                                        TÝM 5 - DESIGN                                                    ",
        "                                      ##################                                                  ",
        "                                                                                                          ",
        "                                       PETRŽELA ONDŘEJ                                                    ",
        "                                         PLÍHAL MARTIN                                                    ",
        "                                          PRESL MARTIN                                                    ",
        "                                                                                                          ",
        "                     (C) Ikonu vytvořil Freepik z webu www.flaticon.com                                   ",
        "##########################################################################################################",
        "                                                                                                          ",
        "Pro vrácení zpět stiskni libovolné tlačítko.                                                              ",
            };

        public void Credits()
        {
            Console.Clear();

            int kolikRadkuVypsat = 1;
            int vrsekVypisu = 35;

            // faze 1 - najizdeni
            while (vrsekVypisu > 0)
            {
                Console.CursorTop = vrsekVypisu;
                Console.CursorLeft = 0;

                for(int i = 0; i < kolikRadkuVypsat; i++)
                    Console.WriteLine(rolovaciText[i]);

                Console.ReadKey();

                vrsekVypisu -= 1;
                Console.CursorLeft = 0;
                kolikRadkuVypsat += 1;
            }

            // faze 2 - prujezd
            while (kolikRadkuVypsat <46)
            {
                vrsekVypisu = 0;
                Console.CursorTop = vrsekVypisu;
                Console.CursorLeft = 0;

                for (int i = 35; i < kolikRadkuVypsat; i++)
                    Console.WriteLine(rolovaciText[i]);
                Console.ReadLine();

                vrsekVypisu -= 1;
                kolikRadkuVypsat += 1;
            }
            // faze 3 - dojezd

        }
    }
}