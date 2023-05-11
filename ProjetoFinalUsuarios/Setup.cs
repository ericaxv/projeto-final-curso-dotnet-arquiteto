using Microsoft.EntityFrameworkCore;
using ProjetoFinalUsuarios.Application.Interfaces;
using ProjetoFinalUsuarios.Application.Services;
using ProjetoFinalUsuarios.Domain.Interfaces.Repositories;
using ProjetoFinalUsuarios.Domain.Interfaces.Services;
using ProjetoFinalUsuarios.Domain.Services;
using ProjetoFinalUsuarios.Infra.Data.Contexts;
using ProjetoFinalUsuarios.Infra.Data.Repositories;
using ProjetoFinalUsuarios.Infra.Messages.Helpers;
using ProjetoFinalUsuarios.Infra.Messages.Producers;
using ProjetoFinalUsuarios.Infra.Messages.Settings;

namespace ProjetoFinalUsuarios
{
    public static class Setup
    {
        public static void AddRegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUserAppService, UserAppService>();

            builder.Services.AddTransient<IUserDomainService, UserDomainService>();

            builder.Services.AddTransient<IUserRepository, UserRepository>();
        } 
        public static void AddEntityFrameworkServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("CentralDeUsuarios");
            builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddMessageServices(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<MessageSettings>
                (builder.Configuration.GetSection("MessageSettings"));

            builder.Services.Configure<MailSettings>
                (builder.Configuration.GetSection("MailSettings"));

            builder.Services.AddTransient<MessageQueueProducer>();

            builder.Services.AddTransient<MailsHelpers>();

        }

        public static void AddAutoMapperServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
