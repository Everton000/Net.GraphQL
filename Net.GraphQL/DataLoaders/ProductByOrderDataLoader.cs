using Net.GraphQL.Domain.Entities;
using Net.GraphQL.Domain.Interfaces;

namespace Net.GraphQL.DataLoaders;

public class ProductByOrderDataLoader : BatchDataLoader<int, IEnumerable<Product>>
{
    private readonly IProductService _productService;

    public ProductByOrderDataLoader(
        IProductService productService,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null
    )
        : base(batchScheduler, options)
    {
        _productService = productService;
    }

    protected override async Task<IReadOnlyDictionary<int, IEnumerable<Product>>> LoadBatchAsync(
        IReadOnlyList<int> orderIds,
        CancellationToken cancellationToken
    )
    {
        var products = await _productService.GetByOrderIds(orderIds);

        return products
            .SelectMany(p => p.Orders!.Select(o => new { o.Id, Product = p }))
            .GroupBy(x => x.Id)
            .ToDictionary(g => g.Key, g => g.Select(x => x.Product).AsEnumerable());
    }
}
