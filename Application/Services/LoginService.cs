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
        private IAutenticarTokenService _Token;
        public LoginService(ILoginHandle handler, IAutenticarTokenService token)
        {
            _handler = handler;
            _Token = token;
        }



        public async Task<string> GetByLoginSenha(LoginQuery login)
        {
            var resultado = await _handler.handle(login);

            string response = "";

            if (resultado != null)
            {

                var name = resultado.Name;

                response = _Token.GerarToken(name);

            }
            else
            {
                response = "";
            }

            return response;
        }



    }
}
