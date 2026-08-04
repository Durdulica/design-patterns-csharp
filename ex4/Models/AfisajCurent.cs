namespace DesignPatterns.ex4.Models
{
    public class AfisajCurent : IAfisaj
    {
        public void Actualizeaza(decimal temperatura)
        {
            Console.WriteLine("[CURENT] Acum: " + temperatura);
        }
    }
}