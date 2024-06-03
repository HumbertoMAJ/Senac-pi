using Aplicacao.Models;
using Aplicacao.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aplicacao.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProfissionalRepositorio _profissionalRepositorio;
        public HomeController(IProfissionalRepositorio profissionalRepositorio)
        {
            _profissionalRepositorio = profissionalRepositorio;
        }
        


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           ProfiModel listagem = _profissionalRepositorio.ListarPorId(id);
            return View(listagem);
        }

        public IActionResult Apagar(int id)// aqui é só a view
        {
            ProfiModel listagem = _profissionalRepositorio.ListarPorId(id);

            return View(listagem);
        }

        // crud acima


        public IActionResult Procurar()
        {
            List<ProfiModel> profis = _profissionalRepositorio.BuscarTodos();

            return View(profis);
        }
       /* public IActionResult Marcar()
        {
            return View();
        }*/

        public IActionResult Perfil()
        {
            return View();
        }

        /* public IActionResult MeuAgen()
         {

             return View();
         }*/

        //------
      
        public IActionResult Deletar(int id)
        {

            _profissionalRepositorio.Deletar(id);

            return RedirectToAction("Procurar");
        }


        [HttpPost]
        public IActionResult Criar(ProfiModel profi) // crud normal
        {
            _profissionalRepositorio.Adicionar(profi);

            return RedirectToAction("Procurar");
        }

        [HttpPost]
        public IActionResult Alterar(ProfiModel profi) // crud normal
        {
            _profissionalRepositorio.Atualizar(profi);

            return RedirectToAction("Procurar");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}