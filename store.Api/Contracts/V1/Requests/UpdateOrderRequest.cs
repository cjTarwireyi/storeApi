namespace store.Api.Contracts.V1.Requests
{
    public class UpdateOrderRequest
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ShippingAddress { get; set; }
        public Guid ProductId { get; set; }
    }
}
