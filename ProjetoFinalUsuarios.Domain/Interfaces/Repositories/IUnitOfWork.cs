using ProjetoFinalUsuarios.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Unidade de trabalho do repositório
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
         void BeginTransaction();
         void Commit();
         void Rollback();
         IUserRepository userRepository { get; }    
    }
}
