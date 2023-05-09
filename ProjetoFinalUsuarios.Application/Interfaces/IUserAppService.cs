using ProjetoFinalUsuarios.Application.Commands;
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
    }
}
