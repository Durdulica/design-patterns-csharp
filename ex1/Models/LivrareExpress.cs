namespace DesignPatterns.ex1.Models
{
    public class LivrareExpress : ILivrareStrategie
    {
        public string Nume => "Express";

        public decimal CalculeazaCost(decimal greutateKg, decimal distantaKm)
        {
            return 12 + (decimal)1.0 * greutateKg + (decimal)0.25 * distantaKm;
        }
    }
}
