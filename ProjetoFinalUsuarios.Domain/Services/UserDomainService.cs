using ProjetoFinalUsuarios.Domain.Entities;
using ProjetoFinalUsuarios.Domain.Interfaces.Repositories;
using ProjetoFinalUsuarios.Domain.Interfaces.Services;
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
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Construtor para injeção de dependencia.
        /// </summary>
        /// <param name="userRepository"></param>
        public UserDomainService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            DomainException.When(
                _userRepository.GetByEmail(user.Email) != null,
                     $"O email {user.Email} já está cadastrado no sistema, tente outro!");
       
            _userRepository.Create(user);
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}
