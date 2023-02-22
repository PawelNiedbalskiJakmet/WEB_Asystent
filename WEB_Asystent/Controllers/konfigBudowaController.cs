using Microsoft.AspNetCore.Mvc;
using WEB_Asystent.KlasyProgramu;
using WEB_Asystent.Models;
using WEB_Asystent.Global;
using Newtonsoft.Json;
using static System.Formats.Asn1.AsnWriter;
//using System.Web.Mvc;

namespace WEB_Asystent.Controllers
{
    public class konfigBudowaController : Controller
    {
        // GET: konfigBudowaController
   //   static  Blok Podstawa=new Blok();
        public ActionResult Index()
        {
            return View();
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
        public JsonResult PostDodajBloki(KonfigBudowa data)
        {
            var listaModeli=new List<KonfigBudowa>();
            // test here!
            if(data != null)
            {
                //data.UserID= data.UserID;
                var podstawa= globalne.Uzytkownicy.Find(x=>x.UserID==data.UserID).Blok;
                var wyszukany=podstawa.Przeszukaj(data.ID);
                wyszukany.dodajBloki(data.cnt, data.orientacja);
              
                var obiektowa= podstawa.ZrobListeDown();
               
                
                foreach(var obiekt in obiektowa)
                {
                    var modelObiekt = new KonfigBudowa(obiekt);
                    listaModeli.Add(modelObiekt);
                }

                //  JsonConvert.SerializeObject(products, Formatting.Indented);
            }

            // scop.bloki = [{ _x: 0, _y: 0, _width: 100, _height: 100, _bg_color: "white", ID: 1 }];
            //var q = Json(listaModeli, JsonRequestBehavior.AllowGet
            var doReturn = listaModeli.Select(model => new
            {
                _x = model.X,
                _y = model.Y,
                _width = model.Width,
                _height = model.Height,
                _bg_color = "white",
                ID=model.ID
            }); ;
            var q = Json(doReturn);

            return Json(doReturn);
        }

        // POST: konfigBudowaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: konfigBudowaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: konfigBudowaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: konfigBudowaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: konfigBudowaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
