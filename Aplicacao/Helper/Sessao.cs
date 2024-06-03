using Aplicacao.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Aplicacao.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string seccaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(seccaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(seccaoUsuario);
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
