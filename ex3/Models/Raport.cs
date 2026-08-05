namespace DesignPatterns.ex3.Models
{
    public class Raport
    {
        private IExportStrategie strategie;
        private readonly string[] date;
        public string NumeFormat => strategie.Nume;

        public Raport(string[] date, IExportStrategie strategie)
        {
            if(date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }
            if(strategie == null)
            {
                throw new ArgumentNullException(nameof(strategie), "The export type cannot be null");
            }

            this.date = date;
            this.strategie = strategie;
        }

        public void SchimbaFormat(IExportStrategie noua)
        {
            if(noua == null)
            {
                throw new ArgumentNullException(nameof(noua),"The new export type cannot be null");
            }
            strategie = noua;
        }

        public string Genereaza()
        {
            return strategie.Formateaza(date);
        }
    }
}