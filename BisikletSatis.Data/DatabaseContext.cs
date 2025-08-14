using BisikletSatis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BisikletSatis.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Bisiklet> Bisikletler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Tamirhane> Tamirhaneler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(LocalDB)\MSSQLLocalDB;
            database=BisikletSatisNetCore; integrated security=true;
            TrustServerCertificate=true;");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore
            (RelationalEventId.PendingModelChangesWarning));

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marka>().Property(m => m.Adi).IsRequired
                ().HasColumnType("varchar(50)");
           
            modelBuilder.Entity<Rol>().Property(m => m.Adi).IsRequired
                ().HasColumnType("varchar(50)");

            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 1,
                Adi = "Admin"
            });
            modelBuilder.Entity<Kullanici>().HasData(new Kullanici
            {
                Id = 1,
                Adi = "Admin",
                AktifMi = true,
                EklemeTarihi = DateTime.Now,
                Email = "admin@bisikletsatis.com",
                KullaniciAdi = "admin",
                Sifre = "1907",
                RolId = 1,
                Soyadi = "admin",
                Telefon = "0850"
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
