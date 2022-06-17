using DemoGraphQL.Application.Configurations;
using DemoGraphQL.Application.Data.Entities;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace DemoGraphQL.Application.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Category> Categories { get; }
        IMongoCollection<Product> Products { get; }
    }

    public class CatalogContext : ICatalogContext
    {
        private const string ProductCollectionName = "Products";
        private const string CategoryCollectionName = "Categories";

        public CatalogContext(IOptions<MongoDbConfiguration> dbOptions)
        {
            var settings = dbOptions.Value;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);

            this.Categories = database.GetCollection<Category>(CategoryCollectionName);
            this.Products = database.GetCollection<Product>(ProductCollectionName);

            CatalogContextSeed.SeedData(this.Categories, this.Products);
        }

        public IMongoCollection<Category> Categories { get; }
        public IMongoCollection<Product> Products { get; }
    }

    
}
