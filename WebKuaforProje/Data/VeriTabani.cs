using Microsoft.EntityFrameworkCore;

namespace WebKuaforProje.Data
{
    // DbContext sınıfı
    public class VeriTabani : DbContext
    {
        public VeriTabani(DbContextOptions<VeriTabani> options) : base(options)
        {
        }

        // Kullanıcı tablosunu temsil eden DbSet
        public DbSet<Kullanici> Kullanicilar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tablonun adını ve sütun adlarını eşleştiriyoruz
            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.ToTable("Kullanici"); // Veritabanındaki tablo adı
                entity.Property(e => e.Id).HasColumnName("Kullanici_ID");
                entity.Property(e => e.KullaniciAdi).HasColumnName("KullaniciAdi");
                entity.Property(e => e.Sifre).HasColumnName("Sifre");
                entity.Property(e => e.Rol).HasColumnName("Kimlik");
            });
        }
    }

    public class Kullanici
    {
        public int Id { get; set; }             
        public string KullaniciAdi { get; set; } 
        public string Sifre { get; set; }    
        public string Rol { get; set; }        
    }
}
