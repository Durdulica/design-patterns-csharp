namespace DesignPatterns.ex10.Models
{
    public class FabricaProfesor : IFabricaUtilizator
    {
        public string Tip => "PROFESOR";

        public Utilizator Creeaza(string[] campuri)
        {
            return new Profesor(campuri[1], campuri[2], campuri[3]);
        }
    }
}
