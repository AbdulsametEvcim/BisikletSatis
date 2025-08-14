using BisikletSatis.Entities;
using BisikletSatis.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BisikletSatis.WebUI.Controllers
{
    public class BisikletController : Controller
    {
        private readonly IBicycleService _serviceBisiklet;

        public BisikletController(IBicycleService serviceBisiklet)
        {
            _serviceBisiklet = serviceBisiklet;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = await _serviceBisiklet.GetCustomBicycle(id);
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
    }
}
