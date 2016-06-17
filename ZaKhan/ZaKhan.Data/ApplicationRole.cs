using Microsoft.AspNet.Identity.EntityFramework;

namespace ZaKhan.Data
{
    public sealed class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }


        public ApplicationRole(string name, string description)
            : base(name)
        {
            this.Description = description;
        }
        public string Description { get; set; }
    }
}
