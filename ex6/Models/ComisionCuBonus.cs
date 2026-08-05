namespace DesignPatterns.ex6.Models
{
    public class ComisionCuBonus : IComision
    {
        private IComision strategie;
        public string Nume { get; } = "Cu bonus";
        public decimal Comision { get; private set; }

        public ComisionCuBonus(decimal valFixa, IComision strategie)
        {
            Comision = valFixa;
            this.strategie = strategie;
        }

        public decimal Calculeaza(decimal valoareVanzare)
        {
            return strategie.Calculeaza(valoareVanzare) + Comision;
        }
    }
}
