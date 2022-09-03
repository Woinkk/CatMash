using CatMash.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data.SQLite;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using CatMash.Helpers;
using Microsoft.Extensions.Options;

namespace CatMash.Services
{
    public class StartupService : IHostedService
    {
        readonly IServiceScopeFactory _serviceScopeFactory;
        readonly IOptions<ConnectionString> _connectionString;

        public StartupService(IServiceScopeFactory serviceScopeFactory, IOptions<ConnectionString> connectionString)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _connectionString = connectionString;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (File.Exists("database.db")) return;
            else
            {
                using ( var ctx = DbHelper.CreateCtx( _connectionString.Value.Name ) )
                {
                    // Get all cats and add them to the DB.

                    DbHelper.CreateTable(ctx);

                    using (var scope = _serviceScopeFactory.CreateScope() )
                    {
                        var httpClientFactory = scope.ServiceProvider.GetService<IHttpClientFactory>(); 
                        
                        using (var httpClient = httpClientFactory.CreateClient())
                        {
                            HttpResponseMessage response = await httpClient.GetAsync("https://latelier.co/data/cats.json");

                            string responseAsString = await response.Content.ReadAsStringAsync();

                            CatList cats = JsonConvert.DeserializeObject<CatList>(responseAsString);    

                            foreach( Cat cat in cats.Images)
                            {
                                DbHelper.InsertData(ctx, cat.Id, cat.Url);
                            }
                        }
                        return;
                    }

                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
