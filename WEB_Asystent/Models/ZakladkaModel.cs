using WEB_Asystent.Global;
using WEB_Asystent.KlasyProgramu;

namespace WEB_Asystent.Models
{
    public class ZakladkaModel
    {
        public string Nazwa { get; set; }
        public int ID { get; set; }
        public int UserID { get; set; }
        public string color { get; set; }
       public  ZakladkaModel() { }
        public ZakladkaModel(Zakladki _zakladka)
        {

            UserID = _zakladka.UserID;
            Nazwa = _zakladka.Nazwa;
            ID = _zakladka.ZakladkaID;
            color = "#d1edff";

        }
    }
}
