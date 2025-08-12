using BisikletSatis.Entities;
using BisikletSatis.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BisikletSatis.WebUI.Controllers
{
    public class BisikletController : Controller
    {
        private readonly IService<Bisiklet> _serviceBisiklet;

        public BisikletController(IService<Bisiklet> serviceBisiklet)
        {
            _serviceBisiklet = serviceBisiklet;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = await _serviceBisiklet.FindAsync(id);
            return View(model);
        }
    }
}
