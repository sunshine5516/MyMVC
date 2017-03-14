using Microsoft.AspNet.Identity.EntityFramework;
namespace WXPageAdmin.Models
{
    public class ApplicationUser : IdentityUser
    {

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        { }
    }
}