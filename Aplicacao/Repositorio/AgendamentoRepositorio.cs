using Aplicacao.Data;
using Aplicacao.Models;

namespace Aplicacao.Repositorio
{
    public class AgendamentoRepositorio : IagendamentoRepositorio
    {
       
        private readonly BancoContext _bancoContext;
        public AgendamentoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public AgendarContext ListarPorId(int id)
        {
            return _bancoContext.Agendamento.FirstOrDefault(x => x.Id == id);
        }

        public bool Deletar(int id)
        {
            AgendarContext ProfiDB = ListarPorId(id);

            if (ProfiDB == null) throw new System.Exception("Houve um erro na deleção do profissional!");


            _bancoContext.Agendamento.Remove(ProfiDB);
            _bancoContext.SaveChanges();

            return true;


        }



        public List<AgendarContext> BuscarTodos()
        {
            return _bancoContext.Agendamento.ToList();
        }
        public AgendarContext Adicionar(AgendarContext agendar)
        {
            _bancoContext.Agendamento.Add(agendar);
            _bancoContext.SaveChanges();

            return agendar;
        }

        
    }
}
