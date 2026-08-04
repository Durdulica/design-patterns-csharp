namespace DesignPatterns.ex4.Models
{
    public class AfisajAlerta : IAfisaj
    {
        public void Actualizeaza(decimal temperatura)
        {
            if (temperatura > 30)
            {
                Console.WriteLine("[ALERTA] Temperatura ridicata: " + temperatura);
            }
            else
            {
                Console.WriteLine("[ALERTA] OK");
            }
        }
    }
}