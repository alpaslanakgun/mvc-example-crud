using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCrudOperation.Data;
using MvcCrudOperation.Models;

namespace MvcCrudOperation.Controllers
{
    public class UrunController : Controller
    {
        private readonly AppDbContext _context;

        public UrunController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Include ile Kategori bilgisiyle birlikte urunleri cekecegiz join işlemidir.

            var urunler = _context.Urunler.Include(u => u.Kategori).ToList();

            return View(urunler);
        }

        [HttpGet]
        //Get: Urun/Create
        public IActionResult Create()
        {
            //Dropdown ile kategori listesini viewbag'e koyacagız
            ViewBag.Kategoriler = new SelectList(_context.Kategoriler, "Id", "KategoriAdi");

            return View();
        }

        [HttpPost]
        //Post: Urun/Create 
        public IActionResult Create(Urun urun)
        {
            ModelState.Remove("Kategori");//Kategori bilgisi view tarafında gelmeyecegi icin modelstate den kaldırıyoruz yoksa validation hatası verir burada simdilik ignore ettik 

            if (ModelState.IsValid)//Girilmiş olan data dogrulanmıs yani gerekli alanlar doldurulmusmu 
            {
                _context.Urunler.Add(urun);//insert into Urunler values(urun.UrunAdi, urun.Fiyat, urun.Stok, urun.KategoriId)
                _context.SaveChanges(); //calıstır execute kayıt işlemi yapar
                return RedirectToAction("Index"); // ekleme işlemi tamamlandıktansonra beni Urun/Index sayfasına yönlendir
            }

            foreach (var item in ModelState)
            {
                foreach (var mesaj in item.Value.Errors)
                {
                    Console.WriteLine($"{item.Key}:{mesaj.ErrorMessage}");
                }
            }




            ViewBag.Kategoriler = new SelectList(_context.Kategoriler, "Id", "KategoriAdi",urun.KategoriId);
            return View(urun);
        }
        //Get: Urun/Edit/Id update Urunler set= UrunAdi= @UrunAdi, Fiyat=@Fiyat, Stok=@Stok, KategoriId=@KategoriId where Id=@Id 

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var urun = _context.Urunler.Find(id);
            if (urun==null)
            {
                return NotFound();//bulunamadı gönderiyoruz
            }
            ViewBag.Kategoriler = new SelectList(_context.Kategoriler, "Id", "KategoriAdi", urun.KategoriId);
            return View(urun);
        }
        [HttpPost]
        public IActionResult Edit(int id,Urun urun)
        {
            if (id != urun.Id) return NotFound();
            ModelState.Remove("Kategori");
            if (ModelState.IsValid)
            {
                _context.Urunler.Update(urun);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kategoriler = new SelectList(_context.Kategoriler, "Id", "KategoriAdi", urun.KategoriId);
            return View(urun);
        }

        //Get Urun/Delete/5

        public IActionResult Delete(int id)
        {
            var urun =_context.Urunler.Include(u=> u.Kategori).FirstOrDefault(u => u.Id == id);
            if(urun == null)
            {
                return NotFound();
            }
            return View(urun);
        }

        //Post Urun/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var urun =_context.Urunler.Find(id);//where Id=7
            if (urun != null)
            {
                _context.Urunler.Remove(urun);//delete from Urunler where Id=7
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


    }
}
