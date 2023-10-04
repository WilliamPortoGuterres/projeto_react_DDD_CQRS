using Microsoft.AspNetCore.Mvc;
using projeto_react.Aplication.DTOs;

namespace projeto_react.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {


        [HttpPost("Add")]   
        public string Add( [FromBody]ObjLogin login)
        {
            try
            {
                return "RedirectToAction(nameof(Index))";
            }
            catch
            {
                return "RedirectToAction(nameof(Index))";
            }
        }

       
    }
}
