namespace DesignPatterns.ex6.Models
{
    public class ComisionFix : IComision
    {
        public decimal Comision { get; private set; }
        public string Nume { get; } = "Fix";

        public ComisionFix(decimal comision)
        {
            if (comision < 0) 
            {
                throw new ArgumentException("The commission cannot be negative");
            }
            Comision = comision;
        }

        public decimal Calculeaza(decimal valoareVanzare)
        {
            return Comision;
        }
    }
}
