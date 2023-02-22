using WEB_Asystent.KlasyProgramu;

namespace WEB_Asystent.Models
{
    public class KonfigBudowa
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int cnt { get; set; }
        public string orientacja { get; set; }
        public int ID { get; set; }
        public int UserID { get; set; }

        public int ZakladkaID { get; set; }

        public KonfigBudowa() { }

        /// <param name="_blok">obiekt typu blok konwertowany na model</param>
        public KonfigBudowa(Blok _blok)
        {


            ID = _blok.ID;
            orientacja = _blok.Ustawienie;
            X = _blok.X;
            Y = _blok.Y;
            Width = _blok.Szerokosc;
            Height = _blok.Wysokosc;
            UserID = _blok.UserID;
            ZakladkaID = _blok.ZakladkaID;

        }



    }
}
