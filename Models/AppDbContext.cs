using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Vidly_MVCProject.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext() : base("Vidly_MVCProject", throwIfV1Schema: false)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}