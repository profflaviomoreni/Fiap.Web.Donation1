using Fiap.Web.Donation1.Data;
using Fiap.Web.Donation1.Models;
using Fiap.Web.Donation1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation1.Controllers
{
    public class ProdutoController : BaseController
    {

        private readonly TipoProdutoRepository tipoProdutoRepository;

        private readonly IProdutoRepository produtoRepository;

        

        public ProdutoController(DataContext dataContext, 
                                IProdutoRepository prodRepository,  
                                IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            produtoRepository = prodRepository;
            tipoProdutoRepository = new TipoProdutoRepository(dataContext);
        }


        [HttpGet]
        public IActionResult Index() //Lista todos os produtos
        {
            var produtos = produtoRepository.FindAllWithTipoOrderByName();

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
                produtoModel.UsuarioId = UsuarioId;
                produtoRepository.Insert(produtoModel);

                TempData["Mensagem"] = $"{produtoModel.Nome} cadastrado com sucesso";
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            ComboTipoProduto();

            var produtoModel = produtoRepository.FindById(id);
            return View(produtoModel);
        }


        [HttpPost]
        public IActionResult Editar(ProdutoModel produtoModel)
        {
            if ( string.IsNullOrEmpty(produtoModel.Nome) )
            {
                ComboTipoProduto();

                ViewBag.Mensagem = "O campo nome é requerido";
                return View(produtoModel);

            } else
            {
                produtoModel.UsuarioId = UsuarioId;
                produtoRepository.Update(produtoModel);

                TempData["Mensagem"] = $"{produtoModel.Nome} alterado com sucesso";

                return RedirectToAction("Index");
            }
        }



        private void ComboTipoProduto()
        {
            var tiposProdutos = tipoProdutoRepository.FindAll();

            var comboTipoProdutos = new SelectList(tiposProdutos, "TipoProdutoId", "Nome");

            ViewBag.TipoProdutos = comboTipoProdutos;
        }
    }
}
