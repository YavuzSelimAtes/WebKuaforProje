using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebKuaforProje.Data
{
    // DbContext sınıfı
    public class VeriTabani : DbContext
    {
        public VeriTabani(DbContextOptions<VeriTabani> options) : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Sube> Subeler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=WebProje;Username=postgres;Password=Ystns.r.a.a.6");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.ToTable("Kullanici");
                entity.Property(e => e.Id).HasColumnName("Kullanici_ID");
                entity.Property(e => e.KullaniciAdi).HasColumnName("KullaniciAdi");
                entity.Property(e => e.Sifre).HasColumnName("Sifre");
                entity.Property(e => e.Rol).HasColumnName("Kimlik");
            });

            modelBuilder.Entity<Personel>()
                .HasOne(p => p.Kullanici)
                .WithOne(k => k.Personel)
                .HasForeignKey<Personel>(p => p.Id);
            modelBuilder.Entity<Personel>()
                .HasOne(p => p.Sube)
                .WithMany(s => s.Personeller)
                .HasForeignKey(p => p.Subesi)
                .HasPrincipalKey(s => s.Sehir);


            modelBuilder.Entity<Sube>(entity =>
            {
                entity.ToTable("Subeler"); // Veritabanındaki tablo adı
                entity.HasKey(e => e.Sehir); // Primary Key
                entity.Property(e => e.Sehir).HasColumnName("Sehir");
                entity.Property(e => e.Isim).HasColumnName("Isim");
                entity.Property(e => e.TamAdres).HasColumnName("TamAdres");
            });
        }
    }

    public class Kullanici
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string KullaniciAdi { get; set; }
        [Required]
        public string Sifre { get; set; }
        [Required]
        public string Rol { get; set; }
        [Required]
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }
        [Required]
        public string TelefonNo { get; set; }
        public virtual Personel Personel { get; set; }
    }

    public class Personel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Subesi { get; set; }
        [Required]
        public string UzmanlikAlani { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual Sube Sube { get; set; }
    }

    public class Sube
    {
        public string Sehir { get; set; }
        public string Isim { get; set; }
        public string TamAdres { get; set; }
        public virtual ICollection<Personel> Personeller { get; set; }
    }
}
