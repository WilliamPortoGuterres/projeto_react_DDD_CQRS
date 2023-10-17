using Application.Interfaces;
using Domain.Commands;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;


namespace projeto_react.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController:ControllerBase
    {

        private readonly IUsuarioService _service;
        private readonly ICriptografiaService _criptografiaService;
        public UsuarioController(IUsuarioService service, ICriptografiaService criptografiaService)
        {

            _service = service;
            _criptografiaService = criptografiaService;
        }






        [HttpPost("add")]
        public async Task<JsonResult> Add([FromBody] CreateUserCommand request)
        {


            VerifyAccount verifyAccount = new VerifyAccount();

            verifyAccount.Name = request.Name;

            var existe = await _service.VerifyAccount(verifyAccount);


            if (!existe)
            {

                request.Password = await _criptografiaService.Criptografa(request.Password);

                var resultado = await _service.CreateUser(request);


                var respostaPositiva = new {mensagem="Usuário criado com sucesso!",
                sucesso=true};

                return new JsonResult(respostaPositiva);

            }

            var respostaNegativa = new
            {
                mensagem = "Usuário não foi criado pois ja existe!",
                sucesso = false
            };

            return new JsonResult(respostaNegativa);
        }

    }
}
