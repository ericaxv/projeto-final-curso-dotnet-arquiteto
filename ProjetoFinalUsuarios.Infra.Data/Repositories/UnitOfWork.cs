using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _sqlServerContext;
        private IDbContextTransaction _dbContextTransaction;

        public UnitOfWork(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }
        public void BeginTransaction()
        {
            _dbContextTransaction = _sqlServerContext.Database.BeginTransaction();
        }
        public void Commit()
        {
            _dbContextTransaction.Commit();
        }
        public void RollBack()
        {
            _dbContextTransaction.Rollback();
        }
        public IUsuarioRepository UsuarioRepository
            => new UsuarioRepository(_sqlServerContext);
        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }
    }
}
