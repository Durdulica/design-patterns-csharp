namespace DesignPatterns.ex6.Models
{
    public class Vanzare
    {
        private IComision strategie;
        public decimal ValoareVanzare {  get; private set; }

        public Vanzare(decimal valoareVanzare, IComision strategie)
        {
            if (strategie == null)
            {
                throw new ArgumentNullException(nameof(strategie));
            }
            ValoareVanzare = valoareVanzare;
            this.strategie = strategie;
        }

        public void SchimbaComision(IComision nou)
        {
            if (nou == null)
            {
                throw new ArgumentNullException(nameof(nou));
            }
            strategie = nou;
        }

        public decimal Comision()
        {
            return strategie.Calculeaza(ValoareVanzare);
        }
    }
}
