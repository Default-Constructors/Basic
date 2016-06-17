using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ZaKhan.Data.Orderz;

namespace ZaKhan.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Products> Productss { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProdCategory>ProdCategorys{get;set;}

        public DbSet<ProdBrand>ProdBrands{get;set;}

        public DbSet<StoreLocation>StorLocations{get;set;}

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Optometrist> Optometrists { get; set; }

        public DbSet<Fee> Fees { get; set; }

        public DbSet<Audit> Audits { get; set; }
      

       

       

        

       

       

      

        

       

        
    }
}