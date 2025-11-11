using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace SIR_EpidemiModeli
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            double beta = double.Parse(txtBeta.Text);
            double gamma = double.Parse(txtGamma.Text);
            int gun = int.Parse(txtGun.Text);

            int N = 1000;
            double I0 = 1;
            double R0 = 0;
            double S0 = N - I0 - R0;

            var model = new SIR_EpidemiModeli.SIRModel
            {
                Beta = beta,
                Gamma = gamma,
                N = N
            };

            model.Hesapla(S0, I0, R0, gun);

            chart1.Series.Clear(); // köhnə qrafiki sil

            chart1.Series.Add("Sağlam (S)");
            chart1.Series.Add("Yoluxmuş (I)");
            chart1.Series.Add("Sağalmış (R)");

            foreach (var seriya in chart1.Series)
            {
                seriya.ChartType = SeriesChartType.Line;
                seriya.ToolTip = "#VALX gün: #VAL nəfər";
            }

            for (int i = 0; i < gun; i++)
            {
                chart1.Series["Sağlam (S)"].Points.AddXY(i, model.S[i]);
                chart1.Series["Yoluxmuş (I)"].Points.AddXY(i, model.I[i]);
                chart1.Series["Sağalmış (R)"].Points.AddXY(i, model.R[i]);

                chart1.Series["Sağlam (S)"].Points[i].ToolTip = $"{i}. gün: {model.S[i]} nəfər";
                chart1.Series["Yoluxmuş (I)"].Points[i].ToolTip = $"{i}. gün: {model.I[i]} nəfər";
                chart1.Series["Sağalmış (R)"].Points[i].ToolTip = $"{i}. gün: {model.R[i]} nəfər";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
