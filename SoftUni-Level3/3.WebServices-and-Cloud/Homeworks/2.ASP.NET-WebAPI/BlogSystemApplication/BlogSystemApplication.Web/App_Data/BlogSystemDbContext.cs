namespace BlogSystemApplication.Web.App_Data
{
    using BlogSystemApplication.Web.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class BlogSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogSystemDbContext()
            : base("BlogSystemDb", false)
        {
        }
        
        public static BlogSystemDbContext Create()
        {
            return new BlogSystemDbContext();
        }
    }
}