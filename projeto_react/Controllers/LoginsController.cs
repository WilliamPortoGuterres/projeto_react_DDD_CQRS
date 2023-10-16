using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using System.Security.Cryptography.X509Certificates;
using Application.Services;
using Domain.Commands;
using Application.Interfaces;
using Domain.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projeto_react.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class LoginsController : ControllerBase
    {

        private readonly ILoginService _service;

        public LoginsController(ILoginService service)
        {

            _service = service;
        }

        [HttpPost("Loga")]
        public async Task<JsonResult> Loga([FromBody] LoginQuery request)
        {


           var response =await _service.GetByLoginSenha(request);



            

            return new JsonResult(temp);
        }

       
        

    }
}
