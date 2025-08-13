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
    }
}
