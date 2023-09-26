using Fiap.Web.Donation1.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation1.Controllers
{
    public class TrocaController : Controller
    {
        [HttpGet]
        public IActionResult Index(int id)
        {
            var trocaModel = new Models.TrocaModel();
            trocaModel.ProdutoId1 = id;

            return View(trocaModel);
        }


        [HttpPost]
        public IActionResult Index(TrocaModel trocaModel)
        {
            return View();
        }



    }
}
