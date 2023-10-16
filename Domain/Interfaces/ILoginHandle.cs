using Domain.Queries;
using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILoginHandle
    {
        Task<Usuario> handle(LoginQuery request);
    }
}
