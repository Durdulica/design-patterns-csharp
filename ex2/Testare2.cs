using DesignPatterns.ex2.Models;

namespace DesignPatterns.ex2
{
    public class Testare2
    {
        public Testare2()
        {
            JurnalLivrare jurnal = new JurnalLivrare();
            IObservator[] observatori = new IObservator[3]
            {
                new NotificatorEmail(),
                jurnal,
                new PanouDepozit(),
            };

            Comanda comanda = new(observatori);

            comanda.SchimbaStare("Expediata");
            comanda.Aboneaza(new JurnalLivrare());
            Console.WriteLine();
            comanda.SchimbaStare("Livrata");
            comanda.Dezaboneaza(jurnal);
            Console.WriteLine();
            comanda.SchimbaStare("Test");
        }
    }
}
