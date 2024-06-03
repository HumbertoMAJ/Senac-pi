using Aplicacao.Data;
using Aplicacao.Models;

namespace Aplicacao.Repositorio
{
    public class ProfissionalRepositorio : IProfissionalRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ProfissionalRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ProfiModel ListarPorId(int id)
        {
            return _bancoContext.Prdofissional.FirstOrDefault(x => x.Id == id);
        }

        public List<ProfiModel> BuscarTodos()
        {
            return _bancoContext.Prdofissional.ToList();
        }


        public ProfiModel Adicionar(ProfiModel profi)
        {
            //gravar no banco de dados
            _bancoContext.Prdofissional.Add(profi);
            _bancoContext.SaveChanges();

            return profi;
        }

        public ProfiModel Atualizar(ProfiModel aleracao)
        {
            ProfiModel ProfiDB = ListarPorId(aleracao.Id);

            if (ProfiDB == null) throw new System.Exception("Houve um erro da atualização da profissão");


            ProfiDB.Nome = aleracao.Nome;
            ProfiDB.Email = aleracao.Email;
            ProfiDB.Celular = aleracao.Celular;
            ProfiDB.Formacao = aleracao.Formacao;
            ProfiDB.Experiencia = aleracao.Experiencia;

            _bancoContext.Prdofissional.Update(ProfiDB);
            _bancoContext.SaveChanges();

            return ProfiDB;
        }

        public bool Deletar(int id)
        {
            ProfiModel ProfiDB = ListarPorId(id);

            if (ProfiDB == null) throw new System.Exception("Houve um erro na deleção do profissional!");


            _bancoContext.Prdofissional.Remove(ProfiDB);
            _bancoContext.SaveChanges();

            return true;


        }
    }
}
