using BisikletSatis.Entities;
using BisikletSatis.Service.Abstract;
using BisikletSatis.WebUI.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;

namespace BisikletSatis.WebUI.Controllers
{
    public class FavoritesController : Controller
    {

        private readonly IBicycleService _serviceBisiklet;

        public FavoritesController(IBicycleService serviceBisiklet)
        {
            _serviceBisiklet = serviceBisiklet;
        }

        public IActionResult Index()
        {
            var favoriler = GetFavorites();
            return View(favoriler);
        }

        private List<Bisiklet> GetFavorites()
        {
            List<Bisiklet>? bisikletler = new();
            bisikletler = HttpContext.Session.GetJson<List<Bisiklet>>("GetFavorites");
            return bisikletler ?? new List<Bisiklet>();
        }
        public IActionResult Add(int bisikletId)
        {
            try
            {
                var bisiklet = _serviceBisiklet.Find(bisikletId);
                var favoriler = GetFavorites();
                if (bisiklet != null && !favoriler.Any(a => a.Id == bisikletId))
                {
                    favoriler.Add(bisiklet);
                    HttpContext.Session.SetJson("GetFavorites", favoriler);
                }
            }
            catch (Exception)
            {
                TempData["Message"] = "<div class='alert alert-danger'>Hata Oluştu!<div>";
            }
            
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int bisikletId)
        {
            try
            {
                var bisiklet = _serviceBisiklet.Find(bisikletId);
                var favoriler = GetFavorites();
                if (bisiklet != null && favoriler.Any(a => a.Id == bisikletId))
                {
                    favoriler.RemoveAll(a => a.Id == bisikletId);
                    HttpContext.Session.SetJson("GetFavorites", favoriler);
                }
            }
            catch (Exception)
            {
                TempData["Message"] = "<div class='alert alert-danger'>Hata Oluştu!<div>";
            }

            return RedirectToAction("Index");
        }
    }
}
