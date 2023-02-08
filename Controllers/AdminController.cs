using MVC_Library.Models.Entity;
using MVC_Library.RoleManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Library.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ADMIN a)
        {
            var loggedadmin = new DBKUTUPHANE_Entities().ADMIN.FirstOrDefault(x=> x.admin_name == a.admin_name && x.admin_password == a.admin_password);
            if (loggedadmin != null) 
            {
                FormsAuthentication.SetAuthCookie(loggedadmin.admin_name,false);
                Session["admin"] = loggedadmin.admin_name;
                AdminRoleProvider arp = new AdminRoleProvider();
                arp.GetRolesForUser((string)Session["admin"]);
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}