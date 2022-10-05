using MediatR;

namespace CqrsMediatrExample.Commands
{
    public record UpdateProductCommand(int Id, Product Product) : IRequest<Product>;
}
