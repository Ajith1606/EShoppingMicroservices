namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery() : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    internal class GetProductsQueryHandler(IDocumentSession session)
            : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {        
            //Business Logic to get products
            //Fetch products from database
            var products = await session.Query<Product>().ToListAsync(cancellationToken);
            //Return GetProductsResult result
            return new GetProductsResult(products);
        }
   
    }
}
