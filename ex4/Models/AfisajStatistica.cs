namespace DesignPatterns.ex4.Models
{
    public class AfisajStatistica : IAfisaj
    {
        private decimal minim = decimal.MaxValue;
        private decimal maxim = decimal.MinValue;
        private decimal numar = 0;
        private decimal suma = 0;
        public void Actualizeaza(decimal temperatura)
        {
            if (temperatura < minim)
            {
                minim = temperatura;
            }

            if (temperatura > maxim) 
            {
                maxim = temperatura;
            }

            suma += temperatura;
            numar++;
            
            Console.WriteLine("[STATISTICA] Min: " + minim + "| Max: " + maxim + "| Media: " + (suma / numar));
        }
    }
}