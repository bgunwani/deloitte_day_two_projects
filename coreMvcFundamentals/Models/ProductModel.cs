namespace coreMvcFundamentals.Models
{
    public class ProductModel
    {
        List<Product> products = new List<Product>()
        {
            new Product() { Id = 1, Name = "Product One", Price = 1200, Image = "https://d3nn873nee648n.cloudfront.net/900x600/20415/300-PR1021370.jpg" },
            new Product() { Id = 2, Name = "Product Two", Price = 2200, Image = "https://d3nn873nee648n.cloudfront.net/900x600/20415/300-PR1021370.jpg" },
            new Product() { Id = 3, Name = "Product Three", Price = 3200, Image = "https://d3nn873nee648n.cloudfront.net/900x600/20415/300-PR1021370.jpg" },
            new Product() { Id = 4, Name = "Product Four", Price = 4500, Image = "https://d3nn873nee648n.cloudfront.net/900x600/20415/300-PR1021370.jpg" }
        };
        public List<Product> findAll()
        {
            return products;
        }

        public Product? findById(int id)
        {
            var product = products.Find(x => x.Id == id);
            return product;
        }
    }
}
