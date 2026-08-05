using DesignPatterns.ex6.Models;

namespace DesignPatterns.ex6
{
    public class Testare6
    {
        public Testare6()
        {
            ComisionFix strategie = new(50.00m);
            Vanzare vanzare = new(1500,strategie);

            Console.WriteLine(strategie.Nume + ": " + vanzare.Comision());

            ComisionProcent procent = new(10);
            vanzare.SchimbaComision(procent);
            Console.WriteLine(procent.Nume + ": " + vanzare.Comision());

            ComisionPePraguri praguri = new();
            vanzare.SchimbaComision(praguri);
            Console.WriteLine(praguri.Nume + ": " + vanzare.Comision());

            ComisionCuPlafon plafon = new(200.00m, new ComisionProcent(20));
            vanzare.SchimbaComision(plafon);
            Console.WriteLine(plafon.Nume + ": " + vanzare.Comision());

            ComisionCuBonus bonus = new(50.00m, plafon);
            vanzare.SchimbaComision(bonus);
            Console.WriteLine(bonus.Nume + ": " + vanzare.Comision());
        }
    }
}
