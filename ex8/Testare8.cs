using DesignPatterns.ex8.Models;

namespace DesignPatterns.ex8
{
    public class Testare8
    {
        public Testare8()
        {
            IObservatorCont[] observatori = [
                new NotificatorSms(),
                new JurnalAudit(),
                new AlertaSoldMic(55)
                ];

            Cont cont = new(1000, observatori);

            cont.Retrage(950);
            Console.WriteLine();
            cont.Depune(500);
            Console.WriteLine();
            try
            {
                cont.Retrage(600);
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
