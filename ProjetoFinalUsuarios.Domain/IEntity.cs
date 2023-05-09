using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace ProjetoFinalUsuarios.Domain
{
    /// <summary>
    /// Interface para definir o tipo do id da entidade e validações.
    /// </summary>
    /// <typeparam name="TKey">Tipo do ID da entidade.</typeparam>
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }

        ValidationResult Validate { get; }
    }
}
