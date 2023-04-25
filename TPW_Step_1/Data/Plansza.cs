using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Plansza
    {
        public double Wysokosc { get; }
        public double Szerokosc { get; }

        public Plansza(double szerokosc, double wysokosc)
        {
            Szerokosc = szerokosc;
            Wysokosc = wysokosc;
        }

    }
}
