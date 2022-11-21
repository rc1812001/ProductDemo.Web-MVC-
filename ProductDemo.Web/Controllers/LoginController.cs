using ProductDemo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductDemo.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginModel objUser)
        {
            if(ModelState.IsValid)
            {
                using (SampleDBEntities db = new SampleDBEntities())
                {
                    var obj = db.Users.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if(obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Product");
                    }
                    else
                    {
                        ViewBag.Message = "UserName or Password is incorrect";
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult Product()
        {
            if (Session["UserID"] != null)
            {
                SampleDBEntities db = new SampleDBEntities(); 
                return View(db.Products.ToList());
            }
            else
            {
                ViewBag.Message = "UserName or Password is incorrect";
                return RedirectToAction("Login");
            }
        }
    }
}