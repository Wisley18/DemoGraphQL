using DemoGraphQL.Application.Configurations;
using DemoGraphQL.Application.Data.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGraphQL.Application.Data
{
    public class CatalogContext
    {
        private const string ProductCollectionName = "Products";
        private const string CategoryCollectionName = "Categories";

        public CatalogContext(MongoDbConfiguration mongoDbConfiguration)
        {
            var client = new MongoClient(mongoDbConfiguration.ConnectionString);
            var database = client.GetDatabase(mongoDbConfiguration.Database);

            this.Categories = database.GetCollection<Category>(CategoryCollectionName);
            this.Products = database.GetCollection<Product>(ProductCollectionName);

            CatalogContextSeed.SeedData(this.Categories, this.Products);
        }

        public IMongoCollection<Category> Categories { get; }
        public IMongoCollection<Product> Products { get; }
    }
}
