using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Kula
    {
        public Vector2 Predkosc { get; set; }
        public Vector2 Koordynaty { get; set; }
        public double Promien { get; set; }

        public Kula(Vector2 k, double pr, Vector2 p)
        {
            Koordynaty = k;
            Promien = 25;
            Predkosc = p;
        }
    }
}
