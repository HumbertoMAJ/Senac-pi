using Aplicacao.Data;
using Aplicacao.Models;

namespace Aplicacao.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }


        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }


        public UsuarioModel Adicionar(UsuarioModel profi)
        {
            //gravar no banco de dados
            profi.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(profi);
            _bancoContext.SaveChanges();

            return profi;
        }

        public UsuarioModel Atualizar(UsuarioModel aleracao)
        {
            UsuarioModel ProfiDB = ListarPorId(aleracao.Id);

            if (ProfiDB == null) throw new System.Exception("Houve um erro da atualização do usuário");


            ProfiDB.Nome = aleracao.Nome;
            ProfiDB.Email = aleracao.Email;
            ProfiDB.Login = aleracao.Login;
            ProfiDB.Perfil = aleracao.Perfil;
            ProfiDB.DataAlteracao = DateTime.Now;
            //ProfiDB.Senha = aleracao.Senha;



            _bancoContext.Usuarios.Update(ProfiDB);
            _bancoContext.SaveChanges();

            return ProfiDB;
        }

        public bool Deletar(int id)
        {
            UsuarioModel ProfiDB = ListarPorId(id);

            if (ProfiDB == null) throw new System.Exception("Houve um erro na deleção do profissional!");


            _bancoContext.Usuarios.Remove(ProfiDB);
            _bancoContext.SaveChanges();

            return true;


        }

        
    }
}
