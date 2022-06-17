using DemoGraphQL.Application.Configurations;
using DemoGraphQL.Application.Data;
using DemoGraphQL.Application.Data.Repositories;
using DemoGraphQL.Application.Queries;
using DemoGraphQL.Application.Resolvers;
using DemoGraphQL.Application.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDbConfiguration>(builder.Configuration.GetSection("MongoDbConfiguration"));

builder.Services.AddSingleton<CatalogContext>();

builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<ProductRepository>();

builder.Services
      .AddGraphQLServer()
      .AddQueryType<Query>()
      .AddType<ProductType>()
      .AddType<CategoryResolver>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/api/graphql");

app.Run();
