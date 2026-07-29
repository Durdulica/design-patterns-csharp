namespace DesignPatterns.ex1.Models
{
    public interface ILivrareStrategie
    {
        string Nume { get; }
        decimal CalculeazaCost(decimal greutateKg, decimal distantaKm);
    }
}
