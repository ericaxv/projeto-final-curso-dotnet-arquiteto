using ProjetoFinalUsuarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para serviços de domínio de usuário.
    /// </summary>
    public interface IUserDomainService : IDisposable
    {
        /// <summary>
        /// Método para criar usuário
        /// </summary>
        /// <param name="user">Objeto User.</param>
        void CreateUser(User user);
    }
}
