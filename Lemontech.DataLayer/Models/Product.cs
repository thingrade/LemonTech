namespace Lemontech.DataLayer.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }

    public class ProductResult : Product
    {
        public string CategoryName { get; set; }
    }
}
