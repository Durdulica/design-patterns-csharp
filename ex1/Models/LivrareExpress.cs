namespace DesignPatterns.ex1.Models
{
    public class LivrareExpress : ILivrareStrategie
    {
        public string Nume => "Express";

        public decimal CalculeazaCost(decimal greutateKg, decimal distantaKm)
        {
            return 12 + 1.0m * greutateKg + 0.25m * distantaKm;
        }
    }
}
