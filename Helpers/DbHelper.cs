using Dapper;
using System.Data.SQLite;

namespace CatMash.Helpers
{
    public static class DbHelper
    {
        public static SQLiteConnection CreateCtx( string connectionString )
        {
            SQLiteConnection ctx;
            ctx = new SQLiteConnection( connectionString );
            return ctx;
        }

        public static void CreateTable(SQLiteConnection ctx)
        {
            string createTable = @"
                CREATE TABLE CatTable(
                    Id TEXT, 
                    Url TEXT, 
                    Score INTEGER
                );";

            ctx.Execute(createTable);
        }

        public static void InsertData(SQLiteConnection ctx, string id, string url)
        {
            ctx.Execute(@"
                INSERT INTO CatTable (Id, Url, Score) 
                VALUES( @Id, @Url, 0 );",
                new { Id = id, Url = url }
            );
        }
    }
}
