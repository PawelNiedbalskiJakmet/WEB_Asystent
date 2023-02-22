using Microsoft.AspNetCore.Mvc;
using WEB_Asystent.Models;

namespace WEB_Asystent.Controllers
{
    public class SharedController : Controller
    {
        public IActionResult _Layout()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Init(UserModel data)
        {
            List<UserModel> _users = new List<UserModel>();
            foreach (var item in globalne.Uzytkownicy)
            {
                _users.Add(new UserModel(item));
            }

            var doReturn = _users.Select(model => new
            {
                imie = model.imie,
                nazwisko = model.nazwisko,
                id = model.id,

            }); ;
            return Json(doReturn);
        }

    }
}
