using Microsoft.EntityFrameworkCore;
using MvcCrudOperation.Models;

namespace MvcCrudOperation.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler{ get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Satis> Satislar { get; set; }


    }
}
