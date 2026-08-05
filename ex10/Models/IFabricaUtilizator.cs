namespace DesignPatterns.ex10.Models
{
    public interface IFabricaUtilizator
    {
        string Tip { get; }
        Utilizator Creeaza(string[] campuri);
    }
}
