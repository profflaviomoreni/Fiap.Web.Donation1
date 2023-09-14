using Fiap.Web.Donation1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation1.Controllers
{
    public class ProdutoController : Controller
    {

        private List<ProdutoModel> produtos;

        public ProdutoController()
        {
            // Acesso fake ao banco dados
            // SELECT * FROM produtos;

            produtos = new List<ProdutoModel>{ 
                new ProdutoModel()
                {
                    ProdutoId = 1,
                    Nome = "Iphone 11",
                    TipoProdutoId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 2,
                    Nome = "Iphone 12",
                    TipoProdutoId = 2,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 3,
                    Nome = "Iphone 13",
                    TipoProdutoId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 4,
                    Nome = "Iphone 14",
                    TipoProdutoId = 1,
                    Disponivel = false,
                    DataExpiracao = DateTime.Now,
                },
            };        

        }


        [HttpGet]
        public IActionResult Index() //Lista todos os produtos
        {
            //Consultar o banco de dados;

            //TempData["Produtos"] = produtos;

            ViewBag.Produtos = produtos;

            return View();
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Novo(ProdutoModel produtoModel) {
            // Gravando o produto no banco de dados
            // Insert into produtos  values ...

            //ViewBag.Mensagem = $"{produtoModel.Nome} cadastrado com sucesso";
            TempData["Mensagem"] = $"{produtoModel.Nome} cadastrado com sucesso";

            return RedirectToAction("Index");
        }


    }
}
