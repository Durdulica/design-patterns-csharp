namespace DesignPatterns.ex10.Models
{
    public class FabricaStudent : IFabricaUtilizator
    {
        public string Tip => "STUDENT";

        public Utilizator Creeaza(string[] campuri)
        {
            throw new NotImplementedException();
        }
    }
}
