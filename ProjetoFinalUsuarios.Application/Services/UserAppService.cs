using AutoMapper;
using FluentValidation;
using Newtonsoft.Json;
using ProjetoFinalUsuarios.Application.Commands;
using ProjetoFinalUsuarios.Application.Interfaces;
using ProjetoFinalUsuarios.Domain.Entities;
using ProjetoFinalUsuarios.Domain.Interfaces.Services;
using ProjetoFinalUsuarios.Domain.Models;
using ProjetoFinalUsuarios.Infra.Messages.Models;
using ProjetoFinalUsuarios.Infra.Messages.Producers;
using ProjetoFinalUsuarios.Infra.Messages.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService _userDomainService;
        private readonly MessageQueueProducer _messageQueueProducer;
        private readonly IMapper _mapper;

        public UserAppService(IUserDomainService userDomainService,
            MessageQueueProducer messageQueueProducer,
            IMapper mapper)
        {
            _userDomainService = userDomainService;
            _messageQueueProducer = messageQueueProducer;
            _mapper = mapper;
        }

        public AuthorizationModel AutenticarUsuario(AutenticarUserCommand command)
        { 
            var autenticacao = _userDomainService
                .AutenticarUsuário(command.Email, command.Password);

            return new AuthorizationModel(){
                Id = autenticacao.Id,
                Name = autenticacao.Name, 
                Email = autenticacao.Email,
                DataHoraAcesso = autenticacao.DataHoraAcesso,
                AccessToken= autenticacao.AccessToken
            };
        }

        public void CriarUsuario(CreateUserCommand command)
        {
            var user = _mapper.Map<User>(command);

            var validate = user.Validate;

            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }

            _userDomainService.CreateUser(user);

            var _messageQueueModel = new MessageQueueModel
            {
                Tipo = TipoMensagem.CONFIRMACAO_DE_CADASTRO,
                Conteudo = JsonConvert.SerializeObject(new UserMessageVO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email= user.Email
                })
            };

            _messageQueueProducer.Create(_messageQueueModel);

        }

        public PasswordRecoverModel RecoverPassword(PasswordRecoverCommand command)
        {
            var newPassword = _userDomainService.RecoverPassword(command.Email);
            return new PasswordRecoverModel 
            { 
                Password = newPassword.Password 
            };
        }
        public void Dispose()
        {
            _userDomainService.Dispose();
        }

    
    }
} 
    

       
    

