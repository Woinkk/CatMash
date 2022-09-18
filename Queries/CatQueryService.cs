using CatMash.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace CatMash.Queries
{
    public class CatQueryService : ICatQueryService
    {
        public async Task<IEnumerable<Cat>> GetAllCatsAsync( SQLiteConnection ctx )
        {
            return await ctx.QueryAsync<Cat>(@"SELECT * FROM CatTable ORDER BY Score DESC;");
        }

        public async Task UpdateCatScoreAsync(SQLiteConnection ctx, string id)
        {
            int score = await ctx.QueryFirstAsync<int>(@"SELECT Score FROM CatTable WHERE Id = @Id;", new { Id = id });

            score++;

            await ctx.ExecuteAsync(@"
                UPDATE CatTable
                SET Score = @Score
                WHERE Id = @Id;
            ", new { Id = id, Score = score } );
        }
    }
}
