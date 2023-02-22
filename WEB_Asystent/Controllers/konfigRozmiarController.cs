using Microsoft.AspNetCore.Mvc;
using WEB_Asystent.Models;

namespace WEB_Asystent.Controllers
{
    public class konfigRozmiarController : Controller
    {
        public ActionResult Index()
        {
            var obiekt = new UserModel(globalne.Uzytkownicy[0]);

            return View(obiekt);
        }

        // GET: konfigBudowaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: konfigBudowaController/Create
        public ActionResult Create()
        {
            return View();
        }
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
        public JsonResult PostDodajBloki(UserModel data) // dodanie nowego bloku do zakladki do uzytkownika
        {
            var listaModeli = new List<BlokModel>();
            // test here!
            if (data != null)
            {
                //data.UserID= data.UserID;
                var podstawa = globalne.Uzytkownicy.Find(x => x.UserID == data.id).ListyZakladek.Find(y => y.ZakladkaID == data.zakladkiselected.id).Blok;

                var wyszukany = podstawa.Przeszukaj(data.datablokukliknietego.id);
                wyszukany.dodajBloki(data.formblok.n, data.formblok.orientacja);

                wyszukany.ZmienSzerokosc(data.formblok.szerokosc);

                wyszukany.ZmienWysokosc(data.formblok.wysokosc);

                var obiektowa = podstawa.ZrobListeDown();


                foreach (var obiekt in obiektowa)
                {
                    var modelObiekt = new BlokModel(obiekt);
                }

                //  JsonConvert.SerializeObject(products, Formatting.Indented);
            }



            var doReturn = (IEnumerable<BlokModel>)listaModeli;

            return Json(doReturn);
        }
    }
}
