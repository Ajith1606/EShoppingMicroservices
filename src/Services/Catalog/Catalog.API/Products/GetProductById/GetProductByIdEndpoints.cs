
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductsByIdResponse(Product Product);
    public class GetProductByIdEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                var response = result.Adapt<GetProductsByIdResponse>();
                return Results.Ok(response);
            })
           .WithName("GetProductById")
           .Produces<GetProductResponse>(StatusCodes.Status200OK)
           .ProducesProblem(StatusCodes.Status500InternalServerError)
           .WithSummary("Get Product By Id")
           .WithDescription("Get Product By Id");
        }
    }
}
