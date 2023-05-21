using ProjetoFinalUsuarios.Domain.Entities;
using ProjetoFinalUsuarios.Domain.Interfaces.Repositories;
using ProjetoFinalUsuarios.Domain.Interfaces.Security;
using ProjetoFinalUsuarios.Domain.Interfaces.Services;
using ProjetoFinalUsuarios.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Domain.Services
{
    /// <summary>
    /// Classe para implementação da interface de serviços de usuário.
    /// </summary>
    public class UserDomainService : IUserDomainService
    {
        //atributos
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationSecurity _authorizationSecurity;
        /// <summary>
        /// Construtor para injeção de dependência
        /// </summary>
        public UserDomainService(IUnitOfWork unitOfWork,
        IAuthorizationSecurity authorizationSecurity)

        {
            _unitOfWork = unitOfWork;
            _authorizationSecurity = authorizationSecurity;
        }

        public AuthorizationModel AutenticarUsuário(string email, string password)
        {
            var user = _unitOfWork
                .userRepository
                .GetByEmailAndPassword(email, password);

            DomainException.When(user == null,
                "Acesso negado. Usuário não encontrado");

            return new AuthorizationModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                DataHoraAcesso = DateTime.Now,
                AccessToken = _authorizationSecurity.CreateToken(user)
            };
        }

        public void CreateUser(User user)
        {
            DomainException.When(
                _unitOfWork
                .userRepository
                .GetByEmail(user.Email) != null,
                     $"O email {user.Email} já está cadastrado no sistema, tente outro!");

            _unitOfWork.userRepository.Create(user);
        }

        public PasswordRecoverModel RecoverPassword(string email)
        {
            var user = _unitOfWork.userRepository.GetByEmail(email);
            if (user == null)
            {
                DomainException.When(user == null,
                    "Usuário não encontrado, Crie uma nova conta!");
            }

            string passwordRandom = PasswordGenerator.GeneratorRandomPassowrd();

            var userToUpdate = new User()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone= user.Phone,
                DataHoraCriacao = user.DataHoraCriacao,
                Password = passwordRandom
            };

            _unitOfWork.userRepository.Update(userToUpdate);

            return new PasswordRecoverModel 
            { 
                Password = passwordRandom
            };
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

     
    }
}

