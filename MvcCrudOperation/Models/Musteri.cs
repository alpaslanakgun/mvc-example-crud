namespace MvcCrudOperation.Models
{
    public class Musteri
    {
        public int Id { get; set; }
        public string  AdSoyad { get; set; }
        public string  Email { get; set; }
        public string  Telefon { get; set; }


        //Navigation Property
        public ICollection<Satis> Satislar { get; set; }


    }
}
