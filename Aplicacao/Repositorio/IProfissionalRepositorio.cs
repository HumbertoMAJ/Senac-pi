using Aplicacao.Models;

namespace Aplicacao.Repositorio
{
    public interface IProfissionalRepositorio
    {
       
        ProfiModel ListarPorId(int id);
        List<ProfiModel> BuscarTodos();
        ProfiModel Adicionar(ProfiModel profi);
        ProfiModel Atualizar(ProfiModel aleracao);
        bool Deletar(int id);
    }
}
