using Application.DTOs;
using Application.Interfaces;
using Domain.Commands;
using Domain.Handlers;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services
{
    public class LoginService:ILoginService

    {
        private IUserHandle _handler;
        public LoginService(IUserHandle handler)
        {
            _handler = handler;
        }

        public void createUser(CreateUserCommand request)
        {


            _handler.handle(request);
       
        }
    }
}
