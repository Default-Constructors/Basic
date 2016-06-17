using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using ZaKhan.Data;
using ZaKhan.Model;

namespace ZaKhan.BusinessLogic
{
    public class RolesBusiness:IRolesBusiness
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        IdentityManager _idman = new IdentityManager();

        public List<ApplicationUser> GetRoleUsers(string id)
        {
            var roleUsers = _db.Users.Where(u => u.Roles.Any(r => r.RoleId == id));
            return roleUsers.ToList();
        }

        public ApplicationUser GetUsers(string username)
        {
            var users = _db.Users.First(x => x.UserName.Equals(username));
            return users;
        }

        public List<RoleViewModel> GetAllRoles()
        {
            var rolesList = new List<RoleViewModel>();
            foreach (var role in _db.Roles)
            {
                var roleModel = new RoleViewModel(ConvertRole(role));
                rolesList.Add(roleModel);
            }
            return rolesList;
        }

        public EditRoleViewModel GetRole(string id)
        {
            var role = _db.Roles.First(r => r.Name == id);
            var roleModel = new EditRoleViewModel(ConvertRole(role));
            return roleModel;
        }

        private static ApplicationRole ConvertRole(IdentityRole role)
        {
            var r = new ApplicationRole()
            {
                Id = role.Id,
                Name = role.Name,
                
            };
            return r;
        }

        public ApplicationRole Convert(IdentityRole role)
        {
            var r = new ApplicationRole()
            {
                Id = role.Id,
                Name = role.Name,
            };
            return r;
        }

        public bool Insert(RoleViewModel model)
        {
            bool result = false;
            var role = new ApplicationRole(model.RoleName, model.Description);
            if (_idman.RoleExists(model.RoleName))
            {
                result = false;
            }
            else
            {
                _idman.CreateRole(model.RoleName, model.Description);
                result = true;
            }
            return result;
        }

        public bool Update(EditRoleViewModel model)
        {
            bool res = false;
            //We have to check if that role exist, if it exist return false else create new role and return true
            if (_idman.RoleExists(model.RoleName))
                res = false;
            else
            {
                _idman.CreateRole(model.RoleName, model.Description);

                ////Then we move all users from the previous role to the new role
                //var newrole = ConvertRole(FirstRole(model.RoleName));
                //var oldrole = ConvertRole(FirstRole(model.OriginalRoleName));
                //var roleUsers = _db.Users.Where(u => u.Roles.Any(r => r.RoleId == oldrole.Name));
                //foreach (var user in roleUsers)
                //{
                //    _idman.AddUserToRole(user.Id, model.RoleName);
                //}

                ////Then we finaly delete the old role and create a new role
                //_idman.DeleteRole(oldrole.Id);
                //_idman.CreateRole(newrole.Id, newrole.Description);
                res = true;

            }
            return res;
        }

        public void Delete(string id)
        {
            var role = FirstRole(id);
            var idManager = new IdentityManager();
            idManager.DeleteRole(role.Id);
        }

        public IdentityRole FirstRole(string rolePara)
        {
            return _db.Roles.First(r => r.Name == rolePara);
        }

        public void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }
    }
}
