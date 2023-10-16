using Domain.Commands;
using Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserHandle
    {
        public Task<bool> handle(CreateUserCommand request);
        public Task<bool> handle(AutenticarCommand request);
        public Task<bool> handle(VerifyAccount request);
       
    }
}
