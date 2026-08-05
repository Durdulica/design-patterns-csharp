namespace DesignPatterns.ex6.Models
{
    public class ComisionCuBonus : IComision
    {
        private IComision strategie;
        public string Nume { get; } = "Cu bonus";
        public decimal Bonus { get; private set; }

        public ComisionCuBonus(decimal valFixa, IComision strategie)
        {
            if(strategie == null)
            {
                throw new ArgumentNullException(nameof(strategie));
            }

            Bonus = valFixa;
            this.strategie = strategie;
        }

        public decimal Calculeaza(decimal valoareVanzare)
        {
            return strategie.Calculeaza(valoareVanzare) + Bonus;
        }
    }
}
