using System.Data.Entity;
using MunicipalityServiceApp2.Models;

namespace MunicipalityServiceApp2.Data
{
    public class MunicipalityDbContext : DbContext
    {
        public MunicipalityDbContext()
            : base("name=MunicipalityConnection")
        {
        }

        public DbSet<Issue> Issues { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Announcement> Announcements { get; set; }
    }
}