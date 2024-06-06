using Microsoft.EntityFrameworkCore;

namespace KhanhPG_SE05335.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() // ctor  tab tab
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Sinhvien> Sinhviens { get; set; }
        public DbSet<Lophoc> Lophocs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SHANGHAIK;Database=Tutor_NET104_TT;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
