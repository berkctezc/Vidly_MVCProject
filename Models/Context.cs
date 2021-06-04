using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly_MVCProject.Models
{
    public class Context : IdentityDbContext
    {
        public Context() : base("Vidly_MVCProject")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}