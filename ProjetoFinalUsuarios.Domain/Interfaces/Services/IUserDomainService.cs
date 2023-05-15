using ProjetoFinalUsuarios.Domain.Entities;
using ProjetoFinalUsuarios.Domain.Models;
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

        /// <summary>
        /// Método para realizar autenticação do usuário. 
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        AuthorizationModel AutenticarUsuário(string email, string password);

        /// <summary>
        /// Método para gerar nova senha
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>Nova senha gerada</returns>
        PasswordRecoverModel RecoverPassword(string email);
    }
}
