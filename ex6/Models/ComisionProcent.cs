namespace DesignPatterns.ex6.Models
{
    public class ComisionProcent : IComision
    {
        public decimal Procent { get; private set; }
        public string Nume { get; } = "Procent";

        public ComisionProcent(decimal procent)
        {
            if (procent < 0 || procent > 100)
            {
                throw new ArgumentException("Procent value must be between 0 and 100");
            }
            this.Procent = procent;
        }

        public decimal Calculeaza(decimal valoareVanzare)
        {
            return Procent/100 * valoareVanzare;
        }
    }
}
