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

namespace CatMash.Services
{
    public class StartupService : IHostedService
    {
        private IServiceScopeFactory _serviceScopeFactory;

        public StartupService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (File.Exists("database.db")) return;
            else
            {
                using (var conn = CreateDatabase())
                {
                    // Get all cats and add them to the DB.

                    CreateTable(conn);

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
                                InsertData(conn, cat.Id, cat.Url);
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

        static SQLiteConnection CreateDatabase()
        {

            SQLiteConnection sqliteConn;
            sqliteConn = new SQLiteConnection( @"Data Source = database.db; Version = 3; New = True; Compress = True;");

            // Open the connection:
            try
            {
                sqliteConn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqliteConn;
        }

        static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqliteCmd;
            string CreateTable = @"
                CREATE TABLE CatTable(
                    Id TEXT, 
                    Url TEXT, 
                    Score INTEGER
                );";
            sqliteCmd = conn.CreateCommand();
            sqliteCmd.CommandText = CreateTable;
            sqliteCmd.ExecuteNonQuery();
        }

        static void InsertData(SQLiteConnection conn, string id, string url)
        {
            SQLiteCommand sqliteCmd;
            sqliteCmd = conn.CreateCommand();
            sqliteCmd.CommandText = @$"
                INSERT INTO CatTable (Id, Url, Score) 
                VALUES( '{id}', '{url}', 0 );";
            sqliteCmd.ExecuteNonQuery();
        }

        //static void ReadData(SQLiteConnection conn)
        //{
        //    SQLiteDataReader sqliteDataReader;
        //    SQLiteCommand sqliteCmd;
        //    sqliteCmd = conn.CreateCommand();
        //    sqliteCmd.CommandText = @"SELECT * FROM CatTable";

        //    sqliteDataReader = sqliteCmd.ExecuteReader();
        //    while (sqliteDataReader.Read())
        //    {
        //        string myreader = sqliteDataReader.GetString(0);
        //        Console.WriteLine(myreader);
        //    }
        //    conn.Close();
        //}
    }
}
