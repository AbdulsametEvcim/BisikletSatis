using BisikletSatis.Entities;
using BisikletSatis.Service.Abstract;
using BisikletSatis.WebUI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BisikletSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class BicyclesController : Controller
    {
        private readonly IService<Bisiklet> _service;
        private readonly IService<Marka> _serviceMarka;

        public BicyclesController(IService<Bisiklet> service, IService<Marka> serviceMarka)
        {
            _service = service;
            _serviceMarka = serviceMarka;
        }

        // GET: BicyclesController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: BicyclesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BicyclesController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View();
        }

        // POST: BicyclesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Bisiklet bisiklet, IFormFile? Resim1, IFormFile? Resim2)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bisiklet.Resim1 = await FileHelper.FileLoaderAsync(Resim1, "/Img/Bicycles/");
                    bisiklet.Resim2 = await FileHelper.FileLoaderAsync(Resim2, "/Img/Bicycles/");
                    await _service.AddAsync(bisiklet);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(bisiklet);
        }

        // GET: BicyclesController/Edit/5
        public async Task<IActionResult> EditAsync(int id)
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: BicyclesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Bisiklet bisiklet, IFormFile? Resim1, IFormFile? Resim2)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Resim1 is not null)
                    {
                        bisiklet.Resim1 = await FileHelper.FileLoaderAsync(Resim1, "/Img/Bicycles/");
                    }
                    if (Resim2 is not null)
                    {
                        bisiklet.Resim2 = await FileHelper.FileLoaderAsync(Resim2, "/Img/Bicycles/");
                    }
                    _service.Update(bisiklet);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");
            return View(bisiklet);
        }

        // GET: BicyclesController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: BicyclesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Bisiklet bisiklet)
        {
            try
            {
                _service.Delete(bisiklet);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
