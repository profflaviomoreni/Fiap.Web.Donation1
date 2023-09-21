using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Models;
using Fiap.Web.Donation1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation1.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ProdutoRepository produtoRepository;

        public ProdutoController(DataContext dataContext)
        {
            produtoRepository = new ProdutoRepository(dataContext);
        }


        [HttpGet]
        public IActionResult Index() //Lista todos os produtos
        {
            var produtos = produtoRepository.FindAll();

            return View(produtos);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View(new ProdutoModel());
        }

        [HttpPost]
        public IActionResult Novo(ProdutoModel produtoModel) {

            if (string.IsNullOrEmpty(produtoModel.Nome))
            {
                ViewBag.Mensagem = "O campo nome é requerido";
                return View(produtoModel);
            }
            else
            {
                produtoModel.UsuarioId = 1;
                produtoRepository.Insert(produtoModel);

                TempData["Mensagem"] = $"{produtoModel.Nome} cadastrado com sucesso";
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            var produto = produtoRepository.FindById(id);
            return View(produto);
        }


        [HttpPost]
        public IActionResult Editar(ProdutoModel produtoModel)
        {
            if ( string.IsNullOrEmpty(produtoModel.Nome) )
            {
                ViewBag.Mensagem = "O campo nome é requerido";
                return View(produtoModel);

            } else
            {
                produtoModel.DataCadastro = DateTime.Now;
                produtoModel.UsuarioId = 1;
                produtoRepository.Update(produtoModel);

                TempData["Mensagem"] = $"{produtoModel.Nome} alterado com sucesso";

                return RedirectToAction("Index");
            }
        }

    }
}
