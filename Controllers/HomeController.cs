using Microsoft.AspNetCore.Mvc;
using MockAPI.Auth;
using MockAPI.Models;
using MockAPI.Responses;

namespace MockAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
     

        [HttpPost(Name = "HomeController")]
        public ActionResult<Home> Index([FromBody] RequestModel request)
        {
            if (request.User != AuthConstants.AuthorizedUser || request.Password != AuthConstants.Password || request.Tag != AuthConstants.Tag)
            {
                var errorResponse = new ErrorResponse
                {
                    Error = ErrorResponses.AuthError,
                    Message = ErrorResponses.AuthMsg
                };
                return StatusCode(401, errorResponse); // Retorna a resposta de erro personalizada
            }

            var home = new Home()
            {
                Message = HomeResponse.Message,
                KeyCode = HomeResponse.KeyCode,
            };
            return Ok(home);
        }
    }

  
}