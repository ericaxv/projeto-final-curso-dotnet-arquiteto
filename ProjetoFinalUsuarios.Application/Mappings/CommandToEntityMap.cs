using AutoMapper;
using ProjetoFinalUsuarios.Application.Commands;
using ProjetoFinalUsuarios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalUsuarios.Application.Mappings
{
    public class CommandToEntityMap : Profile
    {
        public CommandToEntityMap()
        {
            CreateMap<CreateUserCommand, User>()
            .AfterMap((command, entity) =>
            {
                entity.Id = Guid.NewGuid();
                entity.DataHoraCriacao = DateTime.Now;
            });
        }
    }
}
