using Microsoft.EntityFrameworkCore;
using ProjetoFinalUsuarios.Infra.Data.Contexts;

namespace ProjetoFinalUsuarios
{
    public static class Setup
    {
        public static void AddEntityFrameworkServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("CentralDeUsuarios");
            builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
