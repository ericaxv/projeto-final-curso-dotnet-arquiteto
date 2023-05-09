using FluentValidation;
using ProjetoFinalUsuarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Domain.Validations
{
    /// <summary>
    /// Class para validação da entidade User.
    /// </summary>
    public class UserValidations : AbstractValidator<User>
    {
        public UserValidations()
        {
            RuleFor(u => u.Id)
                .NotEmpty()
                .WithMessage("Id é obrigatório.");

            RuleFor(u => u.Name)
                .NotEmpty()
                .Length(6, 150)
                .WithMessage("Nome de usuário inválido");

            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Endereço de email inválido.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .Length(8, 20)
                .WithMessage("Senha deve ter de 8 a 20 caracteres.")
                .Matches(@"[A-Z]+")
                .WithMessage("Senha deve ter pelo menos 1 letra maiúscula")
                .Matches(@"[a-z]+")
                .WithMessage("Senha deve ter pelo menos 1 letra minúscula")
                .Matches(@"[0-9]+")
                .WithMessage("Senha deve ter pelo menos 1 número")
                .Matches(@"[\!\?\*\.\@]+")
                .WithMessage("Senha deve ter pelo menos 1 caractere especial(!? *.@)");
        }
    }
}
