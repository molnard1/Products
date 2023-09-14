namespace ProductAPI
{
    public class Dtos
    {
        public record ProductDto(Guid Id, string ProductNeve, int ProductPrice, DateTimeOffset CreatedTime, DateTimeOffset ModifiedTime);
    }
}
