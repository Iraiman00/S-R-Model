using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace SIR_EpidemiModeli
{ 


        public class SIRModel
        {
            public double Beta { get; set; }      // Bulaşma oranı
            public double Gamma { get; set; }     // İyileşme oranı
            public int N { get; set; }            // Toplam nüfus

            public List<double> S { get; private set; }
            public List<double> I { get; private set; }
            public List<double> R { get; private set; }

            public void Hesapla(double S0, double I0, double R0, int gunSayisi)
            {
                S = new List<double>();
                I = new List<double>();
                R = new List<double>();

                double s = S0;
                double i = I0;
                double r = R0;
                double dt = 1.0;

                for (int t = 0; t <= gunSayisi; t++)
                {
                    S.Add(s);
                    I.Add(i);
                    R.Add(r);

                    double ds = -Beta * s * i / N;
                    double di = (Beta * s * i / N) - (Gamma * i);
                    double dr = Gamma * i;

                    s += ds * dt;
                    i += di * dt;
                    r += dr * dt;
                }
            }
        }
  
}

