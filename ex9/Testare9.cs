using DesignPatterns.ex9.Models;

namespace DesignPatterns.ex9
{
    public class Testare9
    {
        public Testare9() 
        {
            AutoLicitator auto1 = new(100);
            AutoLicitator auto2 = new(150);
            IParticipant[] participanti = [
                new Spectator(),
                auto1,
                auto2
                ];

            Licitatie licitatie = new(10,participanti);
            auto1.Licitatie = licitatie;
            auto2.Licitatie = licitatie;

            licitatie.Liciteaza(15);
        }
    }
}
