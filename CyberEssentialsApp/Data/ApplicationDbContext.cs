using CyberEssentialsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CyberEssentialsApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Workstation> Workstations { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet <Mobile> Mobiles { get; set; }
        public DbSet <Firewall> Firewalls { get; set; }

    }
}
