using BisikletSatis.Entities;
using BisikletSatis.Service.Abstract;
using BisikletSatis.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BisikletSatis.WebUI.Controllers
{
    public class BisikletController : Controller
    {
        private readonly IBicycleService _serviceBisiklet;
        private readonly IService<Musteri> _serviceMusteri;
        private readonly IUserService _service;

        public BisikletController(IBicycleService serviceBisiklet, IService<Musteri> serviceMusteri, IUserService service)
        {
            _serviceBisiklet = serviceBisiklet;
            _serviceMusteri = serviceMusteri;
            _service = service;
        }

        public async Task<IActionResult> IndexAsync(int? id)
        {
            if (id == null)
                return BadRequest();

            
                var bisiklet = await _serviceBisiklet.GetCustomBicycle(id.Value);
            if (bisiklet == null)
                 return NotFound();
            var model = new BicycleDetailViewModel();
            model.Bisiklet = bisiklet;

            if (User.Identity.IsAuthenticated)
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                var uguid = User.FindFirst(ClaimTypes.UserData)?.Value;
                if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(uguid))
                {
                    var user = _service.Get(k => k.Email == email && k.UserGuid.ToString() == uguid);
                    if (user != null)
                    {
                        model.Musteri = new Musteri
                        {
                            Adi = user.Adi,
                            Soyadi = user.Soyadi,
                            Email = user.Email,
                            Telefon = user.Telefon
                        };
                    }
                }
            }

            return View(model);
        }
        [Route("tum-bisikletlerimiz")]
        public async Task<IActionResult> List()
        {
            var model = await _serviceBisiklet.GetCustomBicycleList(c => c.SatistaMi);
            return View(model);
        }
        public async Task<IActionResult> Ara(string q)
        {
            var model = await _serviceBisiklet.GetCustomBicycleList(c => c.SatistaMi && c.Marka.Adi.Contains(q) || c.BisikletTipi.Contains(q));
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> MusteriKayit(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceMusteri.AddAsync(musteri);
                    await _serviceMusteri.SaveAsync();
                    return Redirect("/Bisiklet/Index/" + musteri.BisikletId);
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View();
        }
    }
}
