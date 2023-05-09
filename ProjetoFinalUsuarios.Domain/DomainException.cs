using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string errorMessage) 
            : base(errorMessage)
        {  
        }

        /// <summary>
        /// Método para testar uma condição de erro e disparar uma exceção.
        /// </summary>
        /// <param name="hasError">Condição para disparar o erro.</param>
        /// <param name="errorMessage">Mensagem de erro.</param>
        /// <exception cref="DomainException"></exception>
        public static void When(bool hasError, string errorMessage)
        {
            if (hasError)
                throw new DomainException(errorMessage);
        }
    }
}
