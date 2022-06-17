using DemoGraphQL.Application.Data.Entities;
using DemoGraphQL.Application.Data.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace DemoGraphQL.Application.Resolvers
{
    [ExtendObjectType(Name = "Category")]
    public class CategoryResolver
    {
        public Task<Category> GetCategoryAsync(
          [Parent] Product product,
          [Service] ICategoryRepository categoryRepository) => categoryRepository.GetById(product.CategoryId);
    }
}
