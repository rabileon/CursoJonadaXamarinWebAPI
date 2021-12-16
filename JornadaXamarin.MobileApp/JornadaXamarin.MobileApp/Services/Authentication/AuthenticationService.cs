using JornadaXamarin.MobileApp.AppBase.Constants;
using JornadaXamarin.MobileApp.Models;
using JornadaXamarin.MobileApp.Services.Base;
using JornadaXamarin.MobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace JornadaXamarin.MobileApp.Services.Authentication
{
    public class AuthenticationService : BaseRestService, IAuthenticationService
    {
        public AuthenticationService()
        {

        }
        public async Task<(bool success, string token)> Login(LoginDTO loginDTO)
        {
            Init();

            using var response = await httpClient.PostAsJsonAsync(MyAppBooksService.LOGIN, loginDTO);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                return (true, token);
            }

            return (false, string.Empty);
        }
    }
}
