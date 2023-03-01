using WEB_Asystent.KlasyProgramu;

namespace WEB_Asystent.Models
{
    public class BlokModel
    {
        public double x_display { get; set; }
        public double y_display { get; set; }
        public double width_display { get; set; }
        public double height_display { get; set; }

        public double width_zew { get; set; }
        public double height_zew { get; set; }

        public double width_wew { get; set; }
        public double height_wew { get; set; }

        public string bg_color { get; set; }
        public int id { get; set; }

        public int czyrealny { get; set; }
        public bool wprowadzonowymiar { get; set; }

        public bool zablokowanaszerokosc { get; set; }
        public bool zablokowanawysokosc { get; set; }

        public bool wprowadzonoblokadewysokosci  { get; set; }
        public bool wprowadzonoblokadeszerokosci { get; set; }

        public int blokujeszerokosc { get; set  ; }
        public int blokujewysokosc { get; set; }

        public bool oznaczone { get; set; }



        public BlokModel()
        {
            x_display = 0;
            y_display = 0;
            width_display = 100;
            height_display = 100;
            bg_color = "white";
            id = 1;
            czyrealny = 0;
            wprowadzonowymiar = false;
            zablokowanaszerokosc = false;
            zablokowanawysokosc = false;

        }

        /// <param name="_blok">obiekt typu blok konwertowany na model</param>
        public BlokModel(Blok _blok)
        {
            x_display = _blok.X;
            y_display = _blok.Y;
            width_display = _blok.Szerokosc;
            height_display = _blok.Wysokosc;
            width_wew = _blok.SzerokoscWew;
            height_wew = _blok.WysokoscWew;
            width_zew = _blok.SzerokoscZew;
            height_zew = _blok.WysokoscZew;
            wprowadzonowymiar = _blok.WskaznikUstawieniaWymiaruPrzezUzytkownika;

            if (_blok.BlokiWewnetrzne.Count > 0)
            {
                czyrealny = 0;
            }
            else
            {
                czyrealny = 1;
            }


            zablokowanaszerokosc = _blok.zablokowanaSzerokosc;
            zablokowanawysokosc = _blok.zablokowanaWysokosc;
            bg_color = "white";
            id = _blok.ID;

            if(_blok==_blok.BlokujeSzerokosc)
            {
                wprowadzonoblokadeszerokosci = true;
            }
            else
            {
                wprowadzonoblokadeszerokosci = false;
            }

            if (_blok == _blok.BlokujeWysokosc)
            {
                wprowadzonoblokadewysokosci = true;
            }
            else
            {
                wprowadzonoblokadewysokosci = false;
            }
            if (_blok.BlokujeSzerokosc != null)
            {
                blokujeszerokosc = _blok.BlokujeSzerokosc.ID;
            }
            else
            {
                blokujeszerokosc = -1;
            }
            if (_blok.BlokujeWysokosc != null)
            {
                blokujewysokosc = _blok.BlokujeWysokosc.ID;
            }
            else
            {
                blokujewysokosc = -1;
            }


        }




    }
}
