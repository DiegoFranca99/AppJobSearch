using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppJobSearch.API.Services
{
    public class Service
    {
        protected HttpClient _client;
        protected string baseAPIUrl = "https://xamarinforms.azurewebsites.net";

        public Service()
        {
            _client = new HttpClient();
        }
    }
}
