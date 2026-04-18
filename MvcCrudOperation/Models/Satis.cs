using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCrudOperation.Models
{
    public class Satis
    {
        public int Id { get; set; }
        public DateTime SatisTarihi { get; set; }
        public int Miktar { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal  ToplamTutar { get; set; }


        //Foreing Key
        public int MusteriId { get; set; }
        public int UrunId { get; set; }

        //Navigation Property
        public Musteri Musteri { get; set; }
        public Urun Urun { get; set; }


    }
}
