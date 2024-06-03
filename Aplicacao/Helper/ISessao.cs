using Aplicacao.Models;

namespace Aplicacao.Helper
{
    public interface ISessao
    {

        void CriarSessaoDoUsuario(UsuarioModel usuario);

        void RemoverSessaoUsuario();

        UsuarioModel BuscarSessaoDoUsuario();
    }
}
