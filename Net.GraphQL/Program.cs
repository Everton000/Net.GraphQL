using Microsoft.EntityFrameworkCore;
using Net.GraphQL.Application.Services;
using Net.GraphQL.Domain.Interfaces;
using Net.GraphQL.Infrastructure.Data;
using Net.GraphQL.Infrastructure.Repositories;
using Net.GraphQL.Mutations;
using Net.GraphQL.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBGraphQL")));

// Add services to the container.
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddTypeExtension<ClientQuery>()
    .AddTypeExtension<ProductQuery>()
    .AddTypeExtension<OrderQuery>()
    .AddMutationType<Mutation>()
    .AddTypeExtension<ClientMutation>()
    .AddTypeExtension<ProductMutation>()
    .AddTypeExtension<OrderMutation>();

var app = builder.Build();

app.UseRouting();

app.MapGraphQL();

app.MapBananaCakePop("/graphql-ui");

app.Run();
