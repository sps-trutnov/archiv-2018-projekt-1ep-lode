using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
        "                                          PRESL MARTIN?                                                   ",
        "                                                                                                          ",
        "                     (C) Ikonu vytvořil Freepik z webu www.flaticon.com                                   ",
        "##########################################################################################################",
            };

        public void Credits()
        {
            Console.Clear();

            int kolikRadkuVypsat = 1;
            int vrsekVypisu = 35;

            // faze 1 - rozjezd
            while (vrsekVypisu > 0)
            {
                Console.CursorTop = vrsekVypisu;
                Console.CursorLeft = 0;

                for (int i = 0; i < kolikRadkuVypsat; i++)
                    Console.WriteLine(rolovaciText[i]);

                Thread.Sleep(400);

                vrsekVypisu -= 1;
                kolikRadkuVypsat += 1;
            }

            int kolikRadkuSeUzVypsalo = kolikRadkuVypsat;

            // faze 2 - prujezd
            while (rolovaciText.Length - kolikRadkuSeUzVypsalo > 0)
            {
                Console.CursorTop = 0;
                Console.CursorLeft = 0;

                for (int i = kolikRadkuSeUzVypsalo - kolikRadkuVypsat; i < kolikRadkuSeUzVypsalo; i++)
                    Console.WriteLine(rolovaciText[i]);
                Thread.Sleep(400);

                kolikRadkuSeUzVypsalo += 1;
            }
            // faze 3 - dojezd
            while (kolikRadkuVypsat > 0)
            {
                Console.Clear();

                Console.CursorTop = 0;
                Console.CursorLeft = 0;

                for (int i = kolikRadkuSeUzVypsalo - kolikRadkuVypsat; i < kolikRadkuSeUzVypsalo; i++)
                    Console.WriteLine(rolovaciText[i]);
                Thread.Sleep(400);

                kolikRadkuVypsat -= 1;
            }
        }
    }
}
