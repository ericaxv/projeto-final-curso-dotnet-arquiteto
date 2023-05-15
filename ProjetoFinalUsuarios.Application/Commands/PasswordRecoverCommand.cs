using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Application.Commands
{
    /// <summary>
    /// Modelo para criação de nova senha.
    /// </summary>
    public class PasswordRecoverCommand
    {
        public string Email { get; set; }
    }
}
