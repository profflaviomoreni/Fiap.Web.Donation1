using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation1.Controllers
{
    public class TodasTrocasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
