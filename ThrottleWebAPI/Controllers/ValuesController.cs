using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThrottleWebAPI.API;

namespace ThrottleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IApiService _apiService;

        public ValuesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public Task<string> Get()
        {
            return _apiService.DoWorkAsync("Work");
        }
    }
}
