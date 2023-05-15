using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using ProjetoFinalUsuarios.Infra.Security.Settings;
using Microsoft.Extensions.Options;
using ProjetoFinalUsuarios.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using ProjetoFinalUsuarios.Domain.Interfaces.Security;

namespace ProjetoFinalUsuarios.Infra.Security.Services
{
    /// <summary>
    /// Classe para implementar a geração do TOKEN JWT
    /// </summary>
    public class AuthorizationSecurity : IAuthorizationSecurity
    {
        private readonly JwtSettings _jwtSettings;
        public AuthorizationSecurity(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }
        public string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey.ToString());

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //gravar os dados do usuário no token
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name, user.Email),
                //identificação do usuário autenticado
                new Claim(ClaimTypes.Role, "USER")
                //perfil do usuário autenticado
                
             }),

                //definindo a data e hora de expiração
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpirationHours),

                //criptografar a chave antifalsificação no token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                     SecurityAlgorithms.HmacSha256Signature)
            
            
            };

            //retornando o token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
