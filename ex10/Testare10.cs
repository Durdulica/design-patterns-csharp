using DesignPatterns.ex10.Models;

namespace DesignPatterns.ex10
{
    public class Testare10
    {
        public Testare10()
        {
            string[] linii = { "STUDENT,Ana,Popescu,anul 2",
                               "PROFESOR,Ion,Ionescu,Matematica",
                               "STUDENT,Vald,Marin,anul 1",
                               "ADMIN, Stefan, Scarlat, 10000"};

            IFabricaUtilizator[] fabrici= { new FabricaStudent(), new FabricaProfesor(), new FabricaAdmin() };

            IncarcatorUtilizatori incarcatorUtilizatori = new IncarcatorUtilizatori(fabrici);

            Utilizator[] utilizatori = incarcatorUtilizatori.Incarca(linii);

            for (int i = 0; i < utilizatori.Length; i++) 
            {
                Console.WriteLine(utilizatori[i].Descriere());
            }
        }
    }
}
