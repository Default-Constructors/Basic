using System.Net;
using System.Web.Mvc;
using ZaKhan.BusinessLogic;
using ZaKhan.Data;
using ZaKhan.Model;


namespace ZaKhan.Controllers
{
     //[Authorize]
    public class RolesController : Controller
    {
         private ApplicationDbContext _db = new ApplicationDbContext();

        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            RolesBusiness rolesB = new RolesBusiness();
            return View(rolesB.GetAllRoles());
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Roleuser(string id)
        {
            RolesBusiness rolesB = new RolesBusiness();
            return View(rolesB.GetRoleUsers(id));
        }


        //[Authorize(Roles = "Admin")]
        public ActionResult Create(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include =
            "RoleName,Description")]RoleViewModel model)
        {
            string message = "That role name has already been used";
            if (ModelState.IsValid)
            {
                RolesBusiness rolesB = new RolesBusiness();
                if (rolesB.Insert(model) != true)
                {
                    return View(message);
                }
                else
                {
                    return RedirectToAction("Index", "Roles");
                }
            }
            return View();
        }


        ////[Authorize(Roles = "Admin, CanEdit")]
        public ActionResult Edit(string id)
        {
            RolesBusiness rolesB = new RolesBusiness();
            // It's actually the Role.Name tucked into the id param:
            var roleModel = rolesB.GetRole(id);
            return View(roleModel);
        }


        [HttpPost]
        //[Authorize(Roles = "Admin, CanEdit")]
        public ActionResult Edit([Bind(Include =
            "RoleName,OriginalRoleName,Description")] EditRoleViewModel model)
        {
            RolesBusiness rolesB = new RolesBusiness();
            if (ModelState.IsValid)
            {
                if (rolesB.Update(model))
                    return RedirectToAction("Index","Roles");

                else
                {
                    return View(model);
                }
            }
            return View(model);
        }


        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            RolesBusiness rolesB = new RolesBusiness();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = rolesB.FirstRole(id);
            var model = new RoleViewModel();//role);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        //[Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            RolesBusiness rolesB = new RolesBusiness();
            rolesB.Delete(id);
            return RedirectToAction("Index");
        }
	}
}