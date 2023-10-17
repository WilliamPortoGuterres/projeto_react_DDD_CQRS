using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CriptografiaService : ICriptografiaService
    {
        private readonly ICriptografiaHandle _Handle;
       public CriptografiaService(ICriptografiaHandle Handle) 
        {
            _Handle = Handle;
        }   
        public async Task<string> Criptografa(string password)
        {
            return await _Handle.Handle(password);
        }
    }
}
