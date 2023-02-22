namespace WEB_Asystent.Models
{
    public class UserModel
    {
        public string nazwisko { get; set; }
        public string imie { get; set; }
        public int id { get; set; }

        public IList<ZakladkaModel> zakladki { get; set; }

        public ZakladkaModel zakladkiselected { get; set; }
        public BlokModel datablokukliknietego { get; set; }
        public FormModel formblok { get; set; }
        public UserModel() { }
        public UserModel(User _user)
        {

            imie = _user.Imie;
            nazwisko = _user.Nazwisko;
            id = _user.UserID;

            List<ZakladkaModel> listaZakladek = new List<ZakladkaModel>();



            foreach (var model in _user.ListyZakladek)
            {
                listaZakladek.Add(new ZakladkaModel(model)); // dodanie zakladki do listy
                                                             //  model.Blok
            }
            zakladki = listaZakladek;

            zakladkiselected = listaZakladek[0];
            zakladkiselected.color = "#ffffff";

        }
    }
}
