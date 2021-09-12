using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDBDEMO.Business.Entities;
using System;

namespace MongoDBDEMO.Data
{
    public class PessoaMongoDbCollection
    {
        private readonly IMongoDatabase Db;
        public IMongoCollection<Pessoa> Pessoas { get; private set;}

        public PessoaMongoDbCollection(IConfiguration configuration)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration.GetConnectionString("MongoDocker")));
                var client = new MongoClient(settings);
                Db = client.GetDatabase(configuration["NomeBanco"]);
                MapClasses();
            }
            catch (Exception ex)
            {
                throw new MongoException("Não foi possível se conectar ao mongoDB", ex);
            }

            Pessoas = Db.GetCollection<Pessoa>(typeof(Pessoa).Name.ToLower());
        }

        private void MapClasses()
        {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            if (!BsonClassMap.IsClassMapRegistered(typeof(Pessoa)))
            {
                BsonClassMap.RegisterClassMap<Pessoa>(i =>
                {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}
