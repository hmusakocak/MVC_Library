using MVC_Library.DataLayer.EntityFramework;
using MVC_Library.FluentValidation;
using MVC_Library.Managers;
using MVC_Library.Models.Entity;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Library.Controllers
{
    public class MemberController : Controller
    {
        MemberManager mm = new MemberManager(new EFMemberDal());
       
        // GET: Member
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var memlist = mm.TGetAll().ToPagedList(page, 3);
            return View(memlist);
        }


        [HttpPost]
        public ActionResult AddMember(MEMBER m)
        {
            MemberValidator mv = new MemberValidator();
            var result = mv.Validate(m);

            if (result.IsValid)
            {
                mm.TInsert(m);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }

        public ActionResult DeleteMember(int id)
        {
            mm.TDelete(id);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateMember(MEMBER m)
        {
            mm.TUpdate(m);
            return RedirectToAction("Index");
        }

        public ActionResult GetMember(int id)
        {
            return View(mm.TGetByID(id));
        }

    }
}