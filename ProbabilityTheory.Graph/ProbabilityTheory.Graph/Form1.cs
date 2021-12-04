using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbabilityTheory.Graph
{
    public partial class Form1 : Form
    {
        private double a, sig, c, d;
        private double x, y;
        Stopwatch stopWatch = new Stopwatch();
        private void label5_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stopWatch.Start();
            a = Convert.ToDouble(textBox_a.Text);
            sig = Convert.ToDouble(textBox_sig.Text);
            c = Convert.ToDouble(textBox_c.Text);
            d = Convert.ToDouble(textBox_d.Text);

            var x_start = a - 3 * sig;
            var x_end = a + 3 * sig;


            for (x = x_start; x < x_end; x ++)
            {
                y = (1 / (sig * Math.Sqrt(2 * Math.PI))) * (Math.Pow(Math.E, -0.5 * ((x - a) / sig) * ((x - a) / sig)));
                this.chart.Series[0].Points.AddXY(x, y);
            }

            
            DoIntegral(a,sig,c, d);
            stopWatch.Stop();

            textBox_time.Text = Convert.ToString(stopWatch.Elapsed.TotalMilliseconds);

        }

        private void DoIntegral(double a, double sig, double c, double d)
        {
            double f(double x) => Math.Pow(Math.E, ((-x * x) / 2));

            var FI_1 = (c - a) / sig;
            var FI_2 = (d - a) / sig;

            var FI_1_res = 1 / Math.Sqrt(2 * Math.PI) * Simpson(f, 0, FI_1, 1000);
            var FI_2_res = 1 / Math.Sqrt(2 * Math.PI) * Simpson(f, 0, FI_2, 1000);

            var res = FI_2_res - FI_1_res;

            textBox_p.Text = Convert.ToString(res);
        }

        private static double Simpson(Func<double, double> f, double a, double b, int n)
        {
            var h = (b - a) / n;
            var sum1 = 0d;
            var sum2 = 0d;
            for (var k = 1; k <= n; k++)
            {
                var xk = a + k * h;
                if (k <= n - 1)
                {
                    sum1 += f(xk);
                }

                var xk_1 = a + (k - 1) * h;
                sum2 += f((xk + xk_1) / 2);
            }

            var result = h / 3d * (1d / 2d * f(a) + sum1 + 2 * sum2 + 1d / 2d * f(b));
            return result;
        }
    }
}
