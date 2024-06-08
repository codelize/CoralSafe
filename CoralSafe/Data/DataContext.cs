using CoralSafe.Models;
using Microsoft.EntityFrameworkCore;

namespace CoralSafe.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> Options) : base(Options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Campanha> campanhas { get; set; }
        public DbSet<Donate> donates { get; set; }
        public DbSet<Ong> ongs { get; set; }
        public DbSet<Produto> produtos { get; set; }

    }
}
