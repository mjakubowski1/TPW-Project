using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class DataAPI

    {
        public abstract void DodajKule(Kula kula);
        public abstract Kula GetKula(int i);

        public abstract int GetLicznikKul();

        public static Kula StworzKule(Vector2 k, double pr, Vector2 p)
        {
            return new Kula(k, pr, p);
        }
        public static Plansza StworzPlansze(double s, double w)
        {
            return new Plansza(s, w);

        }
    }
}
