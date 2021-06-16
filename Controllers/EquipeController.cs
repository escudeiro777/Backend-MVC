using System;
using EplayersMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EplayersMVC.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();

        [Route("Listar")]
        public IActionResult Index()
        {

            ViewBag.Equipes = equipeModel.LerTodasEquipes();
            return View();
        }
    [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.NomeEquipe = form["Nome"];
            novaEquipe.Imagem = form["Imagem"];
            equipeModel.CadastrarNovaEquipe(novaEquipe);

            ViewBag.Equipes = equipeModel.LerTodasEquipes();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}