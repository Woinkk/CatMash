using CatMash.Models;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace CatMash.Queries
{
    public interface ICatQueryService
    {
        public Task<IEnumerable<Cat>> GetAllCatsAsync( SQLiteConnection ctx );

        public Task UpdateCatScoreAsync( SQLiteConnection ctx, string id );
    }
}
