using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjetoFinalUsuarios.Application.Interfaces;
using ProjetoFinalUsuarios.Application.Services;
using ProjetoFinalUsuarios.Domain.Interfaces.Repositories;
using ProjetoFinalUsuarios.Domain.Interfaces.Security;
using ProjetoFinalUsuarios.Domain.Interfaces.Services;
using ProjetoFinalUsuarios.Domain.Services;
using ProjetoFinalUsuarios.Infra.Data.Contexts;
using ProjetoFinalUsuarios.Infra.Data.Repositories;
using ProjetoFinalUsuarios.Infra.Messages.Helpers;
using ProjetoFinalUsuarios.Infra.Messages.Producers;
using ProjetoFinalUsuarios.Infra.Messages.Settings;
using ProjetoFinalUsuarios.Infra.Security.Services;
using ProjetoFinalUsuarios.Infra.Security.Settings;
using System.Text;

namespace ProjetoFinalUsuarios
{
    public static class Setup
    {
        public static void AddRegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUserAppService, UserAppService>();

            builder.Services.AddTransient<IUserDomainService, UserDomainService>();

            builder.Services.AddTransient<IUserRepository, UserRepository>();

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
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

        public static void AddJwtBearerSecurity(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<JwtSettings>
                (builder.Configuration.GetSection("JwtSettings"));
            builder.Services.AddTransient
                <IAuthorizationSecurity, AuthorizationSecurity>();

            builder.Services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
                bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;

                    bearer.TokenValidationParameters
                    = new TokenValidationParameters

                    {
                        ValidateIssuerSigningKey = true,

                        IssuerSigningKey = new SymmetricSecurityKey(

                    Encoding.ASCII.GetBytes(builder.Configuration
                            .GetSection("JwtSettings")
                            .GetSection("SecretKey").Value)
                    ),
                        ValidateIssuer = false,
                        ValidateAudience = false,

                    };
                });
        }

        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",

                    Title = "API - Usuários",

                    Description = "API REST para controle de usuários. " +
                                 "Treinamento C# Avançado Formação Arquiteto - COTI Informática",
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the " +
                                  "Bearer scheme.Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme

                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },

                        new List<string>()

                    }
                });
            });
        }
    }
}

