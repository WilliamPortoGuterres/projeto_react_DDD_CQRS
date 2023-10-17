using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Domain.Interfaces;
using Domain.Queries;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository.Dapper;
using Infrastructure.Interfaces;

namespace Domain.Handlers
{
    public class UserHandle:IUserHandle
    {
        private readonly RebornLoginContext _context;
        private readonly IUserRepository _contextSecond;
        public UserHandle(RebornLoginContext context,IUserRepository contextSecond) {

            _context = context;
            _contextSecond = contextSecond;
        }
        
        public async Task<bool> handle(CreateUserCommand request) 
        {
            var usuario = new Usuario();
            
            usuario.Name = request.Name;
            usuario.Password = request.Password;

            await _context.Usuario.AddAsync(usuario);
           var result =  await _context.SaveChangesAsync();

            return result>0;

        }
        public Task<bool> handle(AutenticarCommand request)
        {
            return (Task<bool>)Task.CompletedTask;
        }

        public async Task<bool> handle(VerifyAccount request)
        {

            var userExists = await _contextSecond.UserExists(request.Name);

            return userExists;
        }

      
    }
}
