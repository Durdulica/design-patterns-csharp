namespace DesignPatterns.ex5.Models
{
    public class CampParola
    {
        private IPoliticaParola politica;

        public CampParola(IPoliticaParola politica)
        {
            this.politica = politica;
        }

        public void SchimbaPolitica(IPoliticaParola noua)
        {
            if(noua == null)
            {
                throw new ArgumentNullException("new policy");
            }
            politica = noua;
        }

        public void Verifica(string parola)
        {
            Console.WriteLine(politica.EsteValida(parola));
        }
    }
}