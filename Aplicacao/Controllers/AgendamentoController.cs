using Aplicacao.Models;
using Aplicacao.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controllers
{
    public class AgendamentoController : Controller
    {


        private readonly IagendamentoRepositorio _agendamentoRepositorio;
        public AgendamentoController(IagendamentoRepositorio agendamentoRepositorio)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
        }

        public IActionResult Deletar(int id)
        {

            _agendamentoRepositorio.Deletar(id);

            return RedirectToAction("MeuAgendamento");
        }

        public IActionResult MeuAgendamento()
        {
            List<AgendarContext> agendar = _agendamentoRepositorio.BuscarTodos();
            return View(agendar);
        }

        public IActionResult Marcar()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult CriarAgendamento(AgendarContext agendar)
        {
            _agendamentoRepositorio.Adicionar(agendar);

            return RedirectToAction("Marcar");
        }


    }



}
