namespace ProvaPub.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int CustomerId { get; set; }
        public string OrderDate { get; set; } = string.Empty;
        public Customer Customer { get; set; }
    }
}
