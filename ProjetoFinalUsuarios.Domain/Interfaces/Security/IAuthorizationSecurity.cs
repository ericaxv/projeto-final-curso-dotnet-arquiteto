using ProjetoFinalUsuarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Domain.Interfaces.Security
{
    /// <summary>
    /// Interface para definir os métodos para geração de token do usuário.
    /// </summary>
    public interface IAuthorizationSecurity
    {
        /// <summary>
        /// Método para geração de token do usuário.
        /// </summary>
        /// <param name="user">Dados do usuário autenticado.</param>
        /// <returns>Token Jwt para o usuário.</returns>
        string CreateToken(User user);
    }
}
