using ASM2.Models;

namespace ASM2.IServices
{
    public interface ICartService
    {
        public bool CreateCart(Cart p);
        public bool UpdateCart(Cart p);
        public bool DeleteCart(Guid id);
        public List<Cart> GetAllCarts();
        public Cart GetCartById(Guid id);
        public List<Cart> GetCartByName(string name);
    }
}
