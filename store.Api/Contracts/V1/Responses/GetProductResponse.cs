namespace store.Api.Contracts.V1.Responses
{
    public class GetProductResponse
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
