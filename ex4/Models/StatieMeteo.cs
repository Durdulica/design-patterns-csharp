namespace DesignPatterns.ex4.Models
{
    public class StatieMeteo
    {
        private IAfisaj[] observatori;
        public decimal Stare { get; private set; }

        public StatieMeteo(IAfisaj[] observatori)
        {
            this.observatori = observatori;
        }

        public void SchimbaStare(decimal stareNoua)
        {
            Stare = stareNoua;
            for (int i = 0; i < observatori.Length; i++) 
            {
                observatori[i].Actualizeaza(Stare);
            }
        }
    }
}
