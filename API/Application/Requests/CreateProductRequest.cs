namespace API.Application.Requests
{
    public sealed record CreateProductRequest(string Name, string Description, double Price);
}
