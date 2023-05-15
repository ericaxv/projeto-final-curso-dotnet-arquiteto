using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Infra.Security.Settings
{
    public class JwtSettings
    {
        public string? SecretKey { get; set; }

        public int ExpirationHours { get; set; }
    }
}
