using Aplicacao.Models;

namespace Aplicacao.Repositorio
{
    public interface IagendamentoRepositorio
    {
        AgendarContext ListarPorId(int id);
        List<AgendarContext> BuscarTodos();
        AgendarContext Adicionar(AgendarContext agendar);
        bool Deletar(int id);
    }
}
