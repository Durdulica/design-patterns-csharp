namespace DesignPatterns.ex3.Models
{
    public class Raport
    {
        private IExportStrategie strategie;
        public string[] Date { get; }

        public Raport(string[] date, IExportStrategie strategie)
        {
            if(date == null)
            {
                throw new ArgumentNullException("date");
            }

            Date = date;
            this.strategie = strategie;
        }

        public void SchimbaStrategie(IExportStrategie noua)
        {
            strategie = noua;
        }

        public string Exporta()
        {
            return strategie.Formateaza(Date);
        }
    }
}