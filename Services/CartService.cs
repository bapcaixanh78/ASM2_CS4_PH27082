using ASM2.IServices;
using ASM2.Models;

namespace ASM2.Services
{
    public class CartService : ICartService
    {
        ShopDbcontext _dbContext;
        public CartService()
        {
            _dbContext = new ShopDbcontext();
        }
        public bool CreateCart(Cart p)
        {
            try
            {
                _dbContext.Carts.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DeleteCart(Guid id)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var bill = _dbContext.Carts.FirstOrDefault(x => x.UserId == id);
                _dbContext.Carts.Remove(bill);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public List<Cart> GetAllCarts()
        {
            return _dbContext.Carts.ToList();
        }

        public Cart GetCartById(Guid id)
        {
            return _dbContext.Carts.FirstOrDefault(c => c.UserId == id);
        }

        public List<Cart> GetCartByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCart(Cart p)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var bill = _dbContext.Carts.FirstOrDefault(x => x.UserId == p.UserId);
                bill.UserId = p.UserId;
                bill.Description = p.Description;
                _dbContext.Carts.Update(bill);
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
