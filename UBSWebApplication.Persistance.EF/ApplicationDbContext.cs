using System.Data.Entity;

using UBSWebApplication.Core.Models;

namespace UBSWebApplication.Persistance.EF
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ApplicationDbContext()
        {
        }
    }
}