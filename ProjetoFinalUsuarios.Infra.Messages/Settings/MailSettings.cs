using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Infra.Messages.Settings
{
    /// <summary>
    /// Configurações para o servidor de email.
    /// </summary>
    public class MailSettings
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Smtp { get; set; }
        public int? Port { get; set; }
    }
}
