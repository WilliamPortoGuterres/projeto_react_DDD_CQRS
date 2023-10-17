using Domain.Interfaces;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class CriptografiaHandle : ICriptografiaHandle

    {
        
            
        public async  Task<string> Handle(string password)
        {
           
                byte[] hashBytes;

                using (MD5 md5 = MD5.Create())
                {
                    hashBytes = await Task.Run(() => md5.ComputeHash(Encoding.UTF8.GetBytes(password)));
                }

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sBuilder.Append(hashBytes[i].ToString("x2"));
                }


                return sBuilder.ToString();
            
        }
    }
}
