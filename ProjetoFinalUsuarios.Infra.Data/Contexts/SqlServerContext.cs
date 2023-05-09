using Microsoft.EntityFrameworkCore;
using ProjetoFinalUsuarios.Domain.Entities;
using ProjetoFinalUsuarios.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Infra.Data.Contexts
{
    /// <summary>
    /// Classe de contexto para o banco de dados.
    /// </summary>
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> dbContextOptions) 
            : base(dbContextOptions)
        {
        }

        /// <summary>
        /// Adicionar classe de mapeamento.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        /// <summary>
        /// Propriedade para fornecer os métodos que serão
        /// utilizados no repositório de usuários
        /// </summary>
        public DbSet<User> User { get; set; }

    }
}
