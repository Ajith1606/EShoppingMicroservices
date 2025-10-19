namespace Catalog.API.Products.CreateProduct
{
    public record  CreateProductCommand
        (
        string Name,
        List<string> Categories,
        string Description,
        string ImageFile,
        decimal Price
        ) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Bussiness Logic to create a product

            //Create Product entity from command object
            //Save the product entity to database
            //Return CreateProductResult result

            //Create Product entity from command object
            var product = new Product
            {             
                Name = command.Name,
                Categories = command.Categories,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };
            //TODO
            //Save the product entity to database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            //Return CreateProductResult result
            return new CreateProductResult(product.Id);
           
        }
    }
}
