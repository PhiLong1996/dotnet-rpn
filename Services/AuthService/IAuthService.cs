using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpn.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register (User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}