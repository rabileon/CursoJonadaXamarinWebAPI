using JornadaXamarin.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JornadaXamarin.MobileApp.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<(bool success, string token)> Login(LoginDTO loginDTO);
    }
}
