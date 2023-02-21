namespace WEB_Asystent.KlasyProgramu
{
    internal class PoprzeczkaWewHoryzontalna : IPoprzeczka
    {
        double dlugosc;
        double szerokosc;
        Wiazanie meska1;
        Wiazanie meska2;
        string ID;
        PoprzeczkaStrona PoprzeczkaDol;
        PoprzeczkaStrona PoprzeczkaGora;

        public PoprzeczkaWewHoryzontalna(string iD, Wiazanie pierwszyKoniec, Wiazanie drugiKoniec)
        {
            szerokosc = 20;
            ID = iD;
            meska1 = pierwszyKoniec;
            meska2 = drugiKoniec;
            PoprzeczkaDol = new PoprzeczkaStrona(this); // dol;
            PoprzeczkaGora = new PoprzeczkaStrona(this); //gora
        }


        public double ZwrocDlugosc()
        {
            //throw new NotImplementedException();
            return dlugosc;
        }

        public PoprzeczkaStrona ZwrocLewy()
        {
            return PoprzeczkaDol;
        }

        public PoprzeczkaStrona ZwrocPrawy()
        {
            return PoprzeczkaGora;
        }

        public double ZwrocSzerokosc()
        {
            return szerokosc;
        }
        public Wiazanie ZwrocWiazanie1()
        {
            return meska1;
        }
        public Wiazanie ZwrocWiazanie2()
        {
            return meska2;
        }
    }
}
