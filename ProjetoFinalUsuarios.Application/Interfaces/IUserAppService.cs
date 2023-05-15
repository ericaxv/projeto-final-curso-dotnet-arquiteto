using ProjetoFinalUsuarios.Application.Commands;
using ProjetoFinalUsuarios.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        /// <summary>
        /// Método para criar um usuário na aplicação
        /// </summary>
        /// <param name="command">Dados para criação do usuário</param>
        void CriarUsuario(CreateUserCommand command);

        AuthorizationModel AutenticarUsuario(AutenticarUserCommand command);

        /// <summary>
        /// Método para gerar nova senha
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>Nova senha gerada</returns>
        PasswordRecoverModel RecoverPassword(PasswordRecoverCommand command);
    }
}
