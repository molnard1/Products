namespace ProductAPI
{
    public class Dtos
    {
        public record ProductDto(Guid Id, string ProductName, int ProductPrice, DateTimeOffset CreatedTime, DateTimeOffset ModifiedTime);

        public record CreateObjectDto(string ProductName, int ProductPrice);

        public record UpdateProductDto(string ProductName, int ProductPrice);
    }
}
