using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookStore.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string BirthDate { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public long shopping_cart_id { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {


        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            var claims = new List<Claim>();
            claims.Add(new Claim("BirthDate", this.BirthDate));
            claims.Add(new Claim("FirstName", this.FirstName));
            claims.Add(new Claim("LastName", this.LastName));
            claims.Add(new Claim("Country", this.Country));
            claims.Add(new Claim("City", this.City));
            claims.Add(new Claim("PostalCode", this.PostalCode));
            claims.Add(new Claim("Address", this.Address));
            claims.Add(new Claim("shopping_cart_id", shopping_cart_id.ToString()));

            userIdentity.AddClaims(claims);
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("BookStoreConn", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}