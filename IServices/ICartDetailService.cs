using ASM2.Models;

namespace ASM2.IServices
{
    public interface ICartDetailService
    {
        public bool CreateCartDetails(CartDetail p);
        public bool UpdateCartDetails(CartDetail p);
        public bool DeleteCartDetails(Guid id);
        public List<CartDetail> GetAllCartDetails();
        public CartDetail GetCartDetailsById(Guid id);
        public CartDetail GetCartDetailsByIdProduct(Guid idprod);
        public List<CartDetail> GetCartDetailsByName(string name);
    }
}
