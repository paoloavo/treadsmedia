using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace treadsmedia
{
    public class estrattore
    {
        static bool[] numeri = new bool[101];
        static int[] sharedArray = new int[3];
        static Random r = new Random();
        int estratti = 0;
        string persona;
        Form1 form;

        public estrattore(Form1 form1, string persona)
        {
            form = form1;
            this.persona = persona;
        }
        public void Esegui()
        {
            Thread t1 = new Thread(Estrai);
            t1.Start();
        }

        public void Estrai()

        {
            int i;
            int n;
            while (true)
            {


                lock (numeri)
                {
                    for (i = 0; i < 3; i++)
                    {
                        sharedArray[i] = new Random().Next(1, 100);

                        form.Invoke(new Action(() => form.AggiornaListBox(sharedArray[i])));
                    }

                    Thread.Sleep(3000);

                    if (i == 3)
                    {

                        int media = (sharedArray[0] + sharedArray[1] + sharedArray[2]) / 3;


                        form.Invoke(new Action(() => form.AggiornaListBox(media)));
                    }
                }


            }
        }
        public void media()
        {
            int media = (sharedArray[0] + sharedArray[1] + sharedArray[2]) / 3;
            form.Invoke(new Action(() => form.AggiornaListBox(media)));
        }
    }
}
