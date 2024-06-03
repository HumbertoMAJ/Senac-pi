using Aplicacao.Models;
using Aplicacao.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _UsuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _UsuarioRepositorio = usuarioRepositorio;
        }


        public IActionResult Index()
        {
            List<UsuarioModel> profis = _UsuarioRepositorio.BuscarTodos();

            return View(profis);
           
        }
        public IActionResult CriarLogin()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _UsuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }



        public IActionResult ApagarUsuario(int id)
        {

            UsuarioModel listagem = _UsuarioRepositorio.ListarPorId(id);

            return View(listagem);

        }

        [HttpPost]
        public IActionResult Alterar(UsuarioModel profi) // crud normal
        {
            _UsuarioRepositorio.Atualizar(profi);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel profi) // crud normal
        {
            _UsuarioRepositorio.Adicionar(profi);

            return RedirectToAction("Index");
        }

        public IActionResult Deletar(int id)
        {

            _UsuarioRepositorio.Deletar(id);

            return RedirectToAction("Index");
        }


    }



}
