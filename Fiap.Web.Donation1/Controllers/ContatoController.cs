﻿using Fiap.Web.Donation1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation1.Controllers
{
    public class ContatoController : BaseController
    {
        public ContatoController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Gravar(ContatoModel contatoModel)
        {
            string mensagem = string.Empty;

            if ( contatoModel.Email.Equals("fmoreni@gmail.com") )
            {
                mensagem = $"Contato do usuario {contatoModel.Nome} não registrado, pois já existe um contato aberto na plataforma";
            } else
            {
                mensagem = "Contato registrado com sucesso";
            }


            ViewBag.Mensagem = mensagem;

            return View("Sucesso");
        }



        [HttpGet]
        public IActionResult Help()
        {
            return View();
        }

    }
}
