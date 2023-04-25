using System;
using System.Collections.Generic;
using System.Text;
using Dane;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Logika
{
    public class RuchKul
    {
        private Kula kula;
        public int id;
        private FunkcjonalnoscKul wl;

        public double Xend;
        public double Yend;

        public event EventHandler<RuchKul>? KoordynatyChange;

        
        public RuchKul(Kula k, int id, FunkcjonalnoscKul wl, double Xend, double Yend)
        {
            this.kula = k;
            this.id = id;
            this.wl = wl;
            this.Xend = Xend;
            this.Yend = Yend;
        }

        public Kula GetKula()
        {
            return kula;
        }


        public async void Ruch()
        {
            while (!wl.CancelSimulationSource.Token.IsCancellationRequested)
            {
                Vector2 nowyKoordynat = this.kula.Koordynaty + this.kula.Predkosc;

                if (nowyKoordynat.X < 0 || nowyKoordynat.X + this.kula.Promien > this.Xend)
                {
                    this.kula.Predkosc = this.kula.Predkosc * new Vector2(-1, 1);
                }

                if (nowyKoordynat.Y < 0 || nowyKoordynat.Y + this.kula.Promien > this.Yend)
                {
                    this.kula.Predkosc = this.kula.Predkosc * new Vector2(1, -1);
                }

                this.kula.Koordynaty = this.kula.Koordynaty + this.kula.Predkosc;
                KoordynatyChange?.Invoke(this, this);
                await Task.Delay(20, wl.CancelSimulationSource.Token).ContinueWith(_ => { });
            }
        }


    }


}

