namespace Final_Project.Models
    public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<Product> Products { get; set; }
}
