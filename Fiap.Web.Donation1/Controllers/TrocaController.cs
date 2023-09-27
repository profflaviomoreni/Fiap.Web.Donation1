using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Migrations;
using Fiap.Web.Donation1.Repository;
using Fiap.Web.Donation1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation1.Controllers
{
    public class TrocaController : Controller
    {
        private readonly ProdutoRepository produtoRepository;

        private readonly TrocaRepository trocaRepository;

        private readonly TrocaService trocaService;

        private readonly int UsuarioId = 1;

        public TrocaController(DataContext dataContext)
        {
            produtoRepository = new ProdutoRepository(dataContext);
            trocaRepository = new TrocaRepository(dataContext);
            trocaService = new TrocaService(produtoRepository, trocaRepository);
        }



        [HttpGet]
        public IActionResult Index(int id)
        {
            var trocaModel = new Models.TrocaModel();
            trocaModel.ProdutoId1 = id;
            trocaModel.ProdutoModel1 = produtoRepository.FindById(id);

            ComboMeusProdutos();

            return View(trocaModel);
        }


        [HttpPost]
        public IActionResult Index(Models.TrocaModel trocaModel)
        {

            try
            {
                trocaService.TrocarProdutos(trocaModel);

                TempData["Mensagem"] = "Troca registrada com sucesso.";
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
            }

            return RedirectToAction("Index", "Home");
        }

        



        private void ComboMeusProdutos()
        {
            var produtos = produtoRepository.FindAllDisponivelDoUsuario(true, UsuarioId);

            var comboProdutos = new SelectList(produtos, "ProdutoId", "Nome" );

            ViewBag.MeusProdutos = comboProdutos;

        }

    }
}
