using DesignPatterns.ex11.Models;

namespace DesignPatterns.ex11
{
    public class Testare11
    {
        public Testare11()
        {
            string mesaj = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." +
                " Lorem Ipsum has been the industry's standard dummy text ever test test test test test test test";
            NotificatorEmail email = new NotificatorEmail();
            email.Trimite(mesaj);

            CuPrefix prefix = new CuPrefix("[URGENT] ", email);
            prefix.Trimite(mesaj);

            try
            {
                new NotificatorSms().Trimite(mesaj);
            }
            catch (ArgumentException ex) 
            {
                Console.WriteLine(ex.Message);
            }

            CuTrunchiere trunchi = new CuTrunchiere(160, new NotificatorSms());
            trunchi.Trimite(mesaj);

            new CuJurnal(trunchi).Trimite(mesaj);
            new CuTrunchiere(160, new CuJurnal(new NotificatorSms())).Trimite(mesaj);
        }
    }
}
