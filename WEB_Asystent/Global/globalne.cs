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
            _user.ListyZakladek[0].Blok.dodajBloki(5, "PION");
            _user.ListyZakladek[0].Blok.BlokiWewnetrzne[0].dodajBloki(5, "POZ");
            _user.ListyZakladek[0].Blok.BlokiWewnetrzne[0].BlokiWewnetrzne[0].dodajBloki(2, "PION");
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
