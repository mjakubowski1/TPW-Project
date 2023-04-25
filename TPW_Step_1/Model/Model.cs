using Logika;
using System;
using System.Numerics;

namespace Model
{
    public class OnPositionChangeUiAdapterEventArgs : EventArgs
    {
        public readonly Vector2 Koordynaty;
        public readonly int ID;

        public OnPositionChangeUiAdapterEventArgs(Vector2 koordynaty, int id)
        {
            this.Koordynaty = koordynaty;
            ID = id;
        }
    }

    public class ModelClass
    {
        public double SzerokoscPlanszy;
        public double WysokoscPlanszy;
        public int LiczbaKul;
        public LogicAPI? logika;
        public event EventHandler<OnPositionChangeUiAdapterEventArgs>? ZmianaKoordynatow;


        public ModelClass()
        {
            SzerokoscPlanszy = 600;
            WysokoscPlanszy = 600;
            logika = new FunkcjonalnoscKul(SzerokoscPlanszy, WysokoscPlanszy);
            LiczbaKul = 0;

            logika.ZdarzenieZmianyKoordynatow += (z, k) =>
            {
                ZmianaKoordynatow?.Invoke(this, new OnPositionChangeUiAdapterEventArgs(k.GetKula().Koordynaty, k.id));
            };
        }
        public void StartProgram()
        {
            logika.dodajKule(LiczbaKul);
            logika.Start();
        }

        public void StopProgram()
        {
            logika.Stop();
            logika = new FunkcjonalnoscKul(SzerokoscPlanszy, WysokoscPlanszy);
            logika.ZdarzenieZmianyKoordynatow += (z, k) =>
            {
                ZmianaKoordynatow?.Invoke(this, new OnPositionChangeUiAdapterEventArgs(k.GetKula().Koordynaty, k.id));
            };
        }

        public void SetLicznikKul(int ilosc)
        {
            LiczbaKul = ilosc;
        }

        public int GetLicznikKul()
        {
            return LiczbaKul;
        }

        public void OnBallPositionChange(OnPositionChangeUiAdapterEventArgs args)
        {
            ZmianaKoordynatow?.Invoke(this, args);
        }
    }
}
