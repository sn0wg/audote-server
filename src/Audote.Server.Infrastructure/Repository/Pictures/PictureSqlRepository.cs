using Audote.Server.Domain.Entities;
using Audote.Server.Infrastructure.Repository.Pictures.Constants;
using Audote.Server.Infrastructure.Settings;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Audote.Server.Infrastructure.Repository.Pictures
{
    internal class PictureSqlRepository : IPictureRepository
    {
        private readonly string _connectionString;

        public PictureSqlRepository(IOptions<RepositorySettings> settings)
        {
            _connectionString = settings.Value.ConnectionString;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var query = new SqlBuilder()
                .Where(PictureQueryConstants.ID_EQ_FILTER, new { Id = id })
                .AddTemplate(PictureQueryConstants.DELETE_QUERY);

            return await connection.ExecuteAsync(query.RawSql, query.Parameters);
        }

        public async Task<Picture?> GetById(int id, CancellationToken cancellationToken)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var selector = new SqlBuilder()
                .Where(PictureQueryConstants.ID_EQ_FILTER, new { Id = id })
                .AddTemplate(PictureQueryConstants.SELECT_QUERY);

            return await connection.QuerySingleOrDefaultAsync<Picture>(selector.RawSql, selector.Parameters);
        }

        public async Task<int> Save(Picture picture, CancellationToken cancellationToken)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            return await connection.ExecuteScalarAsync<int>(PictureQueryConstants.INSERT_QUERY,
                new
                {
                    picture.Description,
                    picture.Path,
                    picture.ContentType,
                    picture.AnimalId
                });
        }
    }
}
