using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public abstract class LogicAPI
    {

        public event EventHandler<RuchKul>? ZdarzenieZmianyKoordynatow;

        public abstract Kula getKula(int index);

        public abstract void dodajKule(int liczbaKul);

        public abstract void usunKule(int liczbaKul);

        public abstract int getLicznikKul();

        public abstract void Start();

        public abstract void Stop();

        protected virtual void zmianaKoordynatow(RuchKul k)
        {
            ZdarzenieZmianyKoordynatow?.Invoke(this, k);
        }
    }
}
