using BuildingBlocks.CQRS;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest
     (
     string Name,
     List<string> Categories,
     string Description,
     string ImageFile,
     decimal Price,
     int Stock
     );
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint
    {
    }
}
