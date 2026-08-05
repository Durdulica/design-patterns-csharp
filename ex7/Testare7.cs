using DesignPatterns.ex7.Models;

namespace DesignPatterns.ex7
{
    public class Testare7
    {
        public Testare7()
        {
            AbonatPush push = new();
            IAbonat[] abonati =
            [
                new AbonatEmail(),
                push
            ];

            Canal canal = new(abonati);

            canal.PublicaVideo("testare observer pattern");
            canal.Dezaboneaza(push);

            Console.WriteLine();
            canal.PublicaVideo("test2");
        }
    }
}
