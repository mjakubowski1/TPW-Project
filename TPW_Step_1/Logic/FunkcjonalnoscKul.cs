using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logika
{
    public class FunkcjonalnoscKul : LogicAPI
    {
        public LicznikKul Kule { get; set; }

        public Plansza Plansza { get; set; }

        public CancellationTokenSource CancelSimulationSource { get; private set; }




        public FunkcjonalnoscKul(double s, double w)
        {
            Plansza = new Plansza(s, w);
            Kule = new LicznikKul();
            CancelSimulationSource = new CancellationTokenSource();
        }


        protected override void zmianaKoordynatow(RuchKul args)
        {
            base.zmianaKoordynatow(args);
        }


        public override int getLicznikKul()
        {
            return Kule.GetLicznikKul();
        }


        public void utworzKule(double p)
        {
            Random rng = new Random();
            double x = ((double)rng.NextDouble() * (Plansza.Szerokosc - (2 * p)) + p);
            double y = ((double)rng.NextDouble() * (Plansza.Wysokosc - (2 * p)) + p);
            double vx = (rng.NextDouble() - 0.5) * 20;
            double vy = (rng.NextDouble() - 0.5) * 20;
            this.Kule.DodajKule(new Kula(new Vector2((float)x, (float)y), p, new Vector2((float)vx, (float)vy)));
        }



        public override void dodajKule(int liczbaKul)
        {
            Random rng = new Random();
            for (int i = 0; i < liczbaKul; i++)
            {

                double p = (rng.NextDouble() * 20) + 20;
                double x = (rng.NextDouble() * (Plansza.Szerokosc - (2 * p)) + p);
                double y = (rng.NextDouble() * (Plansza.Wysokosc - (2 * p)) + p);
                double vx = (rng.NextDouble() - 0.5) * 20;
                double vy = (rng.NextDouble() - 0.5) * 20;
                this.Kule.DodajKule(new Kula(new Vector2((float)x, (float)y), p, new Vector2((float)vx, (float)vy)));
            }

        }


        public override Kula getKula(int i)
        {
            return Kule.GetKula(i);
        }


        public void PrzemieszczenieKuli(Kula k)
        {
            Vector2 nowyKoordynat = k.Koordynaty + k.Predkosc;
            if (nowyKoordynat.X - k.Promien < 0 && nowyKoordynat.X + k.Promien > Plansza.Szerokosc)
            {
                k.Predkosc = k.Predkosc * new Vector2(1, -1);
            }

            if (nowyKoordynat.Y - k.Promien < 0 && nowyKoordynat.Y + k.Promien > Plansza.Wysokosc)
            {
                k.Predkosc = k.Predkosc * new Vector2(-1, 1);
            }

            k.Koordynaty = k.Koordynaty + k.Predkosc;
        }


        public override void Start()
        {
            if (CancelSimulationSource.IsCancellationRequested) return;

            CancelSimulationSource = new CancellationTokenSource();

            for (int i = 0; i < Kule.GetLicznikKul(); i++)
            {
                RuchKul kula = new RuchKul(Kule.GetKula(i), i, this, Plansza.Szerokosc, Plansza.Wysokosc);
                kula.KoordynatyChange += (_, args) => zmianaKoordynatow(kula);
                Task.Factory.StartNew(kula.Ruch, CancelSimulationSource.Token);
            }

        }


        public override void Stop()
        {
            this.CancelSimulationSource.Cancel();
        }

        public void robKule(double p)
        {
            Random random = new Random();
            double x = ((double)random.NextDouble() * (Plansza.Szerokosc - (2 * p)) + 1 + p);
            double y = ((double)random.NextDouble() * (Plansza.Wysokosc - (2 * p)) + 1 + p);
        }

        public override void usunKule(int liczbaKul)
        {

        }
    }
}
