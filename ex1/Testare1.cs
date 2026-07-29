using DesignPatterns.ex1.Models;

namespace DesignPatterns.ex1
{
    public class Testare1
    {
        public Testare1()
        {
            LivrareStandard strategie = new();
            Comanda comanda = new("Stefan",100,20,strategie);

            Console.WriteLine(strategie.Nume + ": " + comanda.CostTransport());

            LivrareExpress noua = new();

            comanda.SchimbaStrategie(noua);
            Console.WriteLine(noua.Nume + ": " + comanda.CostTransport());

            LivrareGratuita gratuita = new();

            comanda.SchimbaStrategie(gratuita);
            Console.WriteLine(gratuita.Nume + ": " + comanda.CostTransport());

            LivrareCuReducere reducere = new(50, noua);

            comanda.SchimbaStrategie(reducere);
            Console.WriteLine(reducere.Nume + ": " + comanda.CostTransport());
        }
    }
}
