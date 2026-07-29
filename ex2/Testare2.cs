using DesignPatterns.ex2.Models;

namespace DesignPatterns.ex2
{
    public class Testare2
    {
        public Testare2()
        {
            IObservator[] observatori = new IObservator[3]
            {
                new NotificatorEmail(),
                new JurnalLivrare(),
                new PanouDepozit(),
            };

            Comanda comanda = new(observatori);

            comanda.SchimbaStare("Expediata");
            Console.WriteLine();
            comanda.SchimbaStare("Livrata");
        }
    }
}
