using DemoGraphQL.Application.Data.Entities;
using MongoDB.Driver;

namespace DemoGraphQL.Application.Data.Repositories
{
    public class CategoryRepository
    {
        private readonly CatalogContext catalogContext;

        public CategoryRepository(CatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }

        public async Task<Category> GetById(string id)
        {
            var filter = Builders<Category>.Filter.Eq(_ => _.Id, id);

            return await this.catalogContext.Categories.Find(filter).FirstOrDefaultAsync();
        }
    }
}
