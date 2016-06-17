using System.Collections.Generic;
using ZaKhan.Data;
using ZaKhan.Model;

namespace ZaKhan.BusinessLogic
{
    public interface IRolesBusiness
    {
        //List<ApplicationUser> GetRoleUsers(string id);
        List<RoleViewModel> GetAllRoles();
        EditRoleViewModel GetRole(string id);
        bool Insert(RoleViewModel model);
        //bool Update(EditRoleViewModel model);
        void Delete(string id);
        void Dispose(bool disposing);
    }
}
