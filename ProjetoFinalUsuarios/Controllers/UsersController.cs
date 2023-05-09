using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoFinalUsuarios.Controllers
{ 
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost(), Route("api/users/login")]
        public ActionResult Login()
        {
            return Ok("Login!");
        }

        [HttpPost(), Route("api/users/create")]
        public ActionResult Create()
        {
            return Ok("Create!");
        }

        [HttpPost(), Route("api/users/password-recover")]
        public ActionResult PasswordRecover()
        {
            return Ok("PasswordRecover!");
        }
    }
}
