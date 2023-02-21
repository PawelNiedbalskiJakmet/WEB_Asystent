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



        /// <param name="_blok">obiekt typu blok konwertowany na model</param>
        public KonfigBudowa konwertujNaModel(Blok _blok)
        {
            var ob_modelu = new KonfigBudowa();

            ob_modelu.ID = _blok.ID;
            ob_modelu.orientacja = _blok.Ustawienie;
            ob_modelu.X = _blok.X;
            ob_modelu.Y = _blok.Y;
            ob_modelu.Width = _blok.Szerokosc;
            ob_modelu.Height = _blok.Wysokosc;
            return ob_modelu;
        }



    }
}
