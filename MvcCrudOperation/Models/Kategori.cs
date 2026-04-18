namespace MvcCrudOperation.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string  KategoriAdi { get; set; }
        public string  Aciklama { get; set; }

        //Navigation Property
        public ICollection<Urun> Urunler { get; set; }

    }
}
