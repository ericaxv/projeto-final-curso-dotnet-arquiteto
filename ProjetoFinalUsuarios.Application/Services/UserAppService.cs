using AutoMapper;
using FluentValidation;
using Newtonsoft.Json;
using ProjetoFinalUsuarios.Application.Commands;
using ProjetoFinalUsuarios.Application.Interfaces;
using ProjetoFinalUsuarios.Domain.Entities;
using ProjetoFinalUsuarios.Domain.Interfaces.Services;
using ProjetoFinalUsuarios.Infra.Messages.Models;
using ProjetoFinalUsuarios.Infra.Messages.Producers;
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
                Conteudo = JsonConvert.SerializeObject(user)
            };

            _messageQueueProducer.Create(_messageQueueModel);

        }
        public void Dispose()
        {
            _userDomainService.Dispose();
        }
    }
} 
    

       
    

