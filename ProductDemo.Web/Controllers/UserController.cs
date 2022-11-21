using ProductDemo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductDemo.Web.DAL;
using System.Net;
using System.Data.Entity;

namespace ProductDemo.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                RegisterDataLayer dal = new RegisterDataLayer();
                string message = dal.SignUpUser(model);
            }
            else
            {
                return View("~/Views/User/Index.cshtml");
            }
            return View();
        }
    }
}