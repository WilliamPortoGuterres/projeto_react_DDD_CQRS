using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using System.Security.Cryptography.X509Certificates;
using Application.Services;
using Domain.Commands;
using Application.Interfaces;
using Domain.Queries;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projeto_react.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class LoginsController : ControllerBase
    {

        private readonly ILoginService _loginService;
        private readonly ICriptografiaService _criptografiaService;

        public LoginsController(ILoginService loginService,ICriptografiaService criptografiaService)
        {
            _criptografiaService = criptografiaService;
            _loginService = loginService;
        }

        [HttpPost("Loga")]
        public async Task<JsonResult> Loga([FromBody] LoginQuery request)
        {
            request.Password =await _criptografiaService.Criptografa(request.Password);



           var response =await _loginService.GetByLoginSenha(request);


            var mensage = response.IsNullOrEmpty() ? "usuario ou senha invalidos" : "autenticado com sucesso";

            var token = new { token = response,mensage  };
            return new JsonResult(token);
        }

       
        

    }
}
