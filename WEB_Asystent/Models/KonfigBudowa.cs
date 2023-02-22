using WEB_Asystent.KlasyProgramu;

namespace WEB_Asystent.Models
{
    public class KonfigBudowa
    {
        public double y { get; set; }
        public double x { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public int cnt { get; set; }
        public string orientacja { get; set; }
        public int id { get; set; }
        public int userid { get; set; }

        public int zakladkaid { get; set; }

        public KonfigBudowa() { }

        /// <param name="_blok">obiekt typu blok konwertowany na model</param>
        public KonfigBudowa(Blok _blok)
        {


            id = _blok.ID;
            orientacja = _blok.Ustawienie;
            x = _blok.X;
            y = _blok.Y;
            width = _blok.Szerokosc;
            height = _blok.Wysokosc;
            userid = _blok.UserID;
            zakladkaid = _blok.ZakladkaID;

        }



    }
}
