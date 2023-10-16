using Dapper;
using Domain.Queries;
using Infrastructure.Data.Entities;
using Infrastructure.Interfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Dapper
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Usuario> GetByLoginSenha(LoginQueryInfra login)
        {

            
            {
                _connection.Open();
                var response = await _connection.QueryFirstAsync <Usuario>("SELECT * FROM Usuarios WHERE Id = @login", new {login});


                return response;
            }

        }

    }
}
