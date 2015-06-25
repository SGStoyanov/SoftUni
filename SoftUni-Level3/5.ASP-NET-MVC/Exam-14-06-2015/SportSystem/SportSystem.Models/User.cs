namespace SportSystem.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {

        //private ICollection<Bet> bets;
        //private ICollection<Comment> comments;

        //public User()
        //{
        //    this.bets = new HashSet<Bet>();
        //    this.comments = new HashSet<Comment>();
        //}

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //public virtual ICollection<Bet> Bets
        //{
        //    get { return this.bets; }
        //    set { this.bets = value; }
        //}

        //public virtual ICollection<Comment> Comments
        //{
        //    get { return this.comments; }
        //    set { this.comments = value; }
        //}
 
    }
}