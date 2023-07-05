using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpn.Dtos.User
{
    public class UserRegister
    {
        public string Username {get; set;} = string.Empty;
        public string password {get; set;} = string.Empty;
    }
}