namespace DesignPatterns.ex2.Models
{
    public class Comanda
    {
        public string Stare { get; private set; }

        private IObservator[] observatori;

        public Comanda(IObservator[] observatori)
        {
            Stare = "Plasata";
            this.observatori = observatori;
        }

        public void SchimbaStare(string stareNoua)
        {
            throw new NotImplementedException();
        }
    }
}
