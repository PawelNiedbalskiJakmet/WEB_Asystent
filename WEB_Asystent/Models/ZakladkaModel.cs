using WEB_Asystent.Global;
using WEB_Asystent.KlasyProgramu;

namespace WEB_Asystent.Models
{
    public class ZakladkaModel
    {
        public string nazwa { get; set; }
        public int id { get; set; }
        public string color { get; set; }

        public class wymiary
        {
            public double szerokosc { get; set; }
            public double wysokosc { get; set; }
            public double glebokosc { get; set; }

            public wymiary()
            {

            }
            public wymiary(double _szerokosc, double _wysokosc, double _glebokosc)
            {
                this.szerokosc = _szerokosc;
                this.wysokosc = _wysokosc;
                this.glebokosc = _glebokosc;
            }
        }

        public wymiary calosc { get; set; }

        public IList<BlokModel> bloki { get; set; }

        //    public UserModel user { get; set; }
        public ZakladkaModel()
        {

            nazwa = "";
            id = 1;
            color = "#d1edff";
        }
        public ZakladkaModel(Zakladki _zakladka)
        {
            List<BlokModel> listaBlokow = new List<BlokModel>();

            calosc = new wymiary(_zakladka.szerokosc, _zakladka.wysokosc, _zakladka.glebokosc);

            foreach (var model in _zakladka.Blok.ZrobListeDown())
            {
                listaBlokow.Add(new BlokModel(model)); // dodanie zakladki do listy

            }
            bloki = listaBlokow;

            nazwa = _zakladka.Nazwa;
            id = _zakladka.ZakladkaID;
            color = "#d1edff";

        }
    }
}
