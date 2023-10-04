using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using System.Security.Cryptography.X509Certificates;
using Application.Services;
using Domain.Commands;
using Application.Interfaces;

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
       

        // GET: api/<LoginsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginsController>
        [HttpPost("add")]
        public void Add([FromBody] CreateUserCommand request)
        {
           
            _service.createUser(request);
            
        }

        // PUT api/<LoginsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
