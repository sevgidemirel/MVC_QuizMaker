using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SınavProjesi.Models;
using SınavProjesi.Context;


namespace SınavProjesi.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        ExamContext db = new ExamContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var v = db.Users.Where(a=>a.UserName.Equals(user.UserName) && a.Password.Equals(user.Password)).FirstOrDefault();

            if (v != null)
            {
                Session["LogedUserID"] = v.UserId;
                Session["LoggedUserName"] = v.UserName;

                if (Session["LogedUserID"].ToString() == "1")
                {
                    return RedirectToAction("Create", "Quiz");
                }
                else if(Session["LogedUserID"].ToString() == "2")
                {
                    return RedirectToAction("Solve", "Quiz");
                }
            }
            ViewBag.Message = "Kullanıcı adı veya şifre yanlış..";
            return View(user);


        }

    }
}