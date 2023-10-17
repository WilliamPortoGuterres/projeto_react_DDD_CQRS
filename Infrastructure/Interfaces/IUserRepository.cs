﻿using Domain.Queries;
using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        public Task<Usuario> GetByLoginSenha(LoginQueryInfra login );
        public Task<bool> UserExists(string login );
    }
}
