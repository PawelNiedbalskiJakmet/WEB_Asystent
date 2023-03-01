using Microsoft.AspNetCore.Mvc;
using WEB_Asystent.Models;

namespace WEB_Asystent.Controllers
{
    public class konfigRozmiarController : Controller
    {
        public ActionResult Index(int id)
        {
            //var obiekt = new UserModel(globalne.Uzytkownicy[0]);
            foreach (var zakladka in globalne.Uzytkownicy[id].ListyZakladek)
            {
                zakladka.Blok.UsunWiazania();
                zakladka.Blok.WstawZablokujSzerokoscDown(zakladka.szerokosc);
                zakladka.Blok.WstawZablokujWysokoscDown(zakladka.wysokosc);
                zakladka.Blok.updateXY();
            }

            var obiekt = new UserModel(globalne.Uzytkownicy[id]);
            return View(obiekt);
        }

        // GET: konfigBudowaController/Details/5

        [HttpPost]
        public JsonResult PostUpdateUser(UserModel data) // odczytanie danych dla danego Usera
        {
            UserModel doReturn;//
            if (data != null)
            {

                var podstawa = globalne.Uzytkownicy.Find(x => x.UserID == data.id);
                doReturn = new UserModel(podstawa);



            }
            else
            {
                doReturn = new UserModel();
            }
            return Json(doReturn);

        }
        [HttpPost]
        public JsonResult PostZmieniaZakladke(UserModel data) // przerzuca zakladke
        {
            var listaModeli = new List<BlokModel>();
            // test here!
            if (data != null)
            {
                //data.UserID= data.UserID;
                var podstawa = globalne.Uzytkownicy.Find(x => x.UserID == data.id).ListyZakladek.Find(y => y.ZakladkaID == data.zakladkiselected.id).Blok;

                // var wyszukany = podstawa.Przeszukaj(data.ID);
                // wyszukany.dodajBloki(data.cnt, data.orientacja);

                var obiektowa = podstawa.ZrobListeDown();


                foreach (var obiekt in obiektowa)
                {
                    var modelObiekt = new BlokModel(obiekt);
                    listaModeli.Add(modelObiekt);
                }


            }


            var doReturn = (IEnumerable<BlokModel>)listaModeli;


            return Json(doReturn);
        }
        [HttpPost]
        public JsonResult PostZmienRozmiar(UserModel data) // dodanie nowego bloku do zakladki do uzytkownika
        {
            var listaModeli = new List<BlokModel>();
            // test here!
            if (data != null)
            {
                //data.UserID= data.UserID;
                var podstawa = globalne.Uzytkownicy.Find(x => x.UserID == data.id).ListyZakladek.Find(y => y.ZakladkaID == data.zakladkiselected.id).Blok;

                var wyszukany = podstawa.Przeszukaj(data.datablokukliknietego.id);
                //   wyszukany.WskaznikUstawieniaWymiaruPrzezUzytkownika = true;
                //  wyszukany.dodajBloki(data.formblok.n, data.formblok.orientacja);
                if (data.formblok.szerokosc > 0)
                {
                    wyszukany.ZmienSzerokosc(data.formblok.szerokosc);
                }

                if (data.formblok.wysokosc > 0)
                {
                    wyszukany.ZmienWysokosc(data.formblok.wysokosc);
                }

                podstawa.updateXY();

                var obiektowa = podstawa.ZrobListeDown();


                foreach (var obiekt in obiektowa)
                {
                    var modelObiekt = new BlokModel(obiekt);
                    listaModeli.Add(modelObiekt);
                }

                //  JsonConvert.SerializeObject(products, Formatting.Indented);
            }



            var doReturn = (IEnumerable<BlokModel>)listaModeli;

            return Json(doReturn);
        }

        // GET: konfigBudowaController/Create


    }
}
