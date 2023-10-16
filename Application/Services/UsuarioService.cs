using Application.Interfaces;
using Domain.Commands;
using Domain.Interfaces;
using Domain.Queries;
using Infrastructure.Data.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
     public class UsuarioService:IUsuarioService
    {
        private readonly IUserRepository _userRepository;
        private IUserHandle _handler;
     
        public UsuarioService(IUserRepository userRepository, IUserHandle handler) 
        { 
        _userRepository = userRepository;
            _handler = handler;
        }
        

       
        public async Task<bool> CreateUser(CreateUserCommand request)
        {


            var registrou = await _handler.handle(request);
            return registrou;

        }

        public async Task<bool> VerifyAccount(VerifyAccount request)
        {


            var response = await _handler.handle(request);

            return response;
        }
    }
}
