using Aplicacao.Models;

namespace Aplicacao.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel profi);
        UsuarioModel Atualizar(UsuarioModel aleracao);
        bool Deletar(int id);
    }
}
