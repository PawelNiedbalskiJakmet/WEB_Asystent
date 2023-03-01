using Microsoft.AspNetCore.Mvc;
using WEB_Asystent.Models;
using static WEB_Asystent.Models.ZakladkaModel;
//using System.Web.Mvc;

namespace WEB_Asystent.Controllers
{
    public class konfigBudowaController : Controller
    {
        // GET: konfigBudowaController
        //   static  Blok Podstawa=new Blok();
        public ActionResult Index()
        {
            var obiekt = new UserModel(globalne.Uzytkownicy[0]);

            return View(obiekt);
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
        public JsonResult PostUpdateWymiaryCalosci(UserModel data) // odczytanie danych dla danego Usera
        {
            wymiary doReturn;//
            if (data != null)
            {

                var zakladka = globalne.Uzytkownicy.Find(x => x.UserID == data.id).ListyZakladek.Find(y => y.ZakladkaID == data.zakladkiselected.id);


                zakladka.szerokosc = data.zakladkiselected.calosc.szerokosc;
                zakladka.wysokosc = data.zakladkiselected.calosc.wysokosc;
                zakladka.glebokosc = data.zakladkiselected.calosc.glebokosc;

                zakladka.Blok.SzerokoscZew = zakladka.szerokosc;
                zakladka.Blok.WysokoscZew = zakladka.wysokosc;

                doReturn = new wymiary(zakladka.szerokosc, zakladka.wysokosc, zakladka.glebokosc);



            }
            else
            {
                doReturn = new wymiary();
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


    }
}
