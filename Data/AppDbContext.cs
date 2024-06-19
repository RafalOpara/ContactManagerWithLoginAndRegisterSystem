using CustomIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentity.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Contact> Contacts { get; set; }
       

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

         
        
    }
}
