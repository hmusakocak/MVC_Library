using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Library.DataLayer.EntityFramework;
using MVC_Library.Managers;
using MVC_Library.Models.Entity;
using System.Web.Security;
using HtmlAgilityPack;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;

namespace MVC_Library.Controllers
{
    public class AffiliationController : Controller
    {
        MemberManager mm = new MemberManager(new EFMemberDal());
        DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();

        //Get list of universities with HtmlAgilityPack
        HtmlDocument doc = new HtmlDocument();
        HtmlWeb web = new HtmlWeb();
        
        
        // GET: Affiliation
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {          
            return View();
        }

        [HttpPost]
        public ActionResult Login(MEMBER m)
        {
            var bilgiler = db_entities.MEMBER.FirstOrDefault(x=>x.USERNAME == m.USERNAME && x.PASSWORD == m.PASSWORD);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.USERNAME , false);
                Session["username"] = bilgiler.USERNAME;
               
                return RedirectToAction("Index","Panel");
            }
            else 
            {
                ViewBag.msg = "Başarısız!";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            //Turkish char issue is solved with Encoding UTF-8 format
            web.OverrideEncoding = Encoding.UTF8;
            doc = web.Load("https://www.unibilgi.net/turkiyedeki-universitelerin-listesi/");
            List<string> list_of_uni = new List<string>();
            int ct = 2;
            while (true)
            {
                var xpath = string.Format("//*[@id='post-23027']/div[2]/table[1]/tbody/tr[{0}]/td[2]", ct);
                var node = doc.DocumentNode.SelectSingleNode(xpath);

                if (node != null)
                {
                    list_of_uni.Add(node.InnerText);
                }
                else { break; }
                ct++;
            }
            ViewBag.listuni = list_of_uni;

            return View();
        }

        [HttpPost]
        public ActionResult Register(MEMBER m) 
        {
            var list = mm.TGetAll();
            foreach (var item in list)
            { 
                if (m.USERNAME == item.USERNAME)
                {
                    TempData["error"] = "Bu kullanıcı adı kullanılmaktadır!";
                    ViewBag.msg = "Üyelik oluşturulamadı!";

                }
            }
            if (TempData["error"] != null)
            {
                ViewBag.error = TempData["error"];               
            }
            else
            {
                ViewBag.error = "";
                ViewBag.msg = "Üyelik başarıyla oluşturuldu!";
                mm.TInsert(m);
            }
            return View();
        }
    }
}