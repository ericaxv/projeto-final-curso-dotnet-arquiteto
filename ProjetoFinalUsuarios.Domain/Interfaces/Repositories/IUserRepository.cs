using ProjetoFinalUsuarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface de repositório para entidade User.
    /// </summary>
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
        /// <summary>
        /// Método para consultar um usuário a partir do Email.
        /// </summary>
        /// <param name="email">Email do usuário.</param>
        /// <returns>Um usuário.</returns>
        User GetByEmail(string email);

        /// <summary>
        /// Método para consultar usuário por email e senha.
        /// </summary>
        /// <param name="email">Email do usuário a ser consultado.</param>
        /// <param name="password">Senha do usuário consultado.</param>
        /// <returns></returns>
        User GetByEmailAndPassword(string email, string password);
    }
}
