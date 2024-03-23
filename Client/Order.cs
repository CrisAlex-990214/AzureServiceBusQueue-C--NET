namespace Client
{
    public class Order
    {
        public Guid ProductId { get; set; }
        public string Customer { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
