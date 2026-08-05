namespace DesignPatterns.ex3.Models
{
    public class Raport
    {
        private IExportStrategie strategie;
        private string[] Date { get; }
        public string NumeFormat => strategie.Nume;

        public Raport(string[] date, IExportStrategie strategie)
        {
            if(date == null)
            {
                throw new ArgumentNullException("date");
            }

            Date = date;
            this.strategie = strategie;
        }

        public void SchimbaFormat(IExportStrategie noua)
        {
            strategie = noua;
        }

        public string Genereaza()
        {
            return strategie.Formateaza(Date);
        }
    }
}