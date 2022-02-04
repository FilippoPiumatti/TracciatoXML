using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProgettoGaraNuotoThread
{
    public partial class Form1 : Form
    {
        volatile int TotAtleti;
        volatile Random rnd;
        volatile Dictionary<string, int> atleti = new Dictionary<string, int>();
        const int BATTERIE = 4; //n corsie
        const int COORDS_Y = 40;
        const int START_COORDS_Y = 16;
        const int FINISH_COORDS_Y = 650;
        Thread arbitro;
        Thread[] Atlbatterie;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("atleti.txt");
            string testo;
            lblAtleti.Text = "";
            while (!sr.EndOfStream)
            {
                testo = sr.ReadLine();
                lblAtleti.Text += testo + Environment.NewLine;//per andare a capo;
                atleti.Add(testo, 1);// l 1 rappresenta l atleta che non ha ancora gareggiato
            }
            sr.Close();
            StampaAtletiResidui();
            TotAtleti = atleti.Count;
        }

        private void StampaAtletiResidui()
        {
            BeginInvoke((MethodInvoker)delegate ()//equivalente dell function di callback di jquery
            {

            });
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            lblAtleti.Text = "";
            for (int i = 0; i < atleti.Count; i++)//oppure posso fare il foreach, come vuoi
            {
                if (atleti.ElementAt(i).Value == 1)//alternativa al ciclo for, uso la funzione element , ovvero elemento nella chiave i
                {
                    lblAtleti.Text += atleti.ElementAt(i).ToString() + Environment.NewLine;
                }
            }
        }

        private void BtnAvvia_Click(object sender, EventArgs e)
        {
            rnd = new Random();
            lblEsito.Text = "";
            lblEliminati.Text = "";
            arbitro = new Thread(ArbitroThread);
            arbitro.Start();
        }

        private void ArbitroThread()
        {
            int AtletiResidui = TotAtleti;
            int turno = 0;
            while (AtletiResidui > 0)
            {
                SetLabel(lblTurno, "turno: " + (turno++).ToString());
                EseguiTurno();
                AtletiResidui -= BATTERIE;
            }
        }

        private void EseguiTurno()
        {
            int PosAtl;
            TextBox txtA;
            Atlbatterie = new Thread[BATTERIE];
            /*PER OGNI TURNO MAX DI ATLETI POSSONO PARTECIPARE*/
            for (int i = 0; i < BATTERIE; i++)
            {
                txtA = new TextBox();
                txtA = (TextBox)Controls["txtA" + (i + 1).ToString()];
                do
                {
                    PosAtl = rnd.Next(0, TotAtleti);
                } while (atleti.ElementAt(PosAtl).Value != 1);
                //ora abbiamno messo in posAtl una posizione di un altleta che non ha ancora gareggiato
                atleti[atleti.ElementAt(PosAtl).Key] = 0;
                BeginInvoke((MethodInvoker)delegate ()
                {
                    txtA.Text = atleti.ElementAt(PosAtl).Key;

                });
                Thread.Sleep(1000);

                Atlbatterie[i] = new Thread(gara);
                Atlbatterie[i].Name = txtA.Text;
                Atlbatterie[i].Start();
            }
            StampaAtletiResidui();

            for (int i = 0; i < BATTERIE; i++)
            {
                Atlbatterie[i].Join();
            }

        }

        private void gara(object parameter)
        {
            TextBox txtAtl = (parameter as TextBox);
            string atleta = Thread.CurrentThread.Name;
            SetPos(txtAtl, txtAtl.Location.X, START_COORDS_Y);
            Thread.Sleep(2000);
            SetLabel(lblStato, "VIA!");
            do
            {
                Thread.Sleep(300);
                SetPos(txtAtl, txtAtl.Location.X, txtAtl.Location.Y + (rnd.Next(1, 50)));
            } while (txtAtl.Location.Y < FINISH_COORDS_Y);

            SetPos(txtAtl, txtAtl.Location.X, START_COORDS_Y);
            SetText(txtAtl, "");
            SetLabel(lblStato, "END!");
        }

        private void SetText(TextBox txtAtl, string v)
        {
            v = "about nothung bro seeen";
        }

        private void SetPos(TextBox txt, int x, int y)
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
                txt.Location = new Point(x, y);
            });
        }

        private void SetLabel(Label lbl, string msg)
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
                lbl.Text = msg;
            });
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
