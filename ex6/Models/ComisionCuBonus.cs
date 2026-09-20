namespace DesignPatterns.ex6.Models
{
    public class ComisionCuBonus : IComision
    {
        private IComision strategie;
        public decimal Bonus { get; private set; }

        public ComisionCuBonus(decimal valFixa, IComision strategie)
        {
            if (strategie == null)
            {
                throw new ArgumentNullException(nameof(strategie));
            }

            if(valFixa < 0)
            {
                throw new ArgumentException("The value must be positive");
            }
            Bonus = valFixa;
            this.strategie = strategie;
        }

        public string Nume => strategie.Nume + " + cu bonus";

        public decimal Calculeaza(decimal valoareVanzare)
        {
            return strategie.Calculeaza(valoareVanzare) + Bonus;
        }
    }
}
