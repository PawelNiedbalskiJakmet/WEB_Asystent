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

            _user.DodajZakladke("wom-numer");
            _user.DodajZakladke("pom-numer");

            //  _user.Blok = new Blok(_user);
            Uzytkownicy.Add(_user);

            var _user2 = new User();
            _user2.Imie = "Pawel2";
            _user2.Nazwisko = "Niedbalski2";
            _user2.UserID = 2;

            _user2.DodajZakladke("wom-numer2");
            _user2.DodajZakladke("pom-numer2");

            //  _user.Blok = new Blok(_user);
            Uzytkownicy.Add(_user2);
        }

    }
}
