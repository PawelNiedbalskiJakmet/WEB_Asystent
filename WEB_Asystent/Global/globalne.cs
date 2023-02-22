using WEB_Asystent.KlasyProgramu;

namespace WEB_Asystent.Global
{
    public static class globalne
    {
        public static List<User> Uzytkownicy = new List<User>();
        public static void OdczytanieUzytkownikow()
        {
            Uzytkownicy = new List<User>();
            var _user = new User();
            _user.Imie = "Pawel";
            _user.Nazwisko = "Niedbalski";
            _user.UserID = 1;

            _user.DodajZakladke("wom");
            _user.DodajZakladke("pom");

          //  _user.Blok = new Blok(_user);
            Uzytkownicy.Add(_user);
        }

    }
}
