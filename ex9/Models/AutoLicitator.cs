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
            if(pretCurent <= pretMaxim && ultimPret != pretCurent)
            {
                if(pretCurent + 10 > pretMaxim) 
                {
                    ultimPret = pretMaxim;
                    Licitatie.Liciteaza(pretMaxim);
                }
                else
                {
                    ultimPret = pretCurent + 10;
                    Licitatie.Liciteaza(pretCurent + 10);
                }
            }
        }
    }
}
