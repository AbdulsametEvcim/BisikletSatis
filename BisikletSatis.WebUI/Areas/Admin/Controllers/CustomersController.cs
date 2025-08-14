using BisikletSatis.Entities;
using BisikletSatis.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BisikletSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class CustomersController : Controller
    {
        private readonly IService<Musteri> _service;
        private readonly IService<Bisiklet> _serviceBisiklet;

        public CustomersController(IService<Musteri> service, IService<Bisiklet> serviceBisiklet)
        {
            _service = service;
            _serviceBisiklet = serviceBisiklet;
        }

        // GET: CustomersController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomersController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.BisikletId = new SelectList(await _serviceBisiklet.GetAllAsync(), "Id", "Modeli");
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(musteri);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.BisikletId = new SelectList(await _serviceBisiklet.GetAllAsync(), "Id", "Modeli");
            return View(musteri);
        }

        // GET: CustomersController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            ViewBag.BisikletId = new SelectList(await _serviceBisiklet.GetAllAsync(), "Id", "Modeli");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(musteri);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.BisikletId = new SelectList(await _serviceBisiklet.GetAllAsync(), "Id", "Modeli");
            return View(musteri);
        }

        // GET: CustomersController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Musteri musteri)
        {
            try
            {
                _service.Delete(musteri);
                _service.Save(); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
