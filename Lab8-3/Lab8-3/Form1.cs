using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double val1 ;
        double val2 ;
        double val3 ;
        double val4 ;
        double val5 ;
        int n ;
        double countSum;
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            val1 = (double)Val1Ed1.Value;
            val2 = (double)Val1Ed2.Value;
            val3 = (double)Val1Ed3.Value;
            val4 = (double)Val1Ed4.Value;
            double s = val1 + val2 + val3 + val4;
            if (s > 1) 
            {
                MessageBox.Show("Ошибка, сумма вероятностей должна быть равна 1");
            }
            else
            {
                val5 = 1 - s;
            }
            Val1Ed5.Value = (decimal)val5;
            n = (int)numEd.Value;
            
            countSum = 0;

                //timer1.Start();

            double[] probabilities = { val1, val2, val3, val4, val5 };
            double[] genProg = new double[5];

            countSum = 0;
            Random rnd = new Random();
            double randNum;
            for (int i = 0; i < n; i++)
            {
                randNum = rnd.NextDouble();
                int event_id = 0;
                randNum -= probabilities[0];
                while (randNum > 0)
                {
                    event_id++;
                    randNum -= probabilities[event_id];
                };
                genProg[event_id]++;
            }

            for (int j = 0; j < 5; j++)
            {
                genProg[j] /= n;
                chart1.Series[j].Points.AddXY(j,genProg[j]);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (n == 0)
                timer1.Stop();
            else
                n--;
        }
    }
}
