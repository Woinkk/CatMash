using CatMash.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatMash.Controllers
{
    [ApiController]
    [Route("/api/cat")]
    public class CatController : ControllerBase
    {
        private IHttpClientFactory _httpClientFactory;
        public CatController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet( "getCatList" )]
        public async Task<IActionResult> GetCatList()
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                return Ok( await httpClient.GetAsync("https://latelier.co/data/cats.json") );
            }
        }
    }
}
