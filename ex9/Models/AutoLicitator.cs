namespace DesignPatterns.ex9.Models
{
    public class AutoLicitator : IParticipant
    {
        private readonly decimal pretMaxim;
        public Licitatie Licitatie { get; set; }
        private decimal ultimPret = 0;

        public AutoLicitator(decimal pretMaxim) 
        {
            this.pretMaxim = pretMaxim;
        }

        public void OfertaNoua(decimal pretCurent)
        {
            if (pretCurent != Licitatie.PretCurent) return;
            if (ultimPret == pretCurent) return;
            if(pretCurent >= pretMaxim) return;

            ultimPret = Math.Min(pretMaxim, pretCurent + 10);
            Licitatie.Liciteaza(ultimPret);
        }
    }
}
