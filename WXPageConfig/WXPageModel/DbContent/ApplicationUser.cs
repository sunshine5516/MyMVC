using Microsoft.AspNet.Identity.EntityFramework;
namespace WXPageModel.Models
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