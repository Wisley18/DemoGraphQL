using DemoGraphQL.Application.Data.Entities;
using DemoGraphQL.Application.Data.Repositories;
using HotChocolate;

namespace DemoGraphQL.Application.Queries
{
    public class Query
    {
        public Task<IEnumerable<Product>> GetProductsAsync([Service] IProductRepository productRepository) =>
            productRepository.GetAllAsync();

        public Task<Product> GetProductById(string id, [Service] IProductRepository productRepository) =>
            productRepository.GetByIdAsync(id);

        // Add any queries you want here..
        // - Get categories
        // - Get products by category
        // - etc
    }
}
