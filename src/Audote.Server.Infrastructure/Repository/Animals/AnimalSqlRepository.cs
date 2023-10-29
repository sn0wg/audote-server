using Audote.Server.Domain.Entities;
using Audote.Server.Infrastructure.Repository.Animals.Constants;
using Audote.Server.Infrastructure.Repository.Animals.Filters;
using Audote.Server.Infrastructure.Settings;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Audote.Server.Infrastructure.Repository.Animals
{
    internal class AnimalSqlRepository : IAnimalRepository
    {
        private readonly string _connectionString;

        public AnimalSqlRepository(IOptions<RepositorySettings> settings)
        {
            _connectionString = settings.Value.ConnectionString;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var query = new SqlBuilder()
                .Where(AnimalQueryConstants.ID_EQ_FILTER, new { Id = id })
                .AddTemplate(AnimalQueryConstants.DELETE_QUERY);

            return await connection.ExecuteAsync(query.RawSql, query.Parameters);
        }

        public async Task<Animal[]> Get(AnimalFilter animalFilter, CancellationToken cancellationToken)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var builder = new SqlBuilder();

            if (animalFilter.MinAge != null)
                builder = builder.Where(AnimalQueryConstants.AGE_GTE_FILTER, new { animalFilter.MinAge });

            if (animalFilter.MaxAge != null)
                builder = builder.Where(AnimalQueryConstants.AGE_LTE_FILTER, new { animalFilter.MaxAge });

            if (animalFilter.Active != null)
                builder = builder.Where(AnimalQueryConstants.ACTIVE_EQ_FILTER, new { animalFilter.Active });

            if (animalFilter.Kinds != null && animalFilter.Kinds.Length > 0)
                builder = builder.Where(AnimalQueryConstants.KIND_IN_FILTER, new { animalFilter.Kinds });

            if (animalFilter.Genders != null && animalFilter.Genders.Length > 0)
                builder = builder.Where(AnimalQueryConstants.GENDER_IN_FILTER, new { animalFilter.Genders });

            if (!string.IsNullOrEmpty(animalFilter.City))
                builder = builder.Where(AnimalQueryConstants.CITY_EQ_FILTER, new { animalFilter.City });

            if (!string.IsNullOrEmpty(animalFilter.State))
                builder = builder.Where(AnimalQueryConstants.STATE_EQ_FILTER, new { animalFilter.State });

            var selector = builder.AddTemplate(AnimalQueryConstants.SELECT_QUERY);

            var dataDictionary = new Dictionary<int, Animal>();

            await connection.QueryAsync<Animal, Picture, Animal>(selector.RawSql, (animal, picture) =>
            {
                if (!dataDictionary.ContainsKey(animal.Id))
                    dataDictionary.Add(animal.Id, animal);

                var item = dataDictionary[animal.Id];

                if (picture != null)
                    item.Pictures.Add(picture);

                return item;
            }, selector.Parameters);

            return dataDictionary.Values.ToArray();
        }

        public async Task<Animal?> GetById(int animalId, CancellationToken cancellationToken)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var selector = new SqlBuilder()
                .Where(AnimalQueryConstants.ID_EQ_FILTER, new { Id = animalId })
                .AddTemplate(AnimalQueryConstants.SELECT_QUERY);


            Animal? entity = null;

            await connection.QueryAsync<Animal, Picture, Animal>(selector.RawSql, (animal, picture) =>
            {
                entity ??= animal;

                if (picture != null)
                    entity.Pictures.Add(picture);

                return animal;
            }, selector.Parameters);

            return entity;
        }

        public async Task<int> Save(Animal animal, CancellationToken cancellationToken)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            return await connection.ExecuteAsync(AnimalQueryConstants.INSERT_QUERY,
                new
                {
                    animal.Name,
                    animal.Age,
                    animal.Kind,
                    animal.Gender,
                    animal.Active,
                    animal.Description,
                    animal.City,
                    animal.State
                });
        }

        public async Task<int> Update(Animal animal, CancellationToken cancellationToken)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var query = new SqlBuilder()
                .Where(AnimalQueryConstants.ID_EQ_FILTER, new { animal.Id })
                .Set(AnimalQueryConstants.NAME_SET_FIELD, new { animal.Name })
                .Set(AnimalQueryConstants.AGE_SET_FIELD, new { animal.Age })
                .Set(AnimalQueryConstants.KIND_SET_FIELD, new { animal.Kind })
                .Set(AnimalQueryConstants.GENDER_SET_FIELD, new { animal.Gender })
                .Set(AnimalQueryConstants.ACTIVE_SET_FIELD, new { animal.Active })
                .Set(AnimalQueryConstants.DESCRIPTION_SET_FIELD, new { animal.Description })
                .Set(AnimalQueryConstants.CITY_SET_FIELD, new { animal.City })
                .Set(AnimalQueryConstants.STATE_SET_FIELD, new { animal.State })
                .AddTemplate(AnimalQueryConstants.UPDATE_QUERY);

            return await connection.ExecuteAsync(query.RawSql, query.Parameters);
        }
    }
}
