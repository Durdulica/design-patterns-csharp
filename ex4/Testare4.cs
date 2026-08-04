using DesignPatterns.ex4.Models;

namespace DesignPatterns.ex4
{
    public class Testare4
    {
        public Testare4()
        {
            IAfisaj[] observatori =
            {
                new AfisajCurent(),
                new AfisajStatistica(),
                new AfisajAlerta()
            };

            StatieMeteo statie = new(observatori);

            statie.SchimbaStare(20);
            Console.WriteLine();
            statie.SchimbaStare(30);
            Console.WriteLine();
            statie.SchimbaStare(40);
            Console.WriteLine();
            statie.SchimbaStare(30);
        }
    }
}
