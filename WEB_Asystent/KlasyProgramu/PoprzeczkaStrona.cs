namespace WEB_Asystent.KlasyProgramu
{
    internal class PoprzeczkaStrona
    {
        // string Strona;
        List<Wiazanie> wiazania;
        IPoprzeczka parent;
        public PoprzeczkaStrona(IPoprzeczka parent)
        {
            this.parent = parent;
            //   this.wiazania = _wiazania;
        }
        public void DodajWiazania(List<Wiazanie> _wiazania)
        {
            this.wiazania = _wiazania;
        }
    }
}
