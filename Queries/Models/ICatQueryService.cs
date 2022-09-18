using CatMash.Models;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace CatMash.Queries
{
    public interface ICatQueryService
    {
        /// <summary>
        /// Return all cats from database.
        /// </summary>
        /// <param name="ctx">Sql connection.</param>
        /// <returns>IEnumerable of Cat</returns>
        public Task<IEnumerable<Cat>> GetAllCatsAsync( SQLiteConnection ctx );

        /// <summary>
        /// Update cat score by id.
        /// </summary>
        /// <param name="ctx">Sql connection.</param>
        /// <param name="id">Cat id.</param>
        public Task UpdateCatScoreAsync( SQLiteConnection ctx, string id );
    }
}
