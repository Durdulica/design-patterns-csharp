namespace DesignPatterns.ex6.Models
{
    public class Vanzare
    {
        private IComision strategie;
        public decimal ValoareVanzare {  get; private set; }

        public Vanzare(decimal valoareVanzare, IComision strategie)
        {
            ValoareVanzare = valoareVanzare;
            this.strategie = strategie;
        }

        public void SchimbaComision(IComision nou)
        {
            strategie = nou;
        }

        public decimal Comision()
        {
            return strategie.Calculeaza(ValoareVanzare);
        }
    }
}
