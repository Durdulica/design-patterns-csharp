namespace DesignPatterns.ex10.Models
{
    public class FabricaProfesor : IFabricaUtilizator
    {
        public string Tip => "PROFESOR";

        public Utilizator Creeaza(string[] campuri)
        {
            throw new NotImplementedException();
        }
    }
}
