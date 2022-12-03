using BalanceFinanciero.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceFinanciero.Repository.Repositories
{
    public class RubroRepository : IRubroRepository
    {
        private PostgresConfiguration _pgConfiguration;

        public RubroRepository(PostgresConfiguration connString) => _pgConfiguration = connString;

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_pgConfiguration.ConnectionString);
        }

        public async Task<bool> Delete(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM public.rubro
                        WHERE rub_id = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        public async Task<IEnumerable<Rubro>> GetAll()
        {
            var db = dbConnection();

            var sql = @"SELECT rub_id id, title, description 
                        FROM public.rubro";

            return await db.QueryAsync<Rubro>(sql, new { });
        }

        public async Task<Rubro> GetSingle(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT rub_id, title, description 
                        FROM public.rubro 
                        WHERE rub_id = @Id";

            return await db.QueryFirstOrDefaultAsync<Rubro>(sql, new { Id = id });
        }

        public async Task<bool> Insert(Rubro rubro)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO public.rubro (title, description) 
                        VALUES (@Title, @Description)";

            var result = await db.ExecuteAsync(sql, new { rubro.Title, rubro.Description});
            return result > 0;
        }

        public async Task<bool> Update(Rubro rubro)
        {
            var db = dbConnection();

            var sql = @"UPDATE public.rubro
                        SET title = @Title, description = @Description
                        WHERE rub_id = @Id";

            var result = await db.ExecuteAsync(sql, new { rubro.Title, rubro.Description, rubro.Id });
            return result > 0;
        }
    }
}
