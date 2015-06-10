using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS_WEB.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckLogin(LoginModels Login)
        {
            if (ModelState.IsValid)
            {
                var db = new QLBanHangEntities().TaiKhoan;
                var count = db.FirstOrDefault(x => x.ID.ToLower() == Login.Username.ToLower() && x.PW == Login.Password);
                if (count != null)
                {
                    Session["User"] = count.ID.ToString();
                    return RedirectToAction("Home", "Home");
                }
            }
            return View();
        }

    }
}
