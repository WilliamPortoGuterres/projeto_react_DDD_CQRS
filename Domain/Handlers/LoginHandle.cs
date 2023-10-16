using Domain.Interfaces;
using Domain.Queries;
using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class LoginHandle: ILoginHandle
    {
       
        private readonly IUserRepository _contextSecond;
        public LoginHandle( IUserRepository contextSecond)
        {          
            _contextSecond = contextSecond;
        }
        public async Task<Usuario> handle(LoginQuery request)
        {
            LoginQueryInfra loginQueryInfra = new LoginQueryInfra();

            loginQueryInfra.Name = request.Name;
            loginQueryInfra.Password = request.Password;

            var response = await _contextSecond.GetByLoginSenha(loginQueryInfra);

            return response;
        }
    }
}
