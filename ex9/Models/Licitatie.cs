namespace DesignPatterns.ex9.Models
{
    public class Licitatie
    {
        private readonly IParticipant[] participanti;
        private bool difuzez;
        private decimal ofertaInAsteptare;
        private bool areOfertaInAsteptare;

        public decimal PretCurent {  get; private set; }

        public Licitatie(decimal pret, IParticipant[] participanti)
        {
            ArgumentNullException.ThrowIfNull(participanti);

            if (pret <= PretCurent)
            {
                throw new ArgumentException("The sum is lesser or equal to the current auction bid");
            }

            if (difuzez)
            {
                ofertaInAsteptare = pret;
                areOfertaInAsteptare = true;
                return;
            }

            difuzez = true;
            PretCurent = pret;
            this.participanti = participanti;

            do
            {
                areOfertaInAsteptare = false;
                for (int i = 0; i < participanti.Length; i++)
                {
                    participanti[i].OfertaNoua(PretCurent);
                }

                if (areOfertaInAsteptare)
                {
                    PretCurent = ofertaInAsteptare;
                }
            } while (areOfertaInAsteptare);

            difuzez = false;
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
