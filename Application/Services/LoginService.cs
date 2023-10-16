using Application.DTOs;
using Application.Interfaces;
using Domain.Commands;
using Domain.Handlers;
using Domain.Interfaces;
using Domain.Queries;
using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services
{
    public class LoginService:ILoginService

    {
        private ILoginHandle _handler;
        public LoginService(ILoginHandle handler)
        {
            _handler = handler;
        }



        public async Task<Usuario> GetByLoginSenha(LoginQuery login)
        {
            var resultado = await _handler.handle(login);

            return resultado;
        }



    }
}
