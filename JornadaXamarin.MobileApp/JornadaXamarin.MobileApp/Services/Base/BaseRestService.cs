using JornadaXamarin.MobileApp.AppBase.Constants;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace JornadaXamarin.MobileApp.Services.Base
{
    public abstract class BaseRestService
    {
        protected static HttpClient httpClient;
        protected static string token;

        public BaseRestService()
        {
        }
        public BaseRestService(string token)
        {
            BaseRestService.token = token;
        }

        public static void Init()
        {
            if (httpClient is null)
            {
                httpClient = new();
                httpClient.Timeout = TimeSpan.FromSeconds(80);
                httpClient.BaseAddress = new(MyAppBooksService.API_ENDPOINT);

            }

            if (!string.IsNullOrWhiteSpace(token)
                && !httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {

                httpClient.DefaultRequestHeaders.Authorization = new("bearer", token);
            }
        }
    }
}
