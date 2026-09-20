namespace DesignPatterns.ex10.Models
{
    public class FabricaStudent : IFabricaUtilizator
    {
        public string Tip => "STUDENT";

        public Utilizator Creeaza(string[] campuri)
        {
            return new Student(campuri[1], campuri[2], campuri[3]);
        }
    }
}
