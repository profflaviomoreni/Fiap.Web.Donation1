using Fiap.Web.Donation1.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fiap.Web.Donation1.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new UsuarioModel());
        }


        [HttpPost]
        public IActionResult Index(UsuarioModel usuarioModel)
        {
            UsuarioModel usuarioRetorno = null;

            #region acessar-repositorio-usuario
            if (usuarioModel.Nome.Equals("Flavio") && usuarioModel.Email.Equals("fmoreni@gmail.com") ) {
                usuarioRetorno = new UsuarioModel()
                {
                    UsuarioId = 1,
                    Nome = "Flavio",
                    Email = "fmoreni@gmail.com"
                };
            }

            if (usuarioModel.Nome.Equals("Eduardo") && usuarioModel.Email.Equals("emoreni@gmail.com"))
            {
                usuarioRetorno = new UsuarioModel()
                {
                    UsuarioId = 2,
                    Nome = "Eduardo",
                    Email = "emoreni@gmail.com"
                };
            }
            #endregion

            // Se encontrou o usuario seguir os processos de login
            #region controlando-fluxo-login


            if ( usuarioRetorno != null)
            {
                var usuarioJson = JsonConvert.SerializeObject(usuarioRetorno);
                HttpContext.Session.SetString("UsuarioLogado", usuarioJson);

                HttpContext.Session.SetInt32("UsuarioId", usuarioRetorno.UsuarioId);
                HttpContext.Session.SetString("UsuarioNome", usuarioRetorno.Nome);

                return RedirectToAction("Index", "Home");
            } else
            {
                ViewBag.Mensagem = "Login incorreto";
                return View(usuarioModel);
            }
            #endregion

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
