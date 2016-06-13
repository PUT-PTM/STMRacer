using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Threading;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    public partial class GRA_PTM : Form
    {
        PictureBox[] pB = new PictureBox[270];

        public GRA_PTM()
        {
            InitializeComponent();

            // tworzenie tablicy wszystkich elementow planszy w celu umozliwienia sterowania kazdym punktem osobno 
            pB = this.Controls.OfType<PictureBox>().Where(pb => pb.Name.StartsWith("pictureBox")).OrderBy(pb => int.Parse(pb.Name.Replace("pictureBox", ""))).ToArray();

            rysbrzegi();
        }


        private SerialPort port;
        
        public static int wro1;
        public static int wro2;
        public static int gracz = 232;
        public static int konce = 0;
        public static int punkty = 0;
        public static int trafienie = 0;
        public static int licznik = 0;
        public static bool over = false;
        public static int ruchy = 0;

        string znak = @"..\..\znak.jpg";
        string znak2 = @"..\..\znak2.jpg";

        // rysowanie gracza na nowej pozycji po ruchu
        public void rysgracz()
        {
            // rysowanie gracza po ruchu
            for (int i = 0; i < 32; i++)
            {
                if (i == 0 || i == 14 || i == 15 || i == 16 || i == 29 || i == 31)
                {
                    pB[gracz + i].BackgroundImage = System.Drawing.Image.FromFile(znak2);
                }
            }
        }

        // funkcja sluzaca do rysowania brzegow planszy
        public void rysbrzegi()
        {
            // brzegi
            for (int i = 0; i < 265; i += 15)
            {
                //pB[i].BackgroundImage = System.Drawing.Image.FromFile(znak2);
                pB[i].Image = System.Drawing.Image.FromFile(znak2);
                pB[i + 14].Image = System.Drawing.Image.FromFile(znak2);
            }
        }

        // czyszczenie gracza na starej pozycji po wykonaniu ruchu w dana strone
        public void ruch(int g1, int g2, int g3, int g4, int g5, int g6)
        {
            pB[gracz + g1].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[gracz + g2].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[gracz + g3].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[gracz + g4].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[gracz + g5].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[gracz + g6].BackgroundImage = System.Drawing.Image.FromFile(znak);
        }

        // wykonanie ruchu w prawo
        public void wprawo()
        {
            if ((gracz + 1 != 13) && (gracz + 1 != 28) && (gracz + 1 != 43) && (gracz + 1 != 58) && (gracz + 1 != 73) && (gracz + 1 != 88) && (gracz + 1 != 103) && (gracz + 1 != 118) && (gracz + 1 != 133) && (gracz + 1 != 148) && (gracz + 1 != 163) && (gracz + 1 != 178) && (gracz + 1 != 193) && (gracz + 1 != 208) && (gracz + 1 != 223) && (gracz + 1 != 238))
            {
                gracz += 1;
                ruch(-1, 13, 14, 15, 28, 30);
            }
            rysgracz();
        }
        
        // wykonanie ruchu w lewo
        public void wlewo()
        {
            if ((gracz - 1 != 1) && (gracz - 1 != 16) && (gracz - 1 != 31) && (gracz - 1 != 46) && (gracz - 1 != 61) && (gracz - 1 != 76) && (gracz - 1 != 91) && (gracz - 1 != 106) && (gracz - 1 != 121) && (gracz - 1 != 136) && (gracz - 1 != 151) && (gracz - 1 != 166) && (gracz - 1 != 181) && (gracz - 1 != 196) && (gracz - 1 != 211) && (gracz - 1 != 226))
            {
                gracz -= 1;
                ruch(1, 15, 16, 17, 30, 32);
            }
            rysgracz();
        }

        // wykonanie ruchu w gore
        public void wgore()
        {
            if ((gracz - 15) > 1)
            {
                gracz -= 15;
                ruch(15, 29, 30, 31, 44, 46);
            }
            rysgracz();
        }

        // wykonanie ruchu w dol
        public void wdol()
        {
            if ((gracz + 15) < 238)
            {
                gracz += 15;
                ruch(-15, -1, 0, 1, 14, 16);
            }
            rysgracz();
        }

        // funkcja sluzaca do losowania 2 z 3 mozliwych pozycji dla wroga
        public void losujpozycje()
        {
            if (konce == 16 || konce == 0)
            {
                if (konce == 16)
                {
                    kasujwrogow();
                }

                if (konce > 0)
                {
                    punkty = punkty + 20;
                }

                Random gen = new Random();

                int[] tablos = new int[3];
                tablos[0] = 3;
                tablos[1] = 7;
                tablos[2] = 11;

                int los1 = tablos[gen.Next(0, 3)];
                int los2 = tablos[gen.Next(0, 3)];

                wro1 = los1;

                while (wro1 == los2)
                {
                    los2 = tablos[gen.Next(0, 3)];
                }
                wro2 = los2;
                konce = 0;
            }
            konce++;

            label4.Invoke(new Action(delegate() { label4.Text = punkty.ToString(); }));
        }

        // funkcja sluzaca do rysowania i wykonywania ruchu wroga
        public void wrogowie()
        {
            // kasowanie wroga w ruchu
            if (wro2 > 15 || wro1 > 15)
            {
                for (int i = -15; i < 2; i++)
                {
                    if (i == 0 || i == -15 || i == -1 || i == 1)
                    {
                        pB[wro1 + i].BackgroundImage = System.Drawing.Image.FromFile(znak);
                        pB[wro2 + i].BackgroundImage = System.Drawing.Image.FromFile(znak);
                    }
                }
            }
            // rysowanie wroga po wykonaniu ruchu
            for (int i = 0; i < 32; i++)
            {
                if (i == 0 || i == 14 || i == 15 || i == 16 || i == 29 || i == 31)
                {
                    pB[wro1 + i].BackgroundImage = System.Drawing.Image.FromFile(znak2);
                    pB[wro2 + i].BackgroundImage = System.Drawing.Image.FromFile(znak2);
                }
            }
            wro1 += 15;
            wro2 += 15;
        }

        // funkcja sluzaca do kasowania/czyszczenia wrogow po zejsciu na sam dol planszy
        public void kasujwrogow()
        {
            wro1 -= 15;
            wro2 -= 15;
            // kasowanie wrogow
            for (int i = 0; i < 32; i++)
            {
                if (i == 0 || i == 14 || i == 15 || i == 16 || i == 29 || i == 31)
                {
                    pB[wro1 + i].BackgroundImage = System.Drawing.Image.FromFile(znak);
                    pB[wro2 + i].BackgroundImage = System.Drawing.Image.FromFile(znak);
                }
            }
        }

        // funkcja sluzaca do sprawdzenia czy nie wystapila kolizja
        public void czykolizja()
        {
            if (ruchy > 4 && gracz == wro1 - 15 || gracz == wro1 - 16 || gracz == wro1 - 17 || gracz == wro1 - 14 || gracz == wro1 - 13 || gracz == wro1 - 31 || gracz == wro1 - 29 || gracz == wro1 - 44 || gracz == wro1 - 46 ||
                gracz == wro2 - 15 || gracz == wro2 - 16 || gracz == wro2 - 17 || gracz == wro2 - 14 || gracz == wro2 - 13 || gracz == wro2 - 31 || gracz == wro2 - 29 || gracz == wro2 - 44 || gracz == wro1 - 46)
            {
                if (trafienie == 0)
                {
                    label5.Invoke(new Action(delegate() { label5.Text = "-"; }));
                    ruchy = 0;
                }
                if (trafienie == 1)
                {
                    label6.Invoke(new Action(delegate() { label6.Text = "-"; }));
                    ruchy = 0;
                }
                if (trafienie == 2)
                {
                    label7.Invoke(new Action(delegate() { label7.Text = "-"; }));
                    ruchy = 0;
                }
                if (trafienie == 3)
                {
                    for (int i = 0; i < 270; i++)
                    {
                        //pB[i].BackgroundImage = System.Drawing.Image.FromFile(znak);
                        pB[i].Invoke(new Action(delegate() { pB[i].Image = System.Drawing.Image.FromFile(znak); }));
                    }
                    // napis game over
                    int[] tabgameover = new int[89] { 30, 31, 32, 34, 35, 36, 38, 40, 42, 43, 44, 45, 49, 51, 53, 54, 55, 57, 60, 62, 64, 65, 66, 68, 70, 72, 73, 74, 75, 77, 79, 81, 83, 85, 87, 90, 91, 92, 94, 96, 98, 100, 102, 103, 104, 135, 136, 137, 139, 141, 143, 144, 145, 147, 148, 149, 150, 152, 154, 156, 158, 162, 164, 165, 167, 169, 171, 173, 174, 175, 177, 178, 179, 180, 182, 184, 186, 188, 192, 193, 195, 196, 197, 200, 203, 204, 205, 207, 209 };
                    for (int j = 0; j < tabgameover.Length; j++)
                    {
                        int z = tabgameover[j];
                        //pB[z].BackgroundImage = System.Drawing.Image.FromFile(znak2);
                        pB[z].Invoke(new Action(delegate() { pB[z].Image = System.Drawing.Image.FromFile(znak2); }));
                    }

                    label5.Invoke(new Action(delegate() { label5.Text = "X"; }));
                    label6.Invoke(new Action(delegate() { label6.Text = "X"; }));
                    label7.Invoke(new Action(delegate() { label7.Text = "X"; }));
                    trafienie = -1;
                    konce = 0;
                    punkty = 0;
                    gracz = 232;

                    over = true;
                }
                punkty = punkty - 10;
                trafienie++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Wybierz port com")
            {
                MessageBox.Show("Nie wybrałeś portu com");
            }
            else
            {
                port = new SerialPort(comboBox1.Text, 9600, Parity.None, 8, StopBits.One);

                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                if (!port.IsOpen)
                {
                    port.Open();
                    textBox1.Text = "OK";
                }
                else
                {
                    MessageBox.Show("Urządzenie nie zostało podłączone");
                }
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            licznik++;

            var odczyt = port.ReadChar();

            if (licznik == 2 && over == false)
            {
                if (odczyt == 'A')
                {
                    losujpozycje();
                    wrogowie();
                    wlewo();
                    czykolizja();
                }
                if (odczyt == 'D')
                {
                    losujpozycje();
                    wrogowie();
                    wprawo();
                    czykolizja();
                }

                if (odczyt == 'W')
                {
                    losujpozycje();
                    wrogowie();
                    wgore();
                    czykolizja();
                }

                if (odczyt == 'S')
                {
                    losujpozycje();
                    wrogowie();
                    wdol();
                    czykolizja();
                }
                licznik = 0;
                ruchy++;
            }

            if (odczyt == 'B')
            {
                DialogResult przycisk = MessageBox.Show("Czy chcesz zacząć grę od nowa?", "Nowa gra", MessageBoxButtons.YesNo);
                if (przycisk == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (przycisk == DialogResult.No)
                {
                    MessageBox.Show("Zapraszamy ponownie");
                    Application.Exit();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            licznik++;

            if (licznik == 3 && over == false)
            {
                if (e.KeyCode == Keys.W)
                {
                    losujpozycje();
                    wrogowie();
                    wgore();
                    czykolizja();
                }
                if (e.KeyCode == Keys.A)
                {
                    losujpozycje();
                    wrogowie();
                    wlewo();
                    czykolizja();
                }
                if (e.KeyCode == Keys.S)
                {
                    losujpozycje();
                    wrogowie();
                    wdol();
                    czykolizja();
                }
                if (e.KeyCode == Keys.D)
                {
                    losujpozycje();
                    wrogowie();
                    wprawo();
                    czykolizja();
                }
                licznik = 0;
                ruchy++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            port.Close();
        }

    }
}
