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
            var responseQuery = new Usuario();

            try
            {
                _connection.Open();
                 responseQuery = await _connection.QueryFirstOrDefaultAsync<Usuario>("SELECT * FROM Usuario WHERE Name = @Name AND Password = @Password",
                   new { Name = login.Name, Password = login.Password });
                

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return new Usuario();
            }

            return responseQuery;


        }
        public async Task<bool> UserExists(string login)
        {
            var responseQuery = new Usuario();

            try
            {
                _connection.Open();
                 responseQuery = await _connection.QueryFirstOrDefaultAsync<Usuario>("SELECT * FROM Usuario WHERE Name = @Name",
                   new { Name = login, });
                

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return false;
            }
            

            return responseQuery!=null ;


        }

    }
}
