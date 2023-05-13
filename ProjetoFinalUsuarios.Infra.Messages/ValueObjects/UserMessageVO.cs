using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Infra.Messages.ValueObjects
{
    public class UserMessageVO
    {
        /// <summary>
        /// Objeto de valor para gravar dados de usuário na mensagem da fila
        /// </summary>
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
