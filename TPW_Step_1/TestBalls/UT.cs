using Logika;
using System.Numerics;

namespace TestBalls
{
    [TestClass]
    public class UT
    {
        [TestMethod]
        public void Test1()
        {
            LogicAPI przykladowe = new FunkcjonalnoscKul(50, 50);
            przykladowe.dodajKule(14);
            Assert.AreEqual(14, przykladowe.getLicznikKul());

        }

        public void Test2()
        {
            int liczbaInterakcji = 0;
            LogicAPI przykladowe2 = new FunkcjonalnoscKul(70, 70);
            przykladowe2.dodajKule(11);

            List<Vector2> lista = new List<Vector2>();
            for (int i = 0; i < przykladowe2.getLicznikKul(); i++)
            {
                lista.Add(przykladowe2.getKula(i).Koordynaty);
            }

            przykladowe2.ZdarzenieZmianyKoordynatow += (_, _) =>
            {
                liczbaInterakcji++;
                if (liczbaInterakcji >= 30)
                {
                    przykladowe2.Stop();
                }
            };
            przykladowe2.Start();
            while (liczbaInterakcji < 30)
            { }
            Assert.IsTrue(liczbaInterakcji >= 29);
            for (int i = 0; i < przykladowe2.getLicznikKul(); i++)
            {
                if (lista[i] == przykladowe2.getKula(i).Koordynaty)
                {
                    Assert.Fail();
                }
            }
        }
    }
}