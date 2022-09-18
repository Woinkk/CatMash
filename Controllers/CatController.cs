using CatMash.Helpers;
using CatMash.Models;
using CatMash.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CatController> _logger;

        public CatController(
            ICatQueryService catQueryService, 
            IOptions<ConnectionString> connectionString, 
            ILogger<CatController> logger
        )
        {
            _catQueryService = catQueryService;
            _connectionString = connectionString;
            _logger = logger;
        }

        [HttpGet( "getAllCats" )]
        public async Task<IActionResult> GetAllCats()
        {
            using ( var ctx = DbHelper.CreateCtx( _connectionString.Value.Name ) )
            {
                var cats = await _catQueryService.GetAllCatsAsync(ctx);
                _logger.LogInformation("getAllCats query success.");
                return Ok(cats);
            }
        }

        [HttpPut( "vote" )]
        public async Task<IActionResult> PutVoteCat( [FromQuery] string id )
        {
            _logger.LogInformation("Cat score succesfully updated.");
            if (id != null)
            {
                using (var ctx = DbHelper.CreateCtx(_connectionString.Value.Name))
                {
                    try
                    {
                        await _catQueryService.UpdateCatScoreAsync(ctx, id);
                        _logger.LogInformation("Cat score succesfully updated.");
                        return Ok();
                    } catch (Exception e)
                    {
                        _logger.LogError(e, "Error occured while updating cat score.");
                        return StatusCode(500);
                    }
                }
            } else
            {
                _logger.LogError("Error query params id was null.");
                return BadRequest();
            }
        }
    }
}
