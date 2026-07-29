namespace DesignPatterns.ex1.Models
{
    public class LivrareCuReducere : ILivrareStrategie
    {
        public string Nume => "Reducere";
        public decimal Procent { get; }

        private ILivrareStrategie strategie;

        public LivrareCuReducere(decimal procent, ILivrareStrategie strategie)
        {
            if(procent < 0 || procent > 100)
            {
                throw new ArgumentOutOfRangeException("Discount percent must be between 0 and 100");
            }

            Procent = procent;
            this.strategie = strategie;
        }

        public decimal CalculeazaCost(decimal greutateKg, decimal distantaKm)
        {
            decimal costInitial = strategie.CalculeazaCost(greutateKg, distantaKm);
            return costInitial - costInitial * Procent / 100;
        }
    }
}