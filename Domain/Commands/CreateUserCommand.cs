using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class CreateUserCommand
    {
        public string Name { get; set; }
        
        public string Password { get; set; }
    }
}
