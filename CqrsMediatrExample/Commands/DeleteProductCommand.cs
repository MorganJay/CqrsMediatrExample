using MediatR;

namespace CqrsMediatrExample.Commands
{
    public record DeleteProductCommand(int Id) : IRequest;
}
