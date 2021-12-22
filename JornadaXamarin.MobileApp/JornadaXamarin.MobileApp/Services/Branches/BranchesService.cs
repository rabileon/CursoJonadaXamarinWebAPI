using JornadaXamarin.MobileApp.Models;
using JornadaXamarin.MobileApp.Services.Base;
using JornadaXamarin.MobileApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace JornadaXamarin.MobileApp.Services.Branches
{
    public class BranchesService : BaseRestService, IBranchesService
    {
        public BranchesService(string token) : base(token)
        {

        }
        public async Task<IEnumerable<BranchDTO>> GetBranches()
        {
            Init();

            var branches = await httpClient.GetFromJsonAsync<IEnumerable<BranchDTO>>
                (AppBase.Constants.MyAppBooksService.BRANCHES);
            return branches;
        }
    }
}
