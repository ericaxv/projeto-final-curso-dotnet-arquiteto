using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Application.Commands
{
    public class AutenticarUserCommand
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
