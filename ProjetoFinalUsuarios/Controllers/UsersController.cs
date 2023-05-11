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
        public ActionResult Login()
        {
            return Ok("Login!");
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
        public ActionResult PasswordRecover()
        {
            return Ok("PasswordRecover!");
        }
    }
}
