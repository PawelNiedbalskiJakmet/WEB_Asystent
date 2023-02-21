using Microsoft.AspNetCore.Mvc;
using WEB_Asystent.KlasyProgramu;
using WEB_Asystent.Models;

namespace WEB_Asystent.Controllers
{
    public class konfigBudowaController : Controller
    {
        // GET: konfigBudowaController
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
            // test here!
            if(data != null);
            var i = 0;
            var j = 14;
            var k = 15;
            var m = 0;
            return Json(data);
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
