namespace DesignPatterns.ex5.Models
{
    public class CampParola
    {
        private IPoliticaParola politica;

        public CampParola(IPoliticaParola politica)
        {
            if (politica == null)
            {
                throw new ArgumentNullException(nameof(politica));
            }
            this.politica = politica;
        }

        public void SchimbaPolitica(IPoliticaParola noua)
        {
            if(noua == null)
            {
                throw new ArgumentNullException(nameof(noua));
            }
            politica = noua;
        }

        public bool Verifica(string parola)
        {
            return politica.EsteValida(parola);
        }
    }
}