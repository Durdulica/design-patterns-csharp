namespace DesignPatterns.ex9.Models
{
    public class Licitatie
    {
        private readonly IParticipant[] participanti;

        public decimal PretCurent {  get; private set; }

        public Licitatie(decimal pret, IParticipant[] participanti)
        {
            ArgumentNullException.ThrowIfNull(participanti);

            PretCurent = pret;
            this.participanti = participanti;

            /*for(int i = 0; i < participanti.Length; i++)
            {
                var test = participanti[i] as AutoLicitator; // ???
                test.Licitatie = this;
            }*/
        }

        public void Liciteaza(decimal suma)
        {
            if(suma <= PretCurent)
            {
                throw new ArgumentException("The sum is lesser or equal to the current action bid");
            }

            PretCurent = suma;
            for(int i = 0; i < participanti.Length; i++)
            {
                participanti[i].OfertaNoua(suma);
            }
        }
    }
}
