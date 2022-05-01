using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using WorldDomination.Core;

namespace WorldDomination.Controllers
{
    //[Route("W-d/Login")]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //[Route("login")]
        public JsonResult login(string login, string password)
        {
            string account_id = DBMysql.GetAccountId(login, password);
            if(account_id == "none")
            {
                return Json(new
                    {
                        Status = "0"
                    });
            }
            else
            {
                HttpCookie cookie = new HttpCookie("CountryId");
                cookie["countryId"] = account_id;
                cookie.Expires = DateTime.Now.AddHours(10);
                Response.Cookies.Add(cookie);
                return Json(new
                {
                    Status = "1"
                });
                //Response.Redirect("Game/Index", true);
                //return View();
            }
        }
    }
}