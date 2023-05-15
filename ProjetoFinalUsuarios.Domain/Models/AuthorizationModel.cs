using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Domain.Models
{
    public class AuthorizationModel
    {
        /// <summary>
        /// Modelo de dados para o retorno da autenticação do usuário
        /// </summary>
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime DataHoraAcesso { get; set; }
        public string? AccessToken { get; set; }
       
    }
}
