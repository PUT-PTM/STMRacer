using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Web;


namespace PTM_GRA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PTM GAME";
            Console.SetWindowSize(40, 20);
            Console.SetBufferSize(40, 20);
            Console.BackgroundColor = ConsoleColor.Gray;
      start:      
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\n\n\n                GRA PTM"); 
            Console.WriteLine("\n\n           Aby rozpoczac gre");
            Console.WriteLine("\n       nacisnij dowolny przycisk");    
            Console.WriteLine("\n\n              sterowanie:");
            Console.WriteLine("\n           klawisze w a s d   ");
            

            string[,] tablica = new string[16,35];
            
            for (int i = 0; i < 16;i++)
            {
                for (int j = 0; j<16;j++)
                {
                    if(j==1 || j == 15)
                    {
                        tablica[i, j] = "#";
                    }
                    else
                    {
                        tablica[i, j] = " ";
                    }     
                }
                if (i == 5)
                {
                    for (int j = 16; j<25;j++)
                    {
                        tablica[i,j] = " ";
                    }
                    tablica[i, 25] = "Punkty";
                    
                }

                if (i == 6)
                {
                    for (int j = 16; j < 32; j++)
                    {
                        tablica[i, j] = " ";
                    }
                }

                if (i == 8)
                {
                    for (int j = 16; j < 25; j++)
                    {
                        tablica[i, j] = " ";
                    }
                    tablica[i, 25] = "Zycia: ";
                }
                if (i == 9)
                {
                    for (int j = 16; j < 26; j++)
                    {
                        tablica[i, j] = " ";
                    }
                    tablica[i, 26] = "X";
                    tablica[i, 27] = " ";
                    tablica[i, 28] = "X";
                    tablica[i, 29] = " ";
                    tablica[i, 30] = "X";
                }

            }

            Random gen = new Random();

            ConsoleKeyInfo klawisz;

            int itemy = 13;
            int itemx = 6;
            int punkty = 0;
            int wrog1i=0;
            int wrog2i = 0;
            int wrog1x;
            int wrog2x;
            int licznik = 0;
            int trafienie = 0;
            int ruchy = 0;

            int[] tablos = new int[3];
            tablos[0] = 2;
            tablos[1] = 6;
            tablos[2] = 10;

      losuj:
            int los1 = tablos[gen.Next(0, 3)];
            int los2 = tablos[gen.Next(0, 3)];

            wrog1x = los1;
            if (wrog1x != los2)
            {
                wrog2x = los2;
            }
            else
            {
                goto losuj;
            }

            //klawisz = Console.ReadKey();
            //Console.Clear();
            
            while(true)
            {
                //System.Threading.Thread.Sleep(200);
                klawisz = Console.ReadKey();
                
                //if (ruchy == 10)
                //{
                    Console.Clear();
                    // STEROWANIE
                    if (klawisz.KeyChar == 'd')
                    {
                        if ((itemx + 1) == 12)
                        {
                            goto rysowanie;
                        }

                        itemx = itemx + 1;
                        tablica[itemy, itemx + 1] = " ";
                        tablica[itemy + 1, itemx] = " ";
                        tablica[itemy + 1, itemx + 1] = " ";
                        tablica[itemy + 1, itemx + 2] = " ";
                        tablica[itemy + 2, itemx] = " ";
                        tablica[itemy + 2, itemx + 2] = " ";
                    }
                    if (klawisz.KeyChar == 'a')
                    {
                        if ((itemx + 1) == 2)
                        {
                            goto rysowanie;
                        }
                        itemx = itemx - 1;
                        tablica[itemy, itemx + 3] = " ";
                        tablica[itemy + 1, itemx + 2] = " ";
                        tablica[itemy + 1, itemx + 3] = " ";
                        tablica[itemy + 1, itemx + 4] = " ";
                        tablica[itemy + 2, itemx + 2] = " ";
                        tablica[itemy + 2, itemx + 4] = " ";
                    }

                    if (klawisz.KeyChar == 's')
                    {
                        if ((itemy + 1) == 14)
                        {
                            goto rysowanie;
                        }
                        itemy = itemy + 1;
                        tablica[itemy - 1, itemx + 2] = " ";
                        tablica[itemy, itemx + 1] = " ";
                        tablica[itemy, itemx + 2] = " ";
                        tablica[itemy, itemx + 3] = " ";
                        tablica[itemy + 1, itemx + 1] = " ";
                        tablica[itemy + 1, itemx + 3] = " ";
                    }

                    if (klawisz.KeyChar == 'w')
                    {
                        if ((itemy + 1) == 1)
                        {
                            goto rysowanie;
                        }
                        itemy = itemy - 1;
                        tablica[itemy + 1, itemx + 2] = " ";
                        tablica[itemy + 2, itemx + 1] = " ";
                        tablica[itemy + 2, itemx + 2] = " ";
                        tablica[itemy + 2, itemx + 3] = " ";
                        tablica[itemy + 3, itemx + 1] = " ";
                        tablica[itemy + 3, itemx + 3] = " ";
                    }

                rysowanie:

                    if (trafienie > 4 &&
                            (tablica[itemy + 1, itemx + 1] == tablica[wrog1i + 1, wrog1x + 3] ||
                            tablica[itemy + 1, itemx + 3] == tablica[wrog1i + 1, wrog1x + 1] ||
                            tablica[itemy + 2, itemx + 1] == tablica[wrog1i + 2, wrog1x + 3] ||
                            tablica[itemy + 2, itemx + 3] == tablica[wrog1i + 2, wrog1x + 1] ||
                            tablica[itemy + 1, itemx + 1] == tablica[wrog2i + 1, wrog2x + 3] ||
                            tablica[itemy + 1, itemx + 3] == tablica[wrog2i + 1, wrog2x + 1] ||
                            tablica[itemy + 2, itemx + 1] == tablica[wrog2i + 2, wrog2x + 3] ||
                            tablica[itemy + 2, itemx + 3] == tablica[wrog2i + 2, wrog2x + 1])
                        )
                    {

                        trafienie = 0;


                        if (licznik == 2)
                        {
                            tablica[9, 26] = "-";
                        }
                        if (licznik == 1)
                        {
                            tablica[9, 28] = "-";
                        }
                        if (licznik == 0)
                        {
                            tablica[9, 30] = "-";
                        }
                        if (licznik == 3)
                        {
                            Console.Write("\n\n\n\n\n\n                GAME OVER       \n\n\n            Nacisnij ENTER");
                            break;
                        }
                        licznik++;

                    }



                    // PRZESZKODY
                    if (wrog1i == 13)
                    {
                        tablica[wrog1i, wrog1x + 2] = " ";
                        tablica[wrog1i + 1, wrog1x + 1] = " ";
                        tablica[wrog1i + 1, wrog1x + 2] = " ";
                        tablica[wrog1i + 1, wrog1x + 3] = " ";
                        tablica[wrog1i + 2, wrog1x + 1] = " ";
                        tablica[wrog1i + 2, wrog1x + 3] = " ";
                        wrog1x = tablos[gen.Next(0, 3)];
                        wrog1i = 0;
                        punkty = punkty + 1;
                    }
                    if (wrog2i == 13)
                    {
                        tablica[wrog2i, wrog2x + 2] = " ";
                        tablica[wrog2i + 1, wrog2x + 1] = " ";
                        tablica[wrog2i + 1, wrog2x + 2] = " ";
                        tablica[wrog2i + 1, wrog2x + 3] = " ";
                        tablica[wrog2i + 2, wrog2x + 1] = " ";
                        tablica[wrog2i + 2, wrog2x + 3] = " ";
                    ponow:
                        wrog2x = tablos[gen.Next(0, 3)];
                        if (wrog1x == wrog2x)
                        {
                            goto ponow;
                        }

                        wrog2i = 0;
                        punkty = punkty + 1;
                    }

                    tablica[wrog1i, wrog1x + 2] = " ";
                    tablica[wrog1i + 1, wrog1x + 1] = " ";
                    tablica[wrog1i + 1, wrog1x + 2] = " ";
                    tablica[wrog1i + 1, wrog1x + 3] = " ";
                    tablica[wrog1i + 2, wrog1x + 1] = " ";
                    tablica[wrog1i + 2, wrog1x + 3] = " ";

                    tablica[wrog1i + 1, wrog1x + 2] = "*";
                    tablica[wrog1i + 2, wrog1x + 1] = "*";
                    tablica[wrog1i + 2, wrog1x + 2] = "*";
                    tablica[wrog1i + 2, wrog1x + 3] = "*";
                    tablica[wrog1i + 3, wrog1x + 1] = "*";
                    tablica[wrog1i + 3, wrog1x + 3] = "*";
                    wrog1i++;

                    tablica[wrog2i, wrog2x + 2] = " ";
                    tablica[wrog2i + 1, wrog2x + 1] = " ";
                    tablica[wrog2i + 1, wrog2x + 2] = " ";
                    tablica[wrog2i + 1, wrog2x + 3] = " ";
                    tablica[wrog2i + 2, wrog2x + 1] = " ";
                    tablica[wrog2i + 2, wrog2x + 3] = " ";

                    tablica[wrog2i + 1, wrog2x + 2] = "*";
                    tablica[wrog2i + 2, wrog2x + 1] = "*";
                    tablica[wrog2i + 2, wrog2x + 2] = "*";
                    tablica[wrog2i + 2, wrog2x + 3] = "*";
                    tablica[wrog2i + 3, wrog2x + 1] = "*";
                    tablica[wrog2i + 3, wrog2x + 3] = "*";
                    wrog2i++;

                    // GRACZ
                    tablica[itemy, itemx + 2] = "*";
                    tablica[itemy + 1, itemx + 1] = "*";
                    tablica[itemy + 1, itemx + 2] = "*";
                    tablica[itemy + 1, itemx + 3] = "*";
                    tablica[itemy + 2, itemx + 1] = "*";
                    tablica[itemy + 2, itemx + 3] = "*";

                    
                    //ruchy = 0;
                //}
                // WYPISYWANIE
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16;j++ )
                    {
                        Console.Write(tablica[i, j]); 
                    }
                    if (i == 5)
                    {
                        for (int j = 16; j < 32; j++)
                        {
                            Console.Write(tablica[i, j]);
                        }
                    }
                    if (i == 6)
                    {
                        for (int j = 16; j < 32; j++)
                        {
                            if(j==27)
                            {
                                tablica[i, j] = punkty.ToString();
                            }
                            Console.Write(tablica[i, j]);
                        }
                    }
                    if (i == 8)
                    {
                        for (int j = 16; j < 26; j++)
                        {
                            Console.Write(tablica[i, j]);
                        }
                    }
                    if (i == 9)
                    {
                        for (int j = 16; j < 31; j++)
                        {
                            Console.Write(tablica[i, j]);
                        }
                    }

                    Console.WriteLine();
                    
                }
                trafienie++;
                /////
                //ruchy++;
                //trafienie++;
            }
            Console.ReadLine();
            goto start;
            
        }
    }
}
