namespace DesignPatterns.ex10.Models
{
    public class FabricaAdmin : IFabricaUtilizator
    {
        public string Tip => "ADMIN";

        public Utilizator Creeaza(string[] campuri)
        {
            return new Admin(campuri[1], campuri[2], Int32.Parse(campuri[3]));
        }
    }
}
