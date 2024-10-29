using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using treadsmedia;




namespace treadsmedia
{
    public partial class Form1 : Form
    {

        static Random rnd = new Random();
        static int[] numeri = new int[3];
        static int turno = 0;

        public Form1()
        {
            InitializeComponent();
        }

        //generatore di numeri casuali
        private void button1_Click(object sender, EventArgs e)
        {
            Thread e1 = new Thread(new ThreadStart(inserisci));
            e1.Start();
        }

        //calcolo media
        private void button2_Click(object sender, EventArgs e)
        {

            Thread e2 = new Thread(new ThreadStart(media));
            e2.Start();

        }

        public void inserisci()
        {
            while (true) {
                while (turno != 0) 
                    Thread.Sleep(100);

                lock (numeri)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        numeri[i] = rnd.Next(1, 100);
                    }

                }
                turno = 1;

                Invoke(new Action(() =>
                {
                    listBox1.Items.Add($"Numeri casuali: {numeri[0]}, {numeri[1]}, {numeri[2]}");
                }));
                Thread.Sleep(1000);

            }


        }
       
        public void media()
        {
            float media = 0;
            while (true)
            {
                while (turno != 1)
                    Thread.Sleep(100);
                lock (numeri)
                {
                    int somma = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        somma += numeri[i];
                    }
                     media = somma / 3.0F;
                    
                }
                turno = 0;
                Invoke(new Action(() =>
                {
                    listBox1.Items.Add($"MEDIA: {media}");
                }));
                Thread.Sleep(2000);
            }
           


        }
    }
}
