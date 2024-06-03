using Aplicacao.Models;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options ) : base( options )
        {

        }

        public DbSet<AgendarContext> Agendamento { get; set; }

        public DbSet<ProfiModel> Prdofissional { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }


    }
}
