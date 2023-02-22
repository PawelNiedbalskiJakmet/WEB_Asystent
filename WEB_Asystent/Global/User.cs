using WEB_Asystent.KlasyProgramu;
namespace WEB_Asystent.Global
{
    public class User
    {
        public User()
        {
            CNT = 0;
        }
        public Blok Blok { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int UserID { get; set; }
        public int CNT { get; set; }
    }
}
