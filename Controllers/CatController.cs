using CatMash.Helpers;
using CatMash.Models;
using CatMash.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatMash.Controllers
{
    [ApiController]
    [Route("/api/cat")]
    public class CatController : ControllerBase
    {
        readonly ICatQueryService _catQueryService;
        readonly IOptions<ConnectionString> _connectionString;

        public CatController(ICatQueryService catQueryService, IOptions<ConnectionString> connectionString)
        {
            _catQueryService = catQueryService;
            _connectionString = connectionString;
        }

        [HttpGet( "getAllCats" )]
        public async Task<IActionResult> GetAllCats()
        {
            using ( var ctx = DbHelper.CreateCtx( _connectionString.Value.Name ) )
            {
                return Ok( await _catQueryService.GetAllCatsAsync( ctx ) );
            }
        }

        [HttpPut( "vote" )]
        public async Task<IActionResult> PutVoteCat( string id )
        {
            using (var ctx = DbHelper.CreateCtx(_connectionString.Value.Name))
            {
                try
                {
                    await _catQueryService.UpdateCatScoreAsync(ctx, id);
                } catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return Ok();
            }
        }
    }
}
