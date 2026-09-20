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
            Utilizator[] utilizatori = new Utilizator[linii.Length];

            for(int i = 0; i < linii.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(linii[i])) continue;

                string[] campuri = linii[i].Split(',');
                string tip = campuri[0].Trim();

                for (int j = 0; j < fabrici.Length; j++) 
                {
                    if (fabrici[j].Tip == tip) 
                    {
                        utilizatori[i] = fabrici[j].Creeaza(campuri);
                    }
                }

                if (utilizatori[i] == null)
                {
                    throw new FormatException($"Unknown user type: '{tip}'");
                }
            }

            return utilizatori;
        }
    }
}
