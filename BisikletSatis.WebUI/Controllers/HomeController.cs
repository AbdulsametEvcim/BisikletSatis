using BisikletSatis.Entities;
using BisikletSatis.Service.Abstract;
using BisikletSatis.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BisikletSatis.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Slider> _service;
        private readonly IService<Bisiklet> _serviceBisiklet;

        public HomeController(IService<Slider> service, IService<Bisiklet> serviceBisiklet)
        {
            _service = service;
            _serviceBisiklet = serviceBisiklet;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = new HomePageViewModel()
            {
                Sliders = await _service.GetAllAsync(),
                Bisikletler = await _serviceBisiklet.GetAllAsync(a => a.AnaSayfa)
            };
               
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
