using Application.DTOs;
using Domain.Commands;
using Domain.Queries;
using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces
{
    public interface ILoginService
    {
        Task<string> GetByLoginSenha(LoginQuery login);
        

    }
}
