using ASM2.Models;


namespace ASM2.IServices
{
    public interface IProductService
    {
        public bool CreateProduct(Product p);
        public bool UpdateProduct(Product p);
        public bool DeleteProduct(Guid id);
        public List<Product> GetAllProducts();
        public List<Product> ListProductUpdate();
        public Product GetProductById(Guid id);
        public List<Product> GetProductByName(string name);
    }
}