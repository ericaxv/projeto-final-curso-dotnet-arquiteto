using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalUsuarios.Application.Commands;
using ProjetoFinalUsuarios.Application.Interfaces;

namespace ProjetoFinalUsuarios.Controllers
{ 
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost(), Route("api/users/login")]
        public ActionResult Login(AutenticarUserCommand command)
        {
            var model = _userAppService.AutenticarUsuario(command);
            return StatusCode(200, new 
            { 
                message = "Usuário Autenticado!",
                model 
            });
        }

        [HttpPost(), Route("api/users/create")]
        public ActionResult Create(CreateUserCommand command)
        {
            _userAppService.CriarUsuario(command);

            return StatusCode(201, new
            {
                message = "Usuário criado com sucesso.",
                command
            });
        }

        [HttpPost(), Route("api/users/password-recover")]
        public ActionResult PasswordRecover(PasswordRecoverCommand command)
        {
            var newPassword = _userAppService.RecoverPassword(command);
            return StatusCode(200, new
            {
                message = "Sua senha foi regerada!",
                newPassword
            });
        }
    }
}
