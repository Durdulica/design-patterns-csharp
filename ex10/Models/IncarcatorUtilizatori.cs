namespace DesignPatterns.ex10.Models
{
    public class IncarcatorUtilizatori
    {
        private IFabricaUtilizator[] fabrici;

        public IncarcatorUtilizatori(IFabricaUtilizator[] fabrici)
        {
            if (fabrici == null || fabrici.Length == 0)
            {
                throw new ArgumentException("At least one factory is required");
            }

            this.fabrici = fabrici;
        }

        public Utilizator[] Incarca(string[] linii)
        {
            throw new NotImplementedException();
        }
    }
}
