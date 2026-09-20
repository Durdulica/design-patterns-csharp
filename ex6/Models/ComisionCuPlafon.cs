namespace DesignPatterns.ex6.Models
{
    public class ComisionCuPlafon : IComision
    {
        private IComision strategie;
        public decimal ComisionMax { get; private set; }

        public ComisionCuPlafon(decimal comisionMax, IComision strategie)
        {
            if (strategie == null)
            {
                throw new ArgumentNullException(nameof(strategie));
            }

            if (comisionMax < 0)
            {
                throw new ArgumentException("The maximum commission must be positive");
            }
            ComisionMax = comisionMax;
            this.strategie = strategie;
        }

        public string Nume => strategie.Nume + " + cu plafon";

        public decimal Calculeaza(decimal valoareVanzare)
        {
            return decimal.Min(strategie.Calculeaza(valoareVanzare), ComisionMax);
        }
    }
}
