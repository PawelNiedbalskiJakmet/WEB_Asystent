namespace WEB_Asystent.Models
{
    public class ModelInKonfigBud
    {
        //   public double X { get; set; }
        //   public double Y { get; set; }
        public UserModel user { get; set; }
        public ZakladkaModel zakladkaselected { get; set; }
        public IList<ZakladkaModel> zakladki { get; set; }
        public IList<BlokModel> bloki { get; set; }
        public ModelInKonfigBud(User _user)
        {
            List<ZakladkaModel> listaZakladek = new List<ZakladkaModel>();
            List<BlokModel> listaBlokow = new List<BlokModel>();
            user = new UserModel(_user);

            foreach (var model in _user.ListyZakladek)
            {
                listaZakladek.Add(new ZakladkaModel(model)); // dodanie zakladki do listy
                                                             //  model.Blok
            }
            zakladki = listaZakladek;

            foreach (var model in _user.ListyZakladek[0].Blok.ZrobListeDown())
            {
                listaBlokow.Add(new BlokModel(model)); // dodanie zakladki do listy

            }
            bloki = listaBlokow;

            zakladkaselected = listaZakladek[0];
        }

    }
}
