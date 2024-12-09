namespace Final_Project.Models

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
