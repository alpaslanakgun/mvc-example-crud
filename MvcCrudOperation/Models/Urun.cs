using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCrudOperation.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string  UrunAdi { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal  Fiyat { get; set; }
        public int Stok { get; set; }

        //Foreing Key
        public int KategoriId { get; set; }

        //Navigation Property
        public Kategori Kategori { get; set; }
    }
}
