namespace WEB_Asystent.Global
{
    public class User
    {
        public User()
        {
            ListyZakladek = new List<Zakladki>();
        }
        public void DodajZakladke(string _nazwa)
        {
            ListyZakladek.Add(new Zakladki(_nazwa, this));
        }
        public List<Zakladki> ListyZakladek
        { get; set; }
        // public Blok Blok { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int UserID { get; set; }
    }
}
