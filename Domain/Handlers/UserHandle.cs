using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Domain.Interfaces;

namespace Domain.Handlers
{
    public class UserHandle:IUserHandle
    {
        private readonly RebornLoginContext _context;
        public UserHandle(RebornLoginContext context) {

            _context = context;
        }
        
        public void handle(CreateUserCommand request) 
        {
            var newusuario = new Usuario();
            
            newusuario.Name = request.Name;
            newusuario.Password = request.Password;

            _context.Usuario.Add(newusuario);

        
        }
        public void handle(AutenticarCommand request) { }


    }
}
