namespace  WEB_Asystent.KlasyProgramu
{
    internal class Wiazanie
    {
        double odlegloscOdGory;
        IPoprzeczka meskaStrona;
        PoprzeczkaStrona zenskaStrona;
        public Wiazanie(PoprzeczkaStrona zenskaStrona, double odlegloscOdGory)
        {
            this.zenskaStrona = zenskaStrona;
            this.odlegloscOdGory = odlegloscOdGory;
        }
        public Wiazanie(IPoprzeczka meskaStrona)
        {
            this.meskaStrona = meskaStrona;
        }
        public void PowiazZmeskaStrona(IPoprzeczka _poprzeczka)
        {
            meskaStrona = _poprzeczka;
        }
        public void PowiazZzenskaStrona(PoprzeczkaStrona _stronaPoprzeczki)
        {
            zenskaStrona = _stronaPoprzeczki;
        }
        public double GetOdlegloscOdGory()
        {
            return odlegloscOdGory;
        }
        public IPoprzeczka GetMeskaStrona()
        {
            return meskaStrona;
        }
        public PoprzeczkaStrona GetZenskaStrona()
        {
            return zenskaStrona;
        }
    }
}
