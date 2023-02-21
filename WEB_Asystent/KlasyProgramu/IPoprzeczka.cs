namespace WEB_Asystent.KlasyProgramu
{
    internal interface IPoprzeczka
    {

        double ZwrocDlugosc();
        double ZwrocSzerokosc();
        PoprzeczkaStrona ZwrocLewy();
        PoprzeczkaStrona ZwrocPrawy();

        Wiazanie ZwrocWiazanie1();
        Wiazanie ZwrocWiazanie2();

    }
}
