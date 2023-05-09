using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Application.Commands
{
    /// <summary>
    /// Classe modelos para transferencia de dados para cadastro do usuário.
    /// </summary>
    public class CreateUserCommand
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }

    }
}
