using System.ComponentModel.DataAnnotations;
using ZaKhan.Data;

namespace ZaKhan.Model
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Enter the role name")]
        [Display(Name = "Role name")]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "Enter role description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public RoleViewModel() { }
        public RoleViewModel(ApplicationRole role)
        {
            this.RoleName = role.Name;
            this.Description = role.Description;
        }
    }
}
