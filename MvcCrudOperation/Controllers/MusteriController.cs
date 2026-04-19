using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MvcCrudOperation.Controllers
{
    public class MusteriController : Controller
    {
        // GET: MusteriController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MusteriController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MusteriController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusteriController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusteriController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MusteriController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusteriController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MusteriController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
