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
using System.Windows.Forms.DataVisualization.Charting;

namespace MatStat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var lines = File.ReadAllLines($"C:\\Users\\ilya-\\Desktop\\Numbers.csv");

            List<double> arr = new List<double>();


            int columnNumber = int.Parse(textBox2.Text);

            for (int i = 0; i < lines.Length; i++)
            {
                var cells = lines[i].Split(',');
                arr.Add(double.Parse(cells[columnNumber]));
            }

            List<double> niList = new List<double>();
            int countValue = arr.Count();
            double xmax = arr.Max();
            double xmin = arr.Min();
            double k = Math.Floor(1 + 3.322 * Math.Log10(countValue)); //5
            var h = (xmax - xmin) / k; //4


            

            


            dataGridView1.Rows.Add(arr.Count());



            for (int i = 0; i < arr.Count(); i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = arr[i];
            }

            double startInt = 0;
            double endInt = Math.Floor(arr[0]);
            double xiavg = 0;
            double ni = 0 ;
            double xWithWave = 0;
            double sigma = 0;

            double gamma = 0.05;
            if (textBox1.Text != "")
            {
                gamma = double.Parse(textBox1.Text); // вводится 
            }
            

            for (int i = 0; i < k; i++)
            {
                startInt = endInt;
                endInt += h;
                xiavg = (startInt + endInt) / 2;
                ni = CulculateNi(startInt, endInt, arr);
                niList.Add(ni);
                xWithWave += (xiavg * ni) / arr.Count();


                dataGridView1.Rows[i].Cells[1].Value = $"{ Math.Round(startInt, 2)} - {Math.Round(endInt, 2)}"; //интервалы
                dataGridView1.Rows[i].Cells[2].Value = Math.Round(ni, 2); //n итое
                dataGridView1.Rows[i].Cells[3].Value = Math.Round(xiavg, 2); // xi сред
            };

            xWithWave = Math.Round(xWithWave, 2);
            dataGridView1.Rows[7].Cells[2].Value = $"x̃ = {xWithWave}";

            startInt = 0;
            endInt = Math.Floor(arr[0]);
            xiavg = 0;
            ni = 0;
            sigma = 0;
            double xXx = 0; // хз как назвать
            double sigmaSquere = 0;


            for (int i = 0; i < k; i++)
            {
                startInt = endInt;
                endInt += h;
                ni = CulculateNi(startInt, endInt, arr);

                niList.Add(ni);

                xiavg = (startInt + endInt) / 2;

                sigma = xiavg - xWithWave;
                xXx = Math.Round(sigma * sigma, 2);
                sigmaSquere += (xXx * ni) / 30;
                dataGridView1.Rows[i].Cells[4].Value = Math.Round(sigma,2); // sigma 
                dataGridView1.Rows[i].Cells[5].Value = Math.Round(xXx, 2); // sigma


            }

            var b = xmin;

            for (int j = 0; j < k; j++)
            {
                chart1.Series["Gista"].Points.AddXY($"{Math.Round(b, 2)}-{Math.Round(b+h, 2)}", $"{Math.Round(niList[j], 2)}");
                b += h;
            }

            sigmaSquere = Math.Round(sigmaSquere, 2);
            dataGridView1.Rows[8].Cells[2].Value = $"sigma^2 = {Math.Round(sigmaSquere, 2)}";
            var sigmaWithWave = Math.Round(Math.Sqrt(sigmaSquere),2);
            dataGridView1.Rows[9].Cells[2].Value = $"sigma = {Math.Round(sigmaWithWave, 2) }";

            double t = chart1.DataManipulator.Statistics.InverseTDistribution(gamma, arr.Count()-1);// ИЗ ТАБЛИЦЫ

            chart1.Titles.Add($"{t}");


            double righteInt = Math.Round(xWithWave + (t * sigmaWithWave) / Math.Sqrt(arr.Count()), 2);
            double leftInt = Math.Round(xWithWave - (t * sigmaWithWave) / Math.Sqrt(arr.Count()), 2);

            dataGridView1.Rows[10].Cells[2].Value = $"Du = {Math.Round(leftInt, 2)} < x̃ < {Math.Round(righteInt, 2)}";


            double a1 = (1 - gamma) / 2;
            double a2 = (1 + gamma) / 2;

            dataGridView1.Rows[11].Cells[2].Value = $"a1 = {a1}; a2 = {a2}";



            double Xsqe1 = Math.Round(((arr.Count() - 1) * sigmaSquere) / 45.7,5); // ВТОРОЙ ИНтерва : левое значение
            double Xsqe2 = Math.Round(((arr.Count() - 1) * sigmaSquere) / 16,5); // ВТОРОЙ ИНтерва : правое значение
            dataGridView1.Rows[12].Cells[2].Value = $"{Math.Round(Xsqe1, 2)} < Sigma с чертой < {Math.Round(Xsqe2, 2)}";



            startInt = 0;
            endInt = Math.Floor(arr[0]);

            double chastota = niList[0];

            int index = 0;

            for (int i = 0; i < niList.Count(); i++)
            {
                if(niList[i] > chastota)
                {
                    chastota = niList[i];
                    index = i;
                };
            }


            double nmMinus1;
            double nm = chastota;
            if(index != 0)
            {
                nmMinus1 = niList[index - 1];

            }
            else
            {
                nmMinus1 = 0;
            }
            double nmPlus1 = niList[index + 1];

            double x0 = 0;
            for (int i = 0; i < k; i++)
            {
                startInt = endInt;
                endInt += h;
                ni = CulculateNi(startInt, endInt, arr);
                if (chastota == ni)
                {
                    x0 = startInt;
                }
            }

            double Mo = x0 + ((nm - nmMinus1) / (nm - nmMinus1) + (nm - nmPlus1)) * h;
            dataGridView1.Rows[13].Cells[2].Value = $"Mo = {Math.Round(Mo, 2)}";

            double Me = x0 + ((0.5 * arr.Count() - nmMinus1) * h) / nm;
            dataGridView1.Rows[14].Cells[2].Value = $"Me = {Math.Round(Me, 2)}";


            double M3 = 0;
            double M4 = 0;

            sigma = 0;
            xiavg = 0;
            startInt = 0;
            endInt = Math.Floor(arr[0]);
            double sigmaPow3 = sigmaWithWave * sigmaWithWave * sigmaWithWave;
            double sigmaPow4 = sigmaWithWave * sigmaWithWave * sigmaWithWave * sigmaWithWave;

            for (int i = 0; i < k; i++)
            {
                startInt = endInt;
                endInt += h;
                ni = CulculateNi(startInt, endInt, arr);
                xiavg = (startInt + endInt) / 2;
                sigma = xiavg - xWithWave;

                M3 += ((sigma * sigma * sigma) * ni ) / 30;
                M4 += ((sigma * sigma * sigma * sigma) * ni) / 30;
            }

            M3 = Math.Round(M3, 2);
            sigmaPow3 = Math.Round(sigmaPow3, 2);
            double A3 = Math.Round(M3 / sigmaPow3, 2);
            double Ek = Math.Round((M4 / sigmaPow4) - 3, 2);

            dataGridView1.Rows[15].Cells[2].Value = $"Sigma^3 = {Math.Round(sigmaPow3, 2)}";
            dataGridView1.Rows[16].Cells[2].Value = $"M3 = {Math.Round(M3, 2)}";
            dataGridView1.Rows[17].Cells[2].Value = $"A3 = {Math.Round(A3, 2)}";

            dataGridView1.Rows[18].Cells[2].Value = $"Sigma^4 = {Math.Round(sigmaPow4, 2)}";
            dataGridView1.Rows[19].Cells[2].Value = $"M4 = {Math.Round(M4, 2)}";
            dataGridView1.Rows[20].Cells[2].Value = $"Ek = {Math.Round(Ek, 2)}";


            


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public double CulculateNi(double startInt , double endInt, List<double> arr)
        {
            double res=0;
            for (int i = 0; i < arr.Count(); i++)
            {
                if(arr[i] >= startInt && arr[i] < endInt)
                {
                    res++;
                }
            }

            if (endInt == arr[arr.Count() - 1])
            {
                res++;
            }

            return res;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
