
namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdRequest>;
    public record GetProductByIdRequest(Product Product);
    internal class GetProductsByIdQueryHandler(IDocumentSession session) 
        : IQueryHandler<GetProductByIdQuery, GetProductByIdRequest>
    {
        public async Task<GetProductByIdRequest> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {           
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

            if (product == null)
            {
                
                throw new ProductNotFoundException(query.Id);
                
                }

            return new GetProductByIdRequest(product);
        }
    }
}
