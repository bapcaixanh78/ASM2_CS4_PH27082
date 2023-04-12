

using ASM2.IServices;
using ASM2.Models;

namespace ASM2.Services
{
    public class CartDetailService : ICartDetailService
    {
        ShopDbcontext _dbContext;
        public CartDetailService()
        {
            _dbContext = new ShopDbcontext();
        }

        public bool CreateCartDetails(CartDetail p)
        {
            try
            {
                _dbContext.CartDetails.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DeleteCartDetails(Guid id)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var bill = _dbContext.CartDetails.FirstOrDefault(x => x.Id == id);
                _dbContext.CartDetails.Remove(bill);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public List<CartDetail> GetAllCartDetails()
        {
            return _dbContext.CartDetails.ToList();
        }

        public CartDetail GetCartDetailsById(Guid id)
        {
            return _dbContext.CartDetails.FirstOrDefault(c => c.Id == id);
        }

        public CartDetail GetCartDetailsByIdProduct(Guid idprod)
        {
            return GetAllCartDetails().FirstOrDefault(c => c.IdSP == idprod);
        }

        public List<CartDetail> GetCartDetailsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCartDetails(CartDetail p)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var cartDetails = _dbContext.CartDetails.FirstOrDefault(x => x.Id == p.Id);
                cartDetails.IdSP = p.IdSP;
                cartDetails.Id = p.Id;
                cartDetails.Quantity = p.Quantity;
                _dbContext.CartDetails.Update(cartDetails);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
