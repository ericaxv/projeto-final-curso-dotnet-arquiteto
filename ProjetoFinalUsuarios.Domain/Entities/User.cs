using FluentValidation.Results;
using ProjetoFinalUsuarios.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Domain.Entities
{
    public class User : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Password { get; set; }

        public DateTime DataHoraCriacao { get; set; }

        public ValidationResult Validate => new UserValidations().Validate(this);
    }
}
