namespace API.Application.Responses
{
    public sealed record ProductResponse(Guid Id, string Name, string Description, double Price);
}
