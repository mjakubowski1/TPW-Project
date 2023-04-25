using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class LicznikKul : DataAPI
    {
        private List<Kula> kule;

        public LicznikKul()
        {
            kule = new List<Kula>();
        }

        public override int GetLicznikKul()
        {
            return kule.Count;
        }

        public override void DodajKule(Kula kula)
        {
            kule.Add(kula);
        }

        public override Kula GetKula(int id)
        {
            return kule[id];
        }
    }
}

