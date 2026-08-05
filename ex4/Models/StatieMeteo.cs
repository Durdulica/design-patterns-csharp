namespace DesignPatterns.ex4.Models
{
    public class StatieMeteo
    {
        private IAfisaj[] afisaje;
        public decimal Temperatura { get; private set; }

        public StatieMeteo(IAfisaj[] afisaje)
        {
            this.afisaje = afisaje;
        }

        public void SeteazaTemperatura(decimal stareNoua)
        {
            Temperatura = stareNoua;
            for (int i = 0; i < afisaje.Length; i++) 
            {
                afisaje[i].Actualizeaza(Temperatura);
            }
        }
    }
}
