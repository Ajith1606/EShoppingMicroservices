
namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdRequest>;
    public record GetProductByIdRequest(Product Product);
    internal class GetProductsByIdQueryHandler(IDocumentSession session,
        ILogger<GetProductsByIdQueryHandler> logger) 
        : IQueryHandler<GetProductByIdQuery, GetProductByIdRequest>
    {
        public async Task<GetProductByIdRequest> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsByIdQueryHandler.Handle called with {@Query}", query);

            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

            if (product == null)
            {
                
                throw new ProductNotFoundException();
                
                }

            return new GetProductByIdRequest(product);
        }
    }
}
