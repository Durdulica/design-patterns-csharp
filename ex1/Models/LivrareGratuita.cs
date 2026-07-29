namespace DesignPatterns.ex1.Models
{
    public class LivrareGratuita : ILivrareStrategie
    {
        public string Nume => "Gratuita";

        public decimal CalculeazaCost(decimal greutateKg, decimal distantaKm)
        {
            return 0;
        }
    }
}
