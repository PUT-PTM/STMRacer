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
    public partial class Form1 : Form
    {
        PictureBox[] pB = new PictureBox[270];

        public Form1()
        {
            InitializeComponent();

            pB[0] = pictureBox1; pB[1] = pictureBox2; pB[2] = pictureBox3; pB[3] = pictureBox4; pB[4] = pictureBox5; pB[5] = pictureBox6; pB[6] = pictureBox7; pB[7] = pictureBox8; pB[8] = pictureBox9; pB[9] = pictureBox10; pB[10] = pictureBox11;
            pB[11] = pictureBox12; pB[12] = pictureBox13; pB[13] = pictureBox14; pB[14] = pictureBox15; pB[15] = pictureBox16; pB[16] = pictureBox17; pB[17] = pictureBox18; pB[18] = pictureBox19; pB[19] = pictureBox20; pB[20] = pictureBox21;
            pB[21] = pictureBox22; pB[22] = pictureBox23; pB[23] = pictureBox24; pB[24] = pictureBox25; pB[25] = pictureBox26; pB[26] = pictureBox27; pB[27] = pictureBox28; pB[28] = pictureBox29; pB[29] = pictureBox30; pB[30] = pictureBox31;
            pB[31] = pictureBox32; pB[32] = pictureBox33; pB[33] = pictureBox34; pB[34] = pictureBox35; pB[35] = pictureBox36; pB[36] = pictureBox37; pB[37] = pictureBox38; pB[38] = pictureBox39; pB[39] = pictureBox40; pB[40] = pictureBox41;
            pB[41] = pictureBox42; pB[42] = pictureBox43; pB[43] = pictureBox44; pB[44] = pictureBox45; pB[45] = pictureBox46; pB[46] = pictureBox47; pB[47] = pictureBox48; pB[48] = pictureBox49; pB[49] = pictureBox50; pB[50] = pictureBox51;
            pB[51] = pictureBox52; pB[52] = pictureBox53; pB[53] = pictureBox54; pB[54] = pictureBox55; pB[55] = pictureBox56; pB[56] = pictureBox57; pB[57] = pictureBox58; pB[58] = pictureBox59; pB[59] = pictureBox60; pB[60] = pictureBox61;
            pB[61] = pictureBox62; pB[62] = pictureBox63; pB[63] = pictureBox64; pB[64] = pictureBox65; pB[65] = pictureBox66; pB[66] = pictureBox67; pB[67] = pictureBox68; pB[68] = pictureBox69; pB[69] = pictureBox70; pB[70] = pictureBox71;
            pB[71] = pictureBox72; pB[72] = pictureBox73; pB[73] = pictureBox74; pB[74] = pictureBox75; pB[75] = pictureBox76; pB[76] = pictureBox77; pB[77] = pictureBox78; pB[78] = pictureBox79; pB[79] = pictureBox80; pB[80] = pictureBox81;
            pB[81] = pictureBox82; pB[82] = pictureBox83; pB[83] = pictureBox84; pB[84] = pictureBox85; pB[85] = pictureBox86; pB[86] = pictureBox87; pB[87] = pictureBox88; pB[88] = pictureBox89; pB[89] = pictureBox90; pB[90] = pictureBox91;
            pB[91] = pictureBox92; pB[92] = pictureBox93; pB[93] = pictureBox94; pB[94] = pictureBox95; pB[95] = pictureBox96; pB[96] = pictureBox97; pB[97] = pictureBox98; pB[98] = pictureBox99; pB[99] = pictureBox100; pB[100] = pictureBox101;
            pB[101] = pictureBox102; pB[102] = pictureBox103; pB[103] = pictureBox104; pB[104] = pictureBox105; pB[105] = pictureBox106; pB[106] = pictureBox107; pB[107] = pictureBox108; pB[108] = pictureBox109; pB[109] = pictureBox110; pB[110] = pictureBox111;
            pB[111] = pictureBox112; pB[112] = pictureBox113; pB[113] = pictureBox114; pB[114] = pictureBox115; pB[115] = pictureBox116; pB[116] = pictureBox117; pB[117] = pictureBox118; pB[118] = pictureBox119; pB[119] = pictureBox120; pB[120] = pictureBox121;
            pB[121] = pictureBox122; pB[122] = pictureBox123; pB[123] = pictureBox124; pB[124] = pictureBox125; pB[125] = pictureBox126; pB[126] = pictureBox127; pB[127] = pictureBox128; pB[128] = pictureBox129; pB[129] = pictureBox130; pB[130] = pictureBox131;
            pB[131] = pictureBox132; pB[132] = pictureBox133; pB[133] = pictureBox134; pB[134] = pictureBox135; pB[135] = pictureBox136; pB[136] = pictureBox137; pB[137] = pictureBox138; pB[138] = pictureBox139; pB[139] = pictureBox140; pB[140] = pictureBox141;
            pB[141] = pictureBox142; pB[142] = pictureBox143; pB[143] = pictureBox144; pB[144] = pictureBox145; pB[145] = pictureBox146; pB[146] = pictureBox147; pB[147] = pictureBox148; pB[148] = pictureBox149; pB[149] = pictureBox150; pB[150] = pictureBox151;
            pB[151] = pictureBox152; pB[152] = pictureBox153; pB[153] = pictureBox154; pB[154] = pictureBox155; pB[155] = pictureBox156; pB[156] = pictureBox157; pB[157] = pictureBox158; pB[158] = pictureBox159; pB[159] = pictureBox160; pB[160] = pictureBox161;
            pB[161] = pictureBox162; pB[162] = pictureBox163; pB[163] = pictureBox164; pB[164] = pictureBox165; pB[165] = pictureBox166; pB[166] = pictureBox167; pB[167] = pictureBox168; pB[168] = pictureBox169; pB[169] = pictureBox170; pB[170] = pictureBox171;
            pB[171] = pictureBox172; pB[172] = pictureBox173; pB[173] = pictureBox174; pB[174] = pictureBox175; pB[175] = pictureBox176; pB[176] = pictureBox177; pB[177] = pictureBox178; pB[178] = pictureBox179; pB[179] = pictureBox180; pB[180] = pictureBox181;
            pB[181] = pictureBox182; pB[182] = pictureBox183; pB[183] = pictureBox184; pB[184] = pictureBox185; pB[185] = pictureBox186; pB[186] = pictureBox187; pB[187] = pictureBox188; pB[188] = pictureBox189; pB[189] = pictureBox190; pB[190] = pictureBox191;
            pB[191] = pictureBox192; pB[192] = pictureBox193; pB[193] = pictureBox194; pB[194] = pictureBox195; pB[195] = pictureBox196; pB[196] = pictureBox197; pB[197] = pictureBox198; pB[198] = pictureBox199; pB[199] = pictureBox200; pB[200] = pictureBox201;
            pB[201] = pictureBox202; pB[202] = pictureBox203; pB[203] = pictureBox204; pB[204] = pictureBox205; pB[205] = pictureBox206; pB[206] = pictureBox207; pB[207] = pictureBox208; pB[208] = pictureBox209; pB[209] = pictureBox210; pB[210] = pictureBox211;
            pB[211] = pictureBox212; pB[212] = pictureBox213; pB[213] = pictureBox214; pB[214] = pictureBox215; pB[215] = pictureBox216; pB[216] = pictureBox217; pB[217] = pictureBox218; pB[218] = pictureBox219; pB[219] = pictureBox220; pB[220] = pictureBox221;
            pB[221] = pictureBox222; pB[222] = pictureBox223; pB[223] = pictureBox224; pB[224] = pictureBox225; pB[225] = pictureBox226; pB[226] = pictureBox227; pB[227] = pictureBox228; pB[228] = pictureBox229; pB[229] = pictureBox230; pB[230] = pictureBox231;
            pB[231] = pictureBox232; pB[232] = pictureBox233; pB[233] = pictureBox234; pB[234] = pictureBox235; pB[235] = pictureBox236; pB[236] = pictureBox237; pB[237] = pictureBox238; pB[238] = pictureBox239; pB[239] = pictureBox240; pB[240] = pictureBox241;
            pB[241] = pictureBox242; pB[242] = pictureBox243; pB[243] = pictureBox244; pB[244] = pictureBox245; pB[245] = pictureBox246; pB[246] = pictureBox247; pB[247] = pictureBox248; pB[248] = pictureBox249; pB[249] = pictureBox250; pB[250] = pictureBox251;
            pB[251] = pictureBox252; pB[252] = pictureBox253; pB[253] = pictureBox254; pB[254] = pictureBox255; pB[255] = pictureBox256; pB[256] = pictureBox257; pB[257] = pictureBox258; pB[258] = pictureBox259; pB[259] = pictureBox260; pB[260] = pictureBox261;
            pB[261] = pictureBox262; pB[262] = pictureBox263; pB[263] = pictureBox264; pB[264] = pictureBox265; pB[265] = pictureBox266; pB[266] = pictureBox267; pB[267] = pictureBox268; pB[268] = pictureBox269; pB[269] = pictureBox270;

            rysbrzegi();
        }
        
        
        private SerialPort port = new SerialPort("COM5",9600, Parity.None, 8, StopBits.One);  

        public static int wro1;
        public static int wro2;
        public static int gracz = 232;
        public static int pom = 0;
        public static int punkty = 0;
        public static int trafienie = 0;
        public static int licznik = 0;
        

        string znak = @"..\..\znak.jpg";
        string znak2 = @"..\..\znak2.jpg";

        public void rysgracz()
        {
            pB[gracz].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[gracz + 14].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[gracz + 15].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[gracz + 16].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[gracz + 29].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[gracz + 31].BackgroundImage = System.Drawing.Image.FromFile(znak2);
        }

        public void rysbrzegi()
        {
            // brzegi
            for (int i = 0; i < 265; i += 15)
            {
                pB[i].Image = System.Drawing.Image.FromFile(znak2);
                pB[i + 14].Image = System.Drawing.Image.FromFile(znak2);
            }
        }

        public void wprawo()
        {
            if ((gracz+1 != 13) &&(gracz+1 != 28) &&(gracz+1 != 43) &&(gracz+1 != 58) &&(gracz+1 != 73) &&(gracz+1 != 88) &&(gracz+1 != 103) &&(gracz+1 != 118) &&(gracz+1 != 133) &&(gracz+1 != 148) &&(gracz+1 != 163) &&(gracz+1 != 178) && (gracz+1 != 193) && (gracz+1 != 208) && (gracz+1 != 223) && (gracz+1 != 238))
            {
                gracz += 1;
                pB[gracz-1].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 13].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 14].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 15].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 28].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 30].BackgroundImage = System.Drawing.Image.FromFile(znak);
            }
            rysgracz();
        }

        public void wlewo()
        {
            if ((gracz - 1 != 1) && (gracz - 1 != 16) && (gracz - 1 != 31) && (gracz - 1 != 46) && (gracz - 1 != 61) && (gracz - 1 != 76) && (gracz - 1 != 91) && (gracz - 1 != 106) && (gracz - 1 != 121) && (gracz - 1 != 136) && (gracz - 1 != 151) && (gracz - 1 != 166) && (gracz - 1 != 181) && (gracz - 1 != 196) && (gracz - 1 != 211) && (gracz - 1 != 226))
            {
                gracz -= 1;
                pB[gracz + 1].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 15].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 16].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 17].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 30].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 32].BackgroundImage = System.Drawing.Image.FromFile(znak);
            }
            rysgracz();
        }

        public void wgore()
        {
            if ((gracz - 15) > 1)
            {
                gracz -= 15;
                pB[gracz + 15].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 29].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 30].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 31].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 44].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 46].BackgroundImage = System.Drawing.Image.FromFile(znak);
            }
            rysgracz();
        }

        public void wdol()
        {
            if ((gracz+15) < 238)
            {
                gracz += 15;
                pB[gracz-15].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz -1].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 1].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 14].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[gracz + 16].BackgroundImage = System.Drawing.Image.FromFile(znak);
            }
            rysgracz();
        }

        public void losujpozycje()
        {
            if (pom == 16 || pom == 0)
            {
                if (pom == 16)
                {
                    kasujwrogow();
                }
                
                if (pom > 0)
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
                pom = 0;
            }
            pom++;

            label4.Invoke(new Action(delegate() { label4.Text = punkty.ToString(); }));
        }

        public void wrogowie()
        {
            // wrog 1
            if (wro1 > 15)
            {
                pB[wro1 - 15].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[wro1 - 1].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[wro1].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[wro1 + 1].BackgroundImage = System.Drawing.Image.FromFile(znak);

            }

            pB[wro1].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[wro1 + 14].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[wro1 + 15].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[wro1 + 16].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[wro1 + 29].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[wro1 + 31].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            wro1 += 15;

            // wrog 2
            if (wro2 > 15)
            {
                pB[wro2 - 15].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[wro2 - 1].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[wro2].BackgroundImage = System.Drawing.Image.FromFile(znak);
                pB[wro2 + 1].BackgroundImage = System.Drawing.Image.FromFile(znak);

            }

            pB[wro2].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[wro2 + 14].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[wro2 + 15].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[wro2 + 16].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[wro2 + 29].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            pB[wro2 + 31].BackgroundImage = System.Drawing.Image.FromFile(znak2);
            wro2 += 15;
        }

        public void kasujwrogow()
        {
            wro1 -= 15;
            wro2 -= 15;

            pB[wro1].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[wro1 + 14].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[wro1 + 15].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[wro1 + 16].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[wro1 + 29].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[wro1 + 31].BackgroundImage = System.Drawing.Image.FromFile(znak);

            pB[wro2].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[wro2 + 14].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[wro2 + 15].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[wro2 + 16].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[wro2 + 29].BackgroundImage = System.Drawing.Image.FromFile(znak);
            pB[wro2 + 31].BackgroundImage = System.Drawing.Image.FromFile(znak);
        }

        public void czykolizja()
        {
            if (gracz == wro1 - 2 || gracz == wro1 - 1 || gracz == wro1 + 1 || gracz == wro1 + 2 || gracz == wro1 + 16 || gracz == wro1 + 17 || gracz == wro1 ||
                gracz == wro2 - 2 || gracz == wro2 - 1 || gracz == wro2 + 1 || gracz == wro2 + 2 || gracz == wro2 + 16 || gracz == wro2 + 17 || gracz == wro2)
            {
                if (trafienie == 0)
                {
                    label5.Invoke(new Action(delegate() { label5.Text = "-"; }));
                }
                if (trafienie == 1)
                {
                    label6.Invoke(new Action(delegate() { label6.Text = "-"; }));
                }
                if (trafienie == 2)
                {
                    label7.Invoke(new Action(delegate() { label7.Text = "-"; })); 
                }
                if (trafienie == 3)
                {
                    for (int i = 0; i < 270;i++)
                    {
                        //pB[i].BackgroundImage = System.Drawing.Image.FromFile(znak);
                        pB[i].Invoke(new Action(delegate() { pB[i].Image = System.Drawing.Image.FromFile(znak); }));
                    }
                    int[] tabgameover = new int[89]{30,31,32,34,35,36,38,40,42,43,44,45,49,51,53,54,55,57,60,62,64,65,66,68,70,72,73,74,75,77,79,81,83,85,87,90,91,92,94,96,98,100,102,103,104,135,136,137,139,141,143,144,145,147,148,149,150,152,154,156,158,162,164,165,167,169,171,173,174,175,177,178,179,180,182,184,186,188,192,193,195,196,197,200,203,204,205,207,209};
                    for (int j = 0; j < tabgameover.Length;j++)
                    {
                        int z = tabgameover[j];
                        //pB[z].BackgroundImage = System.Drawing.Image.FromFile(znak2);
                        pB[z].Invoke(new Action(delegate() { pB[z].Image = System.Drawing.Image.FromFile(znak2); }));
                    }

                    label5.Invoke(new Action(delegate() { label5.Text = "X"; }));
                    label6.Invoke(new Action(delegate() { label6.Text = "X"; }));
                    label7.Invoke(new Action(delegate() { label7.Text = "X"; }));
                    trafienie = -1;
                    pom = 0;
                    punkty = 0;
                    gracz = 232;

                    //return 1;
                }
                trafienie++;
            }
            //return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            //port.Open();
            if(!port.IsOpen)
            {
                port.Open();
                textBox1.Text = "OK";    
            }
            else
            {
                MessageBox.Show("Urządzenie nie zostało podłączone");
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var odczyt = port.ReadChar();

            if(odczyt == 'A')
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
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
           
           
                port.Close();
            

        }
        

    }
    
}
